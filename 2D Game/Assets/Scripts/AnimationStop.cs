using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStop : MonoBehaviour {
	public bool selfAct = true;
	public GameObject nextAnimPlayObj;


	void OnEnable(){
		this.GetComponent<Animator> ().enabled = false;
		if (selfAct == false) {
			nextAnimPlayObj.GetComponent<Animator> ().enabled = true;
		}
		this.enabled = false;
	}
}
