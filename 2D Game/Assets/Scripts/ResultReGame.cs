using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultReGame : MonoBehaviour {

	void OnEnable(){
		GameObject.Find ("ResultUI").GetComponent<ButtonController> ().ButtonSet [0] = true;
		this.enabled = false;
	}
}
