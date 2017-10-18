using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Spaceshipコンポーネント /
    Spaceship spaceship;

    // Startメソッドをコルーチンとして呼び出す /
    IEnumerator Start (){
        spaceship = GetComponent<Spaceship>();

        while (true) {
            // 弾をプレイヤーと同じ位置/角度で生成
            spaceship.Shot(transform);

            // ショット音 /
            GetComponent<AudioSource>().Play();

            // offset /
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

	// Update is called once per frame
	void Update () {
        // 左右 /
        float x = Input.GetAxisRaw("Horizontal");

        // 上下 /
        float y = Input.GetAxisRaw("Vertical");

        // 移動向きを求める /
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動 /
        Move(direction);
	}

    // 移動 /
    void Move(Vector2 direction){
        // 左下のワールド座標を取得 /
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 右上のワールド座標を取得 /
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤー座標取得 /
        Vector2 pos = transform.position;

        // 移動量を設定 /
        pos += direction * spaceship.speed * Time.deltaTime;

        // 画面内にクリップ /
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // プレイヤー座標設定 /
        transform.position = pos;
    }

    // 当たり判定 /
    private void OnTriggerEnter2D(Collider2D c) {
        // レイヤー名取得 /
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        
        if (layerName == "Bullet (Enemy)") {
            // 弾の削除 /
            Destroy(c.gameObject);
        }

        if (layerName == "Bullet (Enemy)" || layerName == "Enemy") {
            // 爆発 /
            spaceship.Explosion();

            // プレイヤー削除 /
            Destroy(gameObject);
        }
    }
}
