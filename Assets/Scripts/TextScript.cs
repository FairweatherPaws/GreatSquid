using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {

	private float timeout = 5;

	public Material BasicMat;
	public Material HighlightedMat;
	public bool chosenOne = false;

	private GameObject mSelectedObject;

	// Use this for initialization
	void Start () {

	//	this.renderer.material = HighlightedMat;
	
	}
	
	// Update is called once per frame
	void Update () {

	//	timeout -= Time.deltaTime;
	//	if (timeout < 1) {this.renderer.material = BasicMat;}
	
	}

	void OnMouseOver()
	{
		chosenOne = true;
		//SelectObjectByMousePos();
		this.renderer.material = HighlightedMat;


//		timeout = 1.1f;
	}

	void OnMouseExit()
	{
		this.renderer.material = BasicMat;
		chosenOne = false;

	}
	
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
//				mSelectedObject.renderer.material = HighlightedMat;
//				timeout = 1.1f;
//
//
//			}
//
//			
//			
//			
//		}
//	}
//
}
