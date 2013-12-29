using UnityEngine;
using System.Collections;

public class MonBehaviour : MonoBehaviour {

	//public HexGrid GameController;
	public bool spawnSizing = false;
	public float maxsize = 10;
	public float endturntimer = 6;
	private float countdown;
	public bool monTurn = false;
	private bool runOnce = true;
	private bool seekPlayLoc = true;
	private Transform[,] waypoints;
	private Transform[,] ownloc;
	private Transform[,] playerLoc;
	private int ownloci, ownlocj, playerLoci, playerLocj, dloci, dlocj;
	private int x = 25;
	private int z = 25;

	// Use this for initialization
	void Start () {


		GameObject Object1 = GameObject.Find("GameController"); //Access HexGrid-script through this.
		HexGrid Script1 = Object1.GetComponent<HexGrid>();
		waypoints = Script1.pieceInfo;


		GameObject Object2 = GameObject.Find("defHero"); //Access HeroBehaviour-script through this.
		HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();
		playerLoc = Script2.playerLoc;
		playerLoci = Script2.playerloci;
		playerLocj = Script2.playerlocj;



	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space")) {monTurn = true; countdown = 6; seekPlayLoc = true;}



		if (spawnSizing && maxsize > 0)
		{ 
				this.transform.localScale += new Vector3(0,0, 0.05f);
			maxsize -= Time.deltaTime;
		}

		if (monTurn)
		{
			// search own location match
			if (runOnce){
			for( int i = 0; i < x; i++ ) {
				for( int j = 0; j < z; j++ ) {
			
					if (waypoints[i,j].position == this.transform.position) {
						ownloci = i;
						ownlocj = j;
						Debug.Log (i);
						}
					}
				}
				runOnce = false;
			}
			// search player location match

			if (seekPlayLoc)
			{
				GameObject Object2 = GameObject.Find("defHero"); //Access HeroBehaviour-script through this.
				HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();
				playerLoci = Script2.playerloci;
				playerLocj = Script2.playerlocj;
				seekPlayLoc = false;
			}

			// move toward player
			dloci = ownloci - playerLoci;
			dlocj = ownlocj - playerLocj;

			countdown -= Time.deltaTime;
			
			if (Mathf.Abs( dloci) > Mathf.Abs(dlocj) && dloci >= 0) // i larger and pos
			{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci-1,ownlocj].position, Time.deltaTime);
				if (countdown < 1) {ownloci -= 1;}}
			if (Mathf.Abs( dloci) >= Mathf.Abs(dlocj) && dloci < 0) // i larger and neg
			{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci+1,ownlocj].position, Time.deltaTime);
				if (countdown < 1) {ownloci += 1;}}
			if (Mathf.Abs( dloci) <= Mathf.Abs(dlocj) && dlocj >= 0) // j larger and pos
			{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci,ownlocj-1].position, Time.deltaTime);
				if (countdown < 1) {ownlocj -= 1;}}
			if (Mathf.Abs( dloci) < Mathf.Abs(dlocj) && dlocj < 0) // j larger and neg
			{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci,ownlocj+1].position, Time.deltaTime);
				if (countdown < 1) {ownlocj += 1;}}
			Debug.Log(ownloci);

			if (countdown < 1) {
				monTurn = false;
			
				//snaps the pieces into their new places. Unelegant as can be.
			//	if (Mathf.Abs( dloci) > Mathf.Abs(dlocj) && dloci >= 0) // i larger and pos
			//	{this.transform.position = waypoints[ownloci-1,ownlocj].transform.position;}
			//	if (Mathf.Abs( dloci) >= Mathf.Abs(dlocj) && dloci < 0) // i larger and neg
			//	{this.transform.position = waypoints[ownloci+1,ownlocj].transform.position;}
			//	if (Mathf.Abs( dloci) <= Mathf.Abs(dlocj) && dlocj >= 0) // j larger and pos
			//	{this.transform.position = waypoints[ownloci,ownlocj-1].transform.position;}
			//	if (Mathf.Abs( dloci) < Mathf.Abs(dlocj) && dlocj < 0) // j larger and neg
			//	{this.transform.position = waypoints[ownloci,ownlocj+1].transform.position;}
			}
		}


	}
}
