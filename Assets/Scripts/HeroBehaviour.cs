using UnityEngine;
using System.Collections;

public class HeroBehaviour : MonoBehaviour {

	public bool spawnSizing = false;
	public float maxsize = 10;
	
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (spawnSizing && maxsize > 0)
		{ 
			this.transform.localScale += new Vector3(0,0, 0.05f);
			maxsize -= Time.deltaTime;
		}
		
	}
}
