using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergeShow : MonoBehaviour {
	public GameObject[] energeBars;
	public int nowEnerge;
	public int maxEnerge;

	void Update () {
		if(GameObject.Find ("GameRobot").GetComponent<RobotController> ().death!= true){
			nowEnerge = GameObject.Find ("GameRobot").GetComponent<RobotController> ().lessJumpTimes;
			maxEnerge = GameObject.Find ("GameRobot").GetComponent<RobotController> ().maxJumpTimes;
			int i;
			for (i = 0; i < nowEnerge; i++) {
				energeBars [i].SetActive (true);
			}
			for (i = nowEnerge; i < maxEnerge; i++) {
				energeBars [i].SetActive (false);
			}
		}
	}
}
