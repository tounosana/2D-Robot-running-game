using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour {

	public int platformType = 0; //0 = platformSetGrass,1 = platformSetWall1,2 = platformSetWall2,3 = platformSetHole1,4 = platformSetHole2;
	public float moveSpeed = 0.1f;

	void Update () {
		if(GameObject.Find("GameManager").GetComponent<GameStageController>().gameEnd != true){
			this.transform.transform.Translate(-moveSpeed * Time.fixedDeltaTime,0.0f,0.0f); 
		}
	}
}
