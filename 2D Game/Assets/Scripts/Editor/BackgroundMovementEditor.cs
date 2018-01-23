using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(BackgroundMovement))]
public class BackgroundMovementEditor : Editor {
	public override void OnInspectorGUI ()
	{
		BackgroundMovement myTarget = (BackgroundMovement)target;
		myTarget.active = EditorGUILayout.Toggle ("Active",myTarget.active);
		myTarget.baseSpeed = EditorGUILayout.FloatField("Base Speed", myTarget.baseSpeed);
		myTarget.playLoop = EditorGUILayout.Toggle ("Play Loop?",myTarget.playLoop);
		myTarget.moveType = (MovementType) EditorGUILayout.EnumPopup("MoveMent Type",myTarget.moveType);
		switch (myTarget.moveType) {
		case MovementType.Left:
			myTarget.rightPoint = EditorGUILayout.FloatField("Max x position", myTarget.rightPoint);
			if (myTarget.rightPoint < myTarget.leftPoint) {
				myTarget.leftPoint = myTarget.rightPoint;
			}
			myTarget.leftPoint = EditorGUILayout.FloatField ("Min x position", myTarget.leftPoint);
			if (myTarget.leftPoint > myTarget.rightPoint) {
				myTarget.rightPoint = myTarget.leftPoint;
			}
			break;
		case MovementType.Right:
			myTarget.rightPoint = EditorGUILayout.FloatField ("Max x position", myTarget.rightPoint);
			if (myTarget.rightPoint < myTarget.leftPoint) {
				myTarget.leftPoint = myTarget.rightPoint;
			}
			myTarget.leftPoint = EditorGUILayout.FloatField ("Min x position", myTarget.leftPoint);
			if (myTarget.leftPoint > myTarget.rightPoint) {
				myTarget.rightPoint = myTarget.leftPoint;
			}
			break;
		case MovementType.Up:
			myTarget.upPoint = EditorGUILayout.FloatField ("Max y position", myTarget.upPoint);
			if (myTarget.upPoint < myTarget.downPoint) {
				myTarget.downPoint = myTarget.upPoint;
			}
			myTarget.downPoint = EditorGUILayout.FloatField ("Min y position", myTarget.downPoint);
			if (myTarget.downPoint > myTarget.upPoint) {
				myTarget.upPoint = myTarget.downPoint;
			}
			break;
		case MovementType.Down:
			myTarget.upPoint = EditorGUILayout.FloatField ("Max y position", myTarget.upPoint);
			if (myTarget.upPoint < myTarget.downPoint) {
				myTarget.downPoint = myTarget.upPoint;
			}
			myTarget.downPoint = EditorGUILayout.FloatField ("Min y position", myTarget.downPoint);
			if (myTarget.downPoint > myTarget.upPoint) {
				myTarget.upPoint = myTarget.downPoint;
			}
			break;
		}
	}
}
