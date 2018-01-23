using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningAnimationEnd : MonoBehaviour {
	static float tempTime = 0.0f;
	public bool titleShow = false;

	void Update () {
		if ((this.gameObject.transform.position.x > 6.14f) && (titleShow == false)) {
			tempTime += Time.fixedDeltaTime;
		}
		if (tempTime >= 2.0f) {
			tempTime = 0.0f;
			titleShow = true;
			GameObject.Find ("GameManager").GetComponent<GameStageController> ().robotAnimationEnd = true;
		}
	}
}
