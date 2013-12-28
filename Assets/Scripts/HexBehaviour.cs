using UnityEngine;
using System.Collections;

public class HexBehaviour : MonoBehaviour {

	public GameObject parentisation;

	// Use this for initialization
	void Start () {
		parentisation = GameObject.Find ("HexFolder");
		this.transform.parent = parentisation.transform; // Cleans up nicely. :P
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
