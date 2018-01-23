using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMake : MonoBehaviour {
	public GameObject backgroundController;
	public GameObject[] obstaclePrefabs;
	public int obstacleMax = 20;
	public int lessObstacleCount;
	//public bool work = true;
	public float time = 0.0f;

	public float reMakeTime; // 1level random N(1~3) + 0.45f , 2level  random N(1~3) + 0.9f
	public int ObstacleNumber;

	public bool canMakeObstacle = false;
	//public bool hole2Show = false;

	//public float standardTime = 0.45f;
	public float finishTimeUp = 0.0f;
	// Use this for initialization
	void Start () {
		lessObstacleCount = obstacleMax;
		reMakeTime = Random.Range (1.0f, 3.0f)+ 0.45f;
		ObstacleNumber = Random.Range (0, 4) ;
		backgroundController = GameObject.Find("BackgroundSets");
	}
	
	// Update is called once per frame
	void Update () {
		if ((GameObject.Find ("GameManager").GetComponent<GameStageController> ().gameEnd != true)&&(lessObstacleCount > 0) && (canMakeObstacle == true)) {
			GameObject obstacle = GameObject.Instantiate (obstaclePrefabs [ObstacleNumber])as GameObject;
			obstacle.transform.position = this.gameObject.transform.position ;
			if (ObstacleNumber == 0) {
				obstacle.transform.Translate (new Vector3 (0.0f, -0.2f, 0.0f));
			}
			else if (ObstacleNumber == 1) {
				obstacle.transform.Translate (new Vector3 (0.0f, 0.6f, 0.0f));
			} else if (ObstacleNumber > 1) {
				obstacle.transform.SetParent (GameObject.Find ("Stage").transform);
				obstacle.transform.Translate (new Vector3 (0.0f, -4.0f, 0.0f));
			}
			lessObstacleCount--;
			canMakeObstacle = false;
			ObstacleNumber = Random.Range (0, 4) ;

		}
		if (canMakeObstacle == false) {
			reMakeTime -=Time.fixedDeltaTime;
			if (reMakeTime < 0.0f) {
				canMakeObstacle = true;
				if (ObstacleNumber % 1 == 0) {
					reMakeTime = Random.Range (1.0f, 3.0f)  + 0.9f;
				} else {
					reMakeTime = Random.Range (1.0f, 3.0f) + 0.45f;
				}
			}
		}
		if (lessObstacleCount == 0) {
			finishTimeUp += Time.fixedDeltaTime;
			if (finishTimeUp >= 10.0f) {
				GameObject.Find ("GameManager").GetComponent<GameStageController> ().gameEnd = true;
				GameObject.Find ("GameManager").GetComponent<GameStageController> ().endType = "win";
				backgroundController.GetComponent<BackgroundController> ().BackgroundStopMoving ();
				GameObject.Find ("GameRobot").GetComponent<Animator> ().SetBool("Win", true);
				ResetData ();
			}
		}
	}
	public void ResetData (){
		lessObstacleCount = obstacleMax;
		reMakeTime = Random.Range (1.0f, 3.0f)+ 0.45f;
		ObstacleNumber = Random.Range (1, 5) ;
		time = 0.0f;
		finishTimeUp = 0.0f;
		canMakeObstacle = false;
	}
}
