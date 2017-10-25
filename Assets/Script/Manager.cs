using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Player prefub/
	public GameObject player;

	// タイトル/
	private GameObject title;

	// Use this for initialization
	void Start () {
		// Titleオブジェクトの取得/
		title = GameObject.Find("Title");
	}
	
	// Update is called once per frame
	void Update () {
		if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X)) {
			GameStart();
		}
	}

	void GameStart() {
		// タイトル非表示後にプレイヤー表示 /
		title.SetActive(false);
		Instantiate(player, player.transform.position, player.transform.rotation);
	}

	public void GameOver() {
		// タイトル表示 /
		title.SetActive(true);
	}

	public bool IsPlaying() {
		// タイトル表示判定 /
		return title.activeSelf == false;
	}
}
