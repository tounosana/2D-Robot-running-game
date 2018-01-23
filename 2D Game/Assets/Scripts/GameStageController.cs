using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageController : MonoBehaviour {

	public int stageNumber = 1; //1 = TopScene,2 = GameScene,3 = ResultScene;
	public int gameUINumber = 1;
	public float timer = 0.0f;

	//TopScene
	public bool startOpening = false;
	public bool openingEnd = false;
	public bool robotAnimationEnd = false;
	public ButtonController controller;
	public AudioClip topMusic;
	//GameScene
	public bool gameEnd = false;
	public AudioClip gameMusic;
	//ResultScene
	public string endType = "death"; // death , win
	public bool findUI = false;
	//

	void Start(){
		controller = GameObject.Find ("TopUI").GetComponent<ButtonController> ();
	}

	void Update () {
		//TopScene
		if (stageNumber == 1) {
			if (startOpening == false) {
				timer += Time.fixedDeltaTime;
				if (timer >= 3.0f) {
					GameObject.Find ("OpeningRobot1").GetComponent<Animator> ().enabled = true;
					timer = 0.0f;
					startOpening = true;
				}
			}
			if ((openingEnd == false) && (robotAnimationEnd == true)) {
				GameObject.Find ("TopUI").transform.Find ("TitleTextSet").gameObject.SetActive (true);
				GameObject.Find ("TopUI").transform.Find ("StartButton").gameObject.SetActive (true);
				GameObject.Find ("TopUI").transform.Find ("ExitButton").gameObject.SetActive (true);
				openingEnd = true;
			}
			if (controller.ButtonSet [0] == true) {
				GameObject.Find ("OpeningRobot2").GetComponent<OpeningAnimationEnd> ().titleShow = false;
				Debug.Log ("Game Start!");
				controller.ButtonActReset ();
				GameObject.Find ("TopUI").transform.Find ("TitleTextSet").gameObject.SetActive (false);
				GameObject.Find ("TopUI").transform.Find ("StartButton").gameObject.SetActive (false);
				GameObject.Find ("TopUI").transform.Find ("ExitButton").gameObject.SetActive (false);
				stageNumber = 2;
				UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene");
				this.GetComponent<AudioSource> ().clip = gameMusic;
				this.GetComponent<AudioSource> ().Play ();
				DontDestroyOnLoad (this.gameObject);
			}
			if (controller.ButtonSet [1] == true) {
				Debug.Log ("Game Exit!");
				Application.Quit ();
			}
		}
		//GameScene
		if (stageNumber == 2) {
			controller = GameObject.Find ("GameUI").GetComponent<ButtonController> ();
			GameObject.Find ("GameUI").transform.Find ("Button").gameObject.SetActive (true);
			GameObject.Find ("GameUI").transform.Find ("EnergeBackground").gameObject.SetActive (true);

			if (controller.ButtonSet [0] == true) {
				controller.ButtonSet [0] = false;
				GameObject.Find ("GameRobot").GetComponent<RobotController> ().OneClickJump ();
			}
			if (gameEnd == true) {
				timer += Time.fixedDeltaTime;
				if (timer >= 2.0f) {
					timer = 0.0f;
					Debug.Log ("Game End!");
					gameEnd = false;
					stageNumber = 3;
					this.GetComponent<AudioSource> ().Stop();
					GameObject.Find ("GameUI").transform.Find ("Button").gameObject.SetActive (false);
					GameObject.Find ("GameUI").transform.Find ("EnergeBackground").gameObject.SetActive (false);
					UnityEngine.SceneManagement.SceneManager.LoadScene ("ResultScene");
				}
			}
		}
		//ResultScene
		if (stageNumber == 3) {
			if (findUI == false) {
				timer += Time.fixedDeltaTime;
				if (GameObject.Find ("ResultUI").GetComponent<ButtonController> () != null) {
					controller = GameObject.Find ("ResultUI").GetComponent<ButtonController> ();
				}
				if ((timer >= 2.0f) && (controller != null)) {
					timer = 0.0f;
					findUI = true;
					if (endType == "death") {
						GameObject.Find ("ResultUI").transform.Find ("ReGameButton").gameObject.SetActive (true);
						GameObject.Find ("ResultUI").transform.Find ("ReGameButton").Find ("Text").gameObject
							.GetComponent<UnityEngine.UI.Text> ().text = "再び挑戦する？";
						GameObject.Find ("ResultUI").transform.Find ("ReGameButton").GetComponent<ReGamePlay> ().win = false;
						GameObject.Find ("ResultUI").transform.Find ("QuitGameButton").gameObject.SetActive (true);
						GameObject.Find ("ResultUI").transform.Find ("QuitGameButton").Find ("Text").gameObject
							.GetComponent<UnityEngine.UI.Text> ().text = "放棄する？";
						GameObject.Find ("ResultUI").transform.Find ("EndType").gameObject.SetActive (true);
						GameObject.Find ("ResultUI").transform.Find ("EndType").gameObject
							.GetComponent<UnityEngine.UI.Text> ().text = "Game Over";
						GameObject.Find("CharacterRobotBoy").GetComponent<Animator> ().SetBool("win", false);
					} else {
						GameObject.Find ("ResultUI").transform.Find ("ReGameButton").gameObject.SetActive (true);
						GameObject.Find ("ResultUI").transform.Find ("ReGameButton").Find ("Text").gameObject
							.GetComponent<UnityEngine.UI.Text> ().text = "もう一回する？";
						GameObject.Find ("ResultUI").transform.Find ("ReGameButton").GetComponent<ReGamePlay> ().win = true;
						GameObject.Find ("ResultUI").transform.Find ("QuitGameButton").gameObject.SetActive (true);
						GameObject.Find ("ResultUI").transform.Find ("QuitGameButton").Find ("Text").gameObject
							.GetComponent<UnityEngine.UI.Text> ().text = "やめる？";
						GameObject.Find ("ResultUI").transform.Find ("EndType").gameObject.SetActive (true);
						GameObject.Find ("ResultUI").transform.Find ("EndType").gameObject
							.GetComponent<UnityEngine.UI.Text> ().text = "Game Clear";
						GameObject.Find("CharacterRobotBoy").GetComponent<Animator> ().SetBool("win", true);
					}
				}
			}
			if (controller.ButtonSet [0] == true) {
				Debug.Log ("Re Game!");
				controller.ButtonActReset ();
				findUI = false;
				GameObject.Find ("ResultUI").transform.Find ("ReGameButton").gameObject.SetActive (false);
				GameObject.Find ("ResultUI").transform.Find ("QuitGameButton").gameObject.SetActive (false);
				GameObject.Find ("ResultUI").transform.Find ("EndType").gameObject.SetActive (false);
				stageNumber = 2;
				this.GetComponent<AudioSource> ().clip = gameMusic;
				this.GetComponent<AudioSource> ().Play ();
				UnityEngine.SceneManagement.SceneManager.LoadScene ("GameScene");
			}
			if (controller.ButtonSet [1] == true) {
				Debug.Log ("Quit Game !");
				controller.ButtonActReset ();
				stageNumber = 1;
				this.GetComponent<AudioSource> ().clip = topMusic;
				this.GetComponent<AudioSource> ().Play ();
				UnityEngine.SceneManagement.SceneManager.LoadScene ("TopScene");
				DestroyObject(this.gameObject);
			}
		}
	}
}