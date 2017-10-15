using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    // 弾速 /
    public int speed = 10;

    // 弾削除までの時間 /
    public float lifeTime = 5;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        // 弾の削除 /
        Destroy(gameObject, lifeTime);
	}
}
