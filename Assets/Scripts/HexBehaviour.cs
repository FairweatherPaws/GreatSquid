using UnityEngine;
using System.Collections;

public class HexBehaviour : MonoBehaviour {

	public GameObject parentisation;
	public bool forestsizing = false;
	public bool grasssizing = false;

	// Use this for initialization
	void Start () {
		parentisation = GameObject.Find ("HexFolder");
		this.transform.parent = parentisation.transform; // Cleans up nicely. :P
	if (forestsizing)
		{ 
			this.transform.localScale += new Vector3(0,0, Random.Range(-5, 10));
		}
		if (grasssizing)
		{ 
			this.transform.localScale += new Vector3(0,0, Random.Range(-2, 1));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
