using UnityEngine;
using System.Collections;

public class HeroBehaviour : MonoBehaviour {

	public bool spawnSizing = false;
	public float maxsize = 10;
	private bool runOnce = true;	
	public int playerloci, playerlocj, tarloci, tarlocj, dloci, dlocj;
	public Transform[,] playerLoc;
	public float countdown = 0;
	private int x = 25;
	private int z = 25;
	private GameObject mSelectedObject;
	private float distanceToTarget, distanceCounter;
	public float speedLimit = 4;
	public int maxMoves = 4;
	public int moveCost;
	public string movesLeftSTR = "4";
	public float cooldown = 0;
	
	// Use this for initialization
	void Start () {
		
		GameObject Object1 = GameObject.FindGameObjectWithTag("GameController"); //Access HexGrid-script through this.
		HexGrid Script1 = Object1.GetComponent<HexGrid>();
		playerLoc = Script1.pieceInfo;
		playerloci = Script1.savex;
		playerlocj = Script1.savez;
		Debug.Log (transform.position);
		
	}
	
	// Update is called once per frame
	void Update () {

		cooldown -= Time.deltaTime;

		if (spawnSizing && maxsize > 0)
		{ 
			this.transform.localScale += new Vector3(0,0, 0.05f);
			maxsize -= Time.deltaTime;
		}

		if (Input.GetKeyDown("space") && countdown < 1) 
		{
			speedLimit = maxMoves; 
			cooldown = 6;
			movesLeftSTR = speedLimit.ToString();
		}

		if (runOnce){
			for( int i = 0; i < x; i++ ) {
				for( int j = 0; j < z; j++ ) {
					
					if (playerLoc[i,j].position == this.transform.position) {
						playerloci = i;
						playerlocj = j;
					}
				}
			}
			runOnce = false;
		}
		if (Input.GetMouseButtonDown(0) && cooldown < 1){
			SelectObjectByMousePos();
			distanceToTarget = Vector3.Distance (this.transform.position, mSelectedObject.transform.position);
			distanceCounter = distanceToTarget/1.75f;
			moveCost = Mathf.CeilToInt(distanceCounter);

			if (speedLimit - moveCost >= 0){
			speedLimit -= moveCost;
			movesLeftSTR = speedLimit.ToString();
			}
			else {moveCost = 0;}

			countdown = (2 * moveCost + 1);	
		}
		
		if (distanceToTarget < (moveCost * 1.75)){
		if (countdown > 1) {

				countdown -= Time.deltaTime;
			transform.position = Vector3.MoveTowards(this.transform.position, playerLoc[tarloci,tarlocj].position, Time.deltaTime);
			

			//if (Mathf.Abs( dloci) > Mathf.Abs(dlocj) && dloci > 0) // i larger and pos
			//{if (countdown < 1) {playerloci -= 1;}}
			//if (Mathf.Abs( dloci) >= Mathf.Abs(dlocj) && dloci < 0) // i larger and neg
			//{if (countdown < 1) {playerloci += 1;}}
			//if (Mathf.Abs( dloci) <= Mathf.Abs(dlocj) && dlocj > 0) // j larger and pos
			//{if (countdown < 1) {playerlocj -= 1;}}
			//if (Mathf.Abs( dloci) < Mathf.Abs(dlocj) && dlocj < 0) // j larger and neg
			//{if (countdown < 1) {playerlocj += 1;}}
			
				if (countdown < 1) {
					playerloci = tarloci; 
					playerlocj = tarlocj;

				}
			}

			
		}
		//if (countdown < 1) {playerloci = tarloci; playerlocj = tarlocj;}
	}

	private void SelectObjectByMousePos()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1000F))
		{
			// get game object
			GameObject rayCastedGO = hit.collider.gameObject;
			
			// select object
			this.SelectedObject = rayCastedGO;
		}
	}

	public GameObject SelectedObject
	{
		get
		{
			return mSelectedObject;
		}
		set
		{
			// get old game object
			GameObject goOld = mSelectedObject;

			// assign new game object
			mSelectedObject = value;
			Debug.Log(mSelectedObject.transform.position);
			for( int i = 0; i < x; i++ ) {
				for( int j = 0; j < z; j++ ) {

					if (playerLoc[i,j].position == mSelectedObject.transform.position) {
						tarloci = i;
						tarlocj = j;

					}
				}
			}
			//move toward target
			dloci = playerloci - tarloci;
			dlocj = playerlocj - tarlocj;


		}
	}

}

	