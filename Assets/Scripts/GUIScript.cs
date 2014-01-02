using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GUIScript : MonoBehaviour {

	public Transform IntroScreen, UpperLeftHud, Instructions, OptionScreen, BackgroundPlane;
	private GoTweenChain chain;
	public Material Instruct01, Instruct02, Instruct03, Instruct04;
	private Material[] instructRotation;
	private int instructRotationIndex;
	private Material currentMaterial;
	public bool gameOn = false;
	private GameObject[] gos;
	public bool audioOn = true;
	private TextMesh tm;


	private GameObject mSelectedObject;

	public GameObject blankBG, BacktoMainMenu, NextPage, PrevPage, goToInstruct, goToOptions, makeStart, leaveGame, muteAudio, returnToMainMenu;
	
	public string movesLeftSTR = "";
	private float countdown = 1;


	
	// Use this for initialization
	void Start () {
	
		instructRotation = new Material[] { Instruct01, Instruct02, Instruct03, Instruct04 };
		currentMaterial = Instruct01;
		gos = GameObject.FindGameObjectsWithTag("MenuText");
		mSelectedObject = blankBG;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(gameOn);
		if (gameOn == false) // Menu code
		{

			FindTarget();



			if(Input.GetKeyDown("m")) // starts the game running
			{
				gameOn = true;

			}

			if(Input.GetKeyDown("a")) //introscreen out
			{

				GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, -135 )).eulerAngles(new Vector3(117, 0, 0)));
				chain = new GoTweenChain();
				chain.append(rotTween);
				chain.play();
			
			}

			if(Input.GetKeyDown("q")) //introscreen in
			{
			
				GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(0, 0, 0)));
				chain = new GoTweenChain();
				chain.append(rotTween);
				chain.play();
			
			}

			if(Input.GetKeyDown("s")) // upperleft hud in
			{
			
				GoTween ulhudTween = new GoTween(UpperLeftHud, 3f, new GoTweenConfig().position (new Vector3( -135, -650, 70 )).eulerAngles(new Vector3(0, 0, 0)));
				chain = new GoTweenChain();
				chain.append(ulhudTween);
				chain.play();
			
			}
			if(Input.GetKeyDown("d")) // upperleft hud out
			{
			
				GoTween ulhudTween = new GoTween(UpperLeftHud, 3f, new GoTweenConfig().position (new Vector3( -175, -650, 60 )).eulerAngles(new Vector3(0, 90, 0)));
				chain = new GoTweenChain();
				chain.append(ulhudTween);
				chain.play();
			
			}
//			textObjectList = new List<GameObject>();




