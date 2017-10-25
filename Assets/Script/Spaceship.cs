using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

	// 移動速度 /
	public float speed;

	// 発射間隔 /
	public float shotDelay;

	// 弾prefab /
	public GameObject bullet;

	// 弾発射の有無 /
	public bool canShot;

	// 爆発prefab /
	public GameObject explosion;

	// 爆発の生成 /
	public void Explosion(){
		Instantiate(explosion, transform.position, transform.rotation);
	}
 
	// 弾の生成 /
	public void Shot(Transform origin) {
		Instantiate(bullet, origin.position, origin.rotation);
	}
}
