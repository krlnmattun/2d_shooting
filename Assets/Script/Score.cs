using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	// スコアを表示するGUIText /
	public GUIText scoreGUIText;

	// ハイスコアを表示するGUIText /
	public GUIText highScoreGUIText;

	// スコア /
	private int score;

	// ハイスコア /
	private int highScore;

	// ハイスコア保存キー /
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start() {
		Initialize();

	}

	// Update is called once per frame
	void Update() {
		// スコアがハイスコアより高い時 /
		if (highScore < score) {
			highScore = score;
		}

		// スコア表示 /
		scoreGUIText.text = score.ToString();
		highScoreGUIText.text = "HighScore : " + highScore.ToString();
	}

	// 初期化 /
	private void Initialize() {
		// スコア /
		score = 0;

		// ハイスコア /
		highScore = PlayerPrefs.GetInt(highScoreKey, 0);
	}

	// ポイントの追加 /
	public void AddPoint(int point) {
		score = score + point;
	}

	// ハイスコア保存 /
	public void Save(){
		// ハイスコア保存 /
		PlayerPrefs.SetInt(highScoreKey, highScore);

		// ゲーム開始前の状態に戻す /
		Initialize();
	}
}
