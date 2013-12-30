using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public Transform IntroScreen;
	private GoTweenChain chain;

	// Use this for initialization
	void Start () {
	

		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("a"))
		{

			GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, -135 )).eulerAngles(new Vector3(117, 0, 0)));
			chain = new GoTweenChain();
			chain.append(rotTween);
			chain.play();
			
		}

	}
}
