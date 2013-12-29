using UnityEngine;
using System.Collections;

public class HeroBehaviour : MonoBehaviour {

	public bool spawnSizing = false;
	public float maxsize = 10;
	private bool runOnce = true;	
	public int playerloci, playerlocj;
	public Transform[,] playerLoc;
	private int x = 25;
	private int z = 25;
	
	// Use this for initialization
	void Start () {
		
		GameObject Object1 = GameObject.Find("GameController"); //Access HexGrid-script through this.
		HexGrid Script1 = Object1.GetComponent<HexGrid>();
		playerLoc = Script1.pieceInfo;
		Debug.Log (transform.position);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (spawnSizing && maxsize > 0)
		{ 
			this.transform.localScale += new Vector3(0,0, 0.05f);
			maxsize -= Time.deltaTime;
		}

		if (runOnce){
			for( int i = 0; i < x; i++ ) {
				for( int j = 0; j < z; j++ ) {
					
					if (playerLoc[i,j].position == this.transform.position) {
						playerloci = i;
						playerlocj = j;
						Debug.Log (i);
					}
				}
			}
			runOnce = false;
		}
		
	}
}
