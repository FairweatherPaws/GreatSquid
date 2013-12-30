﻿using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public string movesLeftSTR = "";
	private float countdown = 1;

	// Use this for initialization
	void Start () {
		GameObject Object1 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
		HeroBehaviour Script1 = Object1.GetComponent<HeroBehaviour>();
		movesLeftSTR = Script1.movesLeftSTR;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
			countdown = 1;
		}
		if (countdown > 0) {
			GameObject Object1 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
			HeroBehaviour Script1 = Object1.GetComponent<HeroBehaviour>();
			movesLeftSTR = Script1.movesLeftSTR;

			countdown -= Time.deltaTime;
		}
	}
	void OnGUI () {
		GameObject Object2 = GameObject.FindGameObjectWithTag("CameraController"); //Access cam-script through this.
		CameraScript Script2 = Object2.GetComponent<CameraScript>();

		if (Script2.currentCamera == Script2.mainCamera){

		GUI.Box (new Rect(10, 10, 200, 30),"Moves remaining: " +movesLeftSTR );
		}
	}
}
