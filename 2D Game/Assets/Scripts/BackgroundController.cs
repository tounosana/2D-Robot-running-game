using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public GameObject[] backgroundObjs;

	public void BackgroundStartMoving(){
		for (int i = 0; i < backgroundObjs.Length; i++) {
			backgroundObjs [i].GetComponent<BackgroundMovement> ().active = true;
		}
	}
	public void BackgroundStopMoving(){
		for (int i = 0; i < backgroundObjs.Length; i++) {
			backgroundObjs [i].GetComponent<BackgroundMovement> ().active = false;
		}
	}
}
