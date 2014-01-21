using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public Material normalTex, HLTex;
	public GameObject menuHelp;
	public bool chosenOne = false;
	private string movesLeftSTR;
	private float countdown = 0;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)){

			countdown = 1;


		}
		if (countdown > 0){
			
			GameObject Object1 = GameObject.FindGameObjectWithTag("Player"); //Access HeroBehaviour-script through this.
			HeroBehaviour Script2 = Object1.GetComponent<HeroBehaviour>();
			movesLeftSTR = Script2.movesLeftSTR;

			
			if (movesLeftSTR == "0"){
				
				TextMesh tm = menuHelp.GetComponent<TextMesh>();
				tm.text = "                                   press space to end turn";
				
			}
			else 
			{
				TextMesh tm = menuHelp.GetComponent<TextMesh>();
				tm.text = "";
			}
			countdown -= Time.deltaTime;
		}
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
