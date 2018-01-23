using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
	Left = 0,
	Right = 1,
	Up = 2,
	Down = 3
}

public class BackgroundMovement : MonoBehaviour {
	public float baseSpeed = 0.0f;
	public bool playLoop = false;
	public bool active = true;
	public MovementType moveType = 0; //Left,Right,Up,Down
	public float leftPoint = 0.0f;
	public float rightPoint = 0.0f;
	public float upPoint = 0.0f;
	public float downPoint = 0.0f;

	void Update () {
		if (active == false) {
			return;
		}
		switch (moveType) {
		case MovementType.Left:
			this.GetComponent<RectTransform> ().transform.Translate (new Vector3 (-baseSpeed * Time.fixedDeltaTime, 0.0f, 0.0f));
			if (this.GetComponent<RectTransform> ().anchoredPosition3D.x <= leftPoint) {
				this.GetComponent<RectTransform> ().transform.Translate (new Vector3 ((rightPoint-leftPoint), 0.0f, 0.0f));
				if (playLoop == false) {
					this.GetComponent<BackgroundMovement> ().enabled = false;
				}
			}
			break;
		case MovementType.Right:
			this.GetComponent<RectTransform> ().transform.Translate (new Vector3 (baseSpeed * Time.fixedDeltaTime, 0.0f, 0.0f));
			if (this.GetComponent<RectTransform> ().anchoredPosition3D.x >= rightPoint) {
				this.GetComponent<RectTransform> ().transform.Translate (new Vector3 ((leftPoint-rightPoint), 0.0f, 0.0f));
				if (playLoop == false) {
					this.GetComponent<BackgroundMovement> ().enabled = false;
				}
			}
			break;
		case MovementType.Up:
			this.GetComponent<RectTransform> ().transform.Translate (new Vector3 (0.0f, baseSpeed * Time.fixedDeltaTime, 0.0f));
			if (this.GetComponent<RectTransform> ().anchoredPosition3D.y >= upPoint) {
				this.GetComponent<RectTransform> ().transform.Translate (new Vector3 (0.0f, (downPoint-upPoint), 0.0f));
				if (playLoop == false) {
					this.GetComponent<BackgroundMovement> ().enabled = false;
				}
			}
			break;
		case MovementType.Down:
			this.GetComponent<RectTransform> ().transform.Translate (new Vector3 (0.0f, -baseSpeed * Time.fixedDeltaTime, 0.0f));
			if (this.GetComponent<RectTransform> ().anchoredPosition3D.y <= downPoint) {
				this.GetComponent<RectTransform> ().transform.Translate (new Vector3 (0.0f, (upPoint-downPoint), 0.0f));
				if (playLoop == false) {
					this.GetComponent<BackgroundMovement> ().enabled = false;
				}
			}
			break;
		}
	}
}
