using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public bool[] ButtonSet;

	public void ButtonAct(int number){
		if (ButtonSet [number] == false) {
			ButtonSet [number] = true;
		}
	}
	public void ButtonActReset(){
		for (int i = 0; i < ButtonSet.Length; i++) {
			ButtonSet [i] = false;
		}
	}
}