//			GameObject Object1[]  = GameObject[].FindGameObjectsWithTag("MenuText"); //Access Text-script through this.
//
//			for (int i = 0; i < 4; i++) {};
//
//			TextScript Script1 = Object1.GetComponent<TextScript>();
//			if (Script1.chosenOne == true)
//			{mSelectedObject = Script1.gameObject;}
//			Debug.Log (Script1.chosenOne);


			if(Input.GetMouseButtonDown(0))
			{
		//		SelectObjectByMousePos();

				if(mSelectedObject == goToInstruct) // open instructions
				{
					
					instructRotationIndex = 0;
					
					GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, 0 )));
					chain = new GoTweenChain();
					chain.append(instruTween);
					chain.play();
					
					GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, -135 )).eulerAngles(new Vector3(117, 0, 0), true));
					chain = new GoTweenChain();
					chain.append(rotTween);
					chain.play();
					
					ChangeMaterial();
					
				}

				if(mSelectedObject == NextPage) // next page in instructions
				{
					instructRotationIndex++;
					if (instructRotationIndex > instructRotation.Length-1)
					{
						instructRotationIndex--;
						GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, -400 )));
						chain = new GoTweenChain();
						chain.append(instruTween);
						chain.play();

						GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(117, 0, 0), true));
						chain = new GoTweenChain();
						chain.append(rotTween);
						chain.play();

					}
				
					ChangeMaterial();
				}

				if(mSelectedObject == PrevPage) // previous page in instructions
				{

					instructRotationIndex--;
					if (instructRotationIndex < 0)
					{
						instructRotationIndex = 0;
						GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, -400 )));
						chain = new GoTweenChain();
						chain.append(instruTween);
						chain.play();

						GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(117, 0, 0), true));
						chain = new GoTweenChain();
						chain.append(rotTween);
						chain.play();
					}
				
					ChangeMaterial();

				}

				if(mSelectedObject == BacktoMainMenu) // back to main menu
				{


						GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, -400 )));
						chain = new GoTweenChain();
						chain.append(instruTween);
						chain.play();
						
					GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(117, 0, 0), true));
						chain = new GoTweenChain();
						chain.append(rotTween);
						chain.play();

					}

				if(mSelectedObject == goToOptions) // open instructions
				{
					
					GoTween optiTween = new GoTween(OptionScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -800, 0 )));
					chain = new GoTweenChain();
					chain.append(optiTween);
					chain.play();
					
					GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, -135 )).eulerAngles(new Vector3(117, 0, 0), true));
					chain = new GoTweenChain();
					chain.append(rotTween);
					chain.play();
					

					
				}
				
				if(mSelectedObject == returnToMainMenu) // back to main menu
				{
					
					
					GoTween optiTween = new GoTween(OptionScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -800, -400 )));
					chain = new GoTweenChain();
					chain.append(optiTween);
					chain.play();
					
					GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(117, 0, 0), true));
					chain = new GoTweenChain();
					chain.append(rotTween);
					chain.play();
					
				}

				if(mSelectedObject == muteAudio)
				{
					if (audioOn)
					{
						AudioListener.volume = 0F;
						audioOn = false;
						tm = muteAudio.GetComponent<TextMesh>();
						tm.text = "Sound: disabled";
					}
					else {
						AudioListener.volume = 1F;
						audioOn = true;
						tm = muteAudio.GetComponent<TextMesh>();
						tm.text = "Sound: enabled";
					}


				}

				if(mSelectedObject == leaveGame)
				{
					Application.Quit();

				
				
				
				}

				if(mSelectedObject == makeStart) 
				
				{
					gameOn = true;

					GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, 0, -400), true));
					GoTween optiTween = new GoTween(OptionScreen, 0.1f, new GoTweenConfig().position (new Vector3( 0, 0, -400 ), true));
					GoTween instruTween = new GoTween(Instructions, 0.1f, new GoTweenConfig().position (new Vector3( 0, 0, -400 ), true));
					GoTween backTween = new GoTween(BackgroundPlane, 0.1f, new GoTweenConfig().position (new Vector3( 0, 0, -1600), true));
					chain = new GoTweenChain();

					chain.append(optiTween);
					chain.append(instruTween);
					chain.append(backTween);
					chain.append(rotTween);
					chain.play ();

				}

				ChangeMaterial();
			}
		}

		if (gameOn) // Game GUI code
		{
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
	}
	void ChangeMaterial()
	{
	
		currentMaterial = instructRotation[instructRotationIndex];
		Instructions.renderer.material = currentMaterial;

	}
//	void OnMouseOver()
//	{
//
//		//SelectObjectByMousePos();
//		mSelectedObject = this.gameObject.gameObject;
//		Debug.Log(mSelectedObject);
//	
//		
//	}
//	
//	
//	private void SelectObjectByMousePos()
//	{
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		
//		RaycastHit hit;
//		if (Physics.Raycast(ray, out hit, 10000F))
//		{
//			// get game object
//			GameObject rayCastedGO = hit.collider.gameObject;
//			Debug.Log("max");
//			// select object
//			this.SelectedObject = rayCastedGO;
//		}
//	}
//	
//	public GameObject SelectedObject
//	{
//		get
//		{
//			return mSelectedObject;
//		}
//		set
//		{
//			// get old game object
//			GameObject goOld = mSelectedObject;
//			
//			// assign new game object
//			mSelectedObject = value;
//			
//			// if this object is the same - just not process this
//			//if (goOld == mSelectedObject)
//			//{
//			//	return;
//			//}
//			
//			// set material to non-selected object
//			//if (goOld != null)
//			//{
//			//	goOld.renderer.material = BasicMat;
//			//}
//			
//			// set material to selected object
//			if (mSelectedObject != null)
//			{
//
//				
//				
//			}
//			
//			
//			
//			
//		}
//	}
	GameObject FindTarget(){
	foreach (GameObject go in gos) {
		TextScript Script1 = go.GetComponent<TextScript>();
		if (Script1.chosenOne == true) {
			mSelectedObject = go;
			return mSelectedObject;
		}
	}
		mSelectedObject = blankBG;
		return mSelectedObject;
	}

	
}
