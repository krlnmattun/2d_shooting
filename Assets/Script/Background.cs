using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    // スクロール速度 /
    public float speed = 0.1f;

	// Update is called once per frame
	void Update () {
		// 時間経過でY座標を1まで変化(0～1をループ) /
        float y = Mathf.Repeat(Time.time * speed, 1);

        // Y座標のオフセット /
        Vector2 offset = new Vector2(0, y);

        // マテリアルにオフセットを設定 /
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}
