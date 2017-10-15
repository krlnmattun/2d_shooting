using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explositon : MonoBehaviour {

	void OnAnimationFinish(){
        Destroy(gameObject);
    }
}
