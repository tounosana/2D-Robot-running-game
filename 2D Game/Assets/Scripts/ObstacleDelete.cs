using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDelete : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "death") {
			Destroy (other.transform.gameObject);
		} 
	}
}
