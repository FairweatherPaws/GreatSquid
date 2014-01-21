using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CharSelGlow : MonoBehaviour {

	public int thisClass;
	public bool chosenOne = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){

		(gameObject.GetComponent("Halo") as Behaviour).enabled = true;
		chosenOne = true;
		if (Input.GetMouseButtonDown(0))
		{
			GameObject Object1 = GameObject.FindGameObjectWithTag("GUIController");
			GUIScript Script1 = Object1.GetComponent<GUIScript>();
			Script1.characterClass = thisClass;
		}
	}

	void OnMouseExit(){
		chosenOne = false;
		(gameObject.GetComponent("Halo") as Behaviour).enabled = false;
	}
}
