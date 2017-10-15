using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Spaceshipコンポーネント /
    Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
        // Spaceshipコンポーネント取得 /
        spaceship = GetComponent<Spaceship>();

        // ローカル座標よりY座標をマイナス方向に移動 /
        spaceship.Move(transform.up * -1);

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

    // 当たり判定 /
    private void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名取得 /
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // Playerの弾以外は何もしない /
        if ( layerName != "Bullet (Player)") {
            return;
        }

        // 弾の削除 /
        Destroy(c.gameObject);

        // 爆発 /
        spaceship.Explosion();

        // プレイヤー削除 /
        Destroy(gameObject);
    }
}
