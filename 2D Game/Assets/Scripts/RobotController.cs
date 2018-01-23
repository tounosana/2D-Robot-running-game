using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {
	public GameObject backgroundController;
	public float jumpForce = 650.0f; 

	public int maxJumpTimes = 2;  
	public int lessJumpTimes = 2;
	public int passTime = 0;
	     
	public bool death = false;
	public bool touchGround = false;
	private Animator anim;            // Reference to the player's animator component.
	private Rigidbody2D rigidbody2D;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		backgroundController = GameObject.Find("BackgroundSets");
	}
	private void FixedUpdate()
	{
		anim.SetBool("Ground", touchGround);
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
	}
	public void OneClickJump(){
		if (death != true) {
			if (lessJumpTimes >= 1) {
				touchGround = false;
				lessJumpTimes--;
				rigidbody2D.velocity = new Vector2(0f, 0f);
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "death") {
			death = true;
			anim.SetBool("Death", death);
			GameObject.Find ("GameManager").GetComponent<GameStageController> ().gameEnd = true;
			GameObject.Find ("GameManager").GetComponent<GameStageController> ().endType = "death";
			backgroundController.GetComponent<BackgroundController> ().BackgroundStopMoving ();
		}
		if (other.tag == "ground") {
			touchGround = true;
			lessJumpTimes = maxJumpTimes;
		} 
	}
}
