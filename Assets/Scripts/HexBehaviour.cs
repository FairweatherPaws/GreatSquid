using UnityEngine;
using System.Collections;

public class HexBehaviour : MonoBehaviour {

	public GameObject parentisation;
	public Material BasicMat;
	public Material HighlightedMat;
	public bool forestsizing = false;
	public bool grasssizing = false;
	private float timeout = 2;

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

		timeout -= Time.deltaTime;
		if (timeout < 1) {this.renderer.material = BasicMat;}

		// process object selection

	}
	void OnMouseOver()
	{
		SelectObjectByMousePos();
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
		
		// set material to selected object
		if (mSelectedObject != null)
		{
			mSelectedObject.renderer.material = HighlightedMat;
				timeout = 1.1f;
			}

	}
}


}
