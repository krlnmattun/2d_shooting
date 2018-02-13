using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// HP /
	public int hp = 1;

	// スコア /
	public int point = 100;

	// Spaceshipコンポーネント /
	Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
		// Spaceshipコンポーネント取得 /
		spaceship = GetComponent<Spaceship>();

		// ローカル座標よりY座標をマイナス方向に移動 /
		Move(transform.up * -1);

		// 弾発射をしない場合は処理終了 /
		if (spaceship.canShot == false) {
			yield break;
		}

		while (true) {
			// 子要素を全て取得 /
			for (int i=0; i<transform.childCount; ++i) {
				Transform shotPosition = transform.GetChild(i);

				// ShotPositionの位置/角度で弾を撃つ /
				spaceship.Shot(shotPosition);
			}

			// shotDelayだけ待つ /
			yield return new WaitForSeconds(spaceship.shotDelay);
		}	   
	}

	// 機体の移動 /
	public void Move(Vector2 direction)
	{
		GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
	}

	// 当たり判定 /
	private void OnTriggerEnter2D(Collider2D c)
	{
		// レイヤー名取得 /
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// Playerの弾以外は何もしない /
		if ( layerName != "Bullet (Player)") {
			return;
		}

		// PlayerBulletのTransfrom取得 /
		Transform pleyerBulletTransForm = c.transform.parent;

		// Bulletコンポーネント取得 /
		Bullet bullet = pleyerBulletTransForm.GetComponent<Bullet>();

		// HPを減らす /
		hp -= bullet.power;

		// 弾の削除 /
		Destroy(c.gameObject);

		// HP0以下の場合、削除処理 /
		if (hp <= 0) {
			// スコア加算 /
			FindObjectOfType<Score>().AddPoint(point);

			// 爆発 /
			spaceship.Explosion();

			// プレイヤー削除 /
			Destroy(gameObject);
		} else {
			spaceship.GetAnimator().SetTrigger("Damage");
		}
	}
}
