using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    // Wave prefabの格納 /
    public GameObject[] waves;

    // 現在のWave /
    private int currentWave;

    IEnumerator Start() {
        // Waveが存在しない場合はコルーチン終了 /
        if (waves.Length == 0) {
            yield break;
         }

        while (true) {
            // Wave作成 /
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする /
            wave.transform.parent = transform;

            // Waveの子要素のEmenyが全削除されるまで待機 /
            while (wave.transform.childCount != 0) {
                yield return new WaitForEndOfFrame();
            }

            // Wave削除 /
            Destroy(wave);

            // 格納Waveを全て実行したらWave数をリセットする /
            if (waves.Length <= ++currentWave) {
                currentWave = 0;
            }
        }
    }
}
