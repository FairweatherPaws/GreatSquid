using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public Material normalTex, HLTex;
	public GameObject menuHelp;
	public bool chosenOne = false;


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver(){
	
		this.renderer.material = HLTex;
		TextMesh tm = menuHelp.GetComponent<TextMesh>();
		tm.text = "click for menu";
	
	}

	void OnMouseExit(){
	
		this.renderer.material = normalTex;
		TextMesh tm = menuHelp.GetComponent<TextMesh>();
		tm.text = "";

	}
}
