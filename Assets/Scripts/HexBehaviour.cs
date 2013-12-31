using UnityEngine;
using System.Collections;

public class HexBehaviour : MonoBehaviour {

	public GameObject parentisation;
	public Material BasicMat;
	public Material HighlightedMat;
	public Material VisibleMat;
	public bool forestsizing = false;
	public bool grasssizing = false;
	public bool clickReset = true;
	private float timeout = 1;
	private float reDyeTime = 6;
	public bool gameOn = false;

	// selected GameObject http://denis-potapenko.blogspot.fi/2013/03/task-3-object-selection-and-highlight.html
	private GameObject mSelectedObject;






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

		if (Input.GetMouseButtonDown(0) && gameOn == false)
		{
			
			GameObject Object2 = GameObject.FindGameObjectWithTag("GUIController"); //Access GUI-script through this.
			GUIScript Script2 = Object2.GetComponent<GUIScript>();
			gameOn = Script2.gameOn;
			
		}

		if (gameOn){
			if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
			{
				reDyeTime = 0; 
				this.renderer.material = BasicMat;
			}
			reDyeTime += Time.deltaTime;
			timeout -= Time.deltaTime;
			GameObject Object2 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
			HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();
			
			float distance = Vector3.Distance(Script2.transform.position, this.transform.position);
			
			float disUnits = Mathf.CeilToInt(distance/1.75f);
			
			float cap = Script2.speedLimit;
			if (timeout < 1)
			{
				if (cap < disUnits) 
				{
					this.renderer.material = BasicMat;
				}	
				if (cap >= disUnits && reDyeTime > 5 && this.renderer.material != HighlightedMat) 
				{
					this.renderer.material = VisibleMat;
				}
				if (cap >= disUnits && reDyeTime <= 5) 
				{
					this.renderer.material = BasicMat;
				}
			}
			if (Input.GetMouseButtonDown(0) && gameOn == true) {clickReset = true; reDyeTime = 0;}
		
		// process object selection
		}

	}
	void OnMouseOver()
	{
		if (gameOn){
			SelectObjectByMousePos();
		}
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
		
		// if this object is the same - just not process this
		//if (goOld == mSelectedObject)
		//{
		//	return;
		//}
		
		// set material to non-selected object
		//if (goOld != null)
		//{
		//	goOld.renderer.material = BasicMat;
		//}
			GameObject Object2 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
			HeroBehaviour Script2 = Object2.GetComponent<HeroBehaviour>();


			float distance = Vector3.Distance(Script2.transform.position, mSelectedObject.transform.position);

			float disUnits = Mathf.CeilToInt(distance/1.75f);

			float cap = Script2.speedLimit;


		// set material to selected object
			if (mSelectedObject != null && cap >= disUnits && reDyeTime > 5)
			{
				mSelectedObject.renderer.material = HighlightedMat;
				timeout = 1.1f;
			}

			
			
		}
}


}
