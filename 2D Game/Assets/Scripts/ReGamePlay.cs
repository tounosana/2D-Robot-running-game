using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReGamePlay : MonoBehaviour {
	public bool win = false;
	public void ReGamePlayStart(){
		if (win == false) {
			GameObject.Find ("CharacterRobotBoy").GetComponent<Animator> ().SetBool ("regame", true);
		} else {
			GameObject.Find ("ResultUI").GetComponent<ButtonController> ().ButtonSet [0] = true;
		}
	}
}
