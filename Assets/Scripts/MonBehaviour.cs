using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MonBehaviour : MonoBehaviour {

	//public HexGrid GameController;
	public bool spawnSizing = false;
	public float maxsize = 10;
	public float endturntimer = 6;
	private float countdown;
	public bool monTurn = false;
	private bool runOnce = false;
	private bool seekPlayLoc = true;
	private Transform[,] waypoints;
	private Transform[,] ownloc;
	private Vector3 playerLoc;
	private int ownloci, ownlocj, playerLoci, playerLocj, dloci, dlocj, index;
	private int x = 25;
	private int z = 25;
	private Vector3 targetSpot;
	private float optimalDist;
	private List<float> optDist;
	private List<int> optDisti, optDistj;

	public bool gameOn = false;

	// Use this for initialization
	void Start () {


		GameObject Object1 = GameObject.FindGameObjectWithTag("GameController"); //Access HexGrid-script through this.
		HexGrid Script1 = Object1.GetComponent<HexGrid>();
		waypoints = Script1.pieceInfo;


		GameObject Object2 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
		HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();

		playerLoci = Script2.playerloci;
		playerLocj = Script2.playerlocj;



	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0) && gameOn == false)
		{
			
			GameObject Object2 = GameObject.FindGameObjectWithTag("GUIController"); //Access GUI-script through this.
			GUIScript Script2 = Object2.GetComponent<GUIScript>();
			gameOn = Script2.gameOn;
			
		}

		if (gameOn)
		{
			if (Input.GetKeyDown("space"))
			{ 
				GameObject Object2 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
				HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();
				if (Script2.countdown < 1) {monTurn = true; seekPlayLoc = true; countdown = 12; runOnce = true;}
			}


			if (spawnSizing && maxsize > 0)
			{ 
					this.transform.localScale += new Vector3(0,0, 0.05f);
				maxsize -= Time.deltaTime;
			}

			if (monTurn)
			{

				if (seekPlayLoc)
				{
					GameObject Object2 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
					HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();
					playerLoci = Script2.playerloci;
					playerLocj = Script2.playerlocj;
					playerLoc = Script2.transform.position;
					
					seekPlayLoc = false;
				}
				// search own location match
				if (runOnce){

					optDist = new List<float>();
					optDisti = new List<int>();
					optDistj = new List<int>();
					
				for( int i = 0; i < x; i++ ) {
					for( int j = 0; j < z; j++ ) {

						if (waypoints[i,j].position == this.transform.position) {
							ownloci = i;
							ownlocj = j;
							
							}
						}
					}
				
					for (int i = -2; i < 3; i++){
						for (int j = -2; j < 3; j++){
							{
								targetSpot = waypoints[ownloci+i,ownlocj+j].transform.position;
								optimalDist = Vector3.Distance (targetSpot, playerLoc);
								optDist.Add(optimalDist);
								optDisti.Add (i);
								optDistj.Add (j);
							}
						}
					}

					float shortestDist = optDist.Min<float>();
					index = optDist.IndexOf( shortestDist );

					ownloci += optDisti[index];
					ownlocj += optDistj[index];

					//--COMBAT IMMINENT-- INJECTION GOES HERE

					runOnce = false;
				}

				// search player location match



				// move toward player
				dloci = ownloci - playerLoci;
				dlocj = ownlocj - playerLocj;

				countdown -= Time.deltaTime;

				//scans the area around itself and chooses the best path








				transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci,ownlocj].position, Time.deltaTime);


				//if (Mathf.Abs( dloci) >= Mathf.Abs(dlocj)){}

				//if (Mathf.Abs( dloci) < Mathf.Abs(dlocj)){}

				//if (Mathf.Abs( dloci) > Mathf.Abs(dlocj) && dloci >= 0) // i larger and pos
				//{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci-1,ownlocj].position, Time.deltaTime);
				//	if (countdown < 1) {ownloci -= 1;}}
				//if (Mathf.Abs( dloci) >= Mathf.Abs(dlocj) && dloci < 0) // i larger and neg
				//{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci+1,ownlocj].position, Time.deltaTime);
				//	if (countdown < 1) {ownloci += 1;}}
				//if (Mathf.Abs( dloci) <= Mathf.Abs(dlocj) && dlocj >= 0) // j larger and pos
				//{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci,ownlocj-1].position, Time.deltaTime);
				//	if (countdown < 1) {ownlocj -= 1;}}
				//if (Mathf.Abs( dloci) < Mathf.Abs(dlocj) && dlocj < 0) // j larger and neg
				//{transform.position = Vector3.MoveTowards(this.transform.position, waypoints[ownloci,ownlocj+1].position, Time.deltaTime);
				//	if (countdown < 1) {ownlocj += 1;}}
			

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
}
