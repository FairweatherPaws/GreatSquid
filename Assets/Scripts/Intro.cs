using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public Transform IntroScreen, UpperLeftHud, Instructions;
	private GoTweenChain chain;
	public Material Instruct01, Instruct02, Instruct03, Instruct04;
	private Material[] instructRotation;
	private int instructRotationIndex;
	private Material currentMaterial;

	// Use this for initialization
	void Start () {
	
		instructRotation = new Material[] { Instruct01, Instruct02, Instruct03, Instruct04 };
		currentMaterial = Instruct01;
		
	}
	
	// Update is called once per frame
	void Update () {
	
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

		if(Input.GetKeyDown("i")) // open instructions
		{

			instructRotationIndex = 0;

			GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, 0 )).eulerAngles(new Vector3(0, 180, 0)));
			chain = new GoTweenChain();
			chain.append(instruTween);
			chain.play();

			GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, -135 )).eulerAngles(new Vector3(117, 0, 0)));
			chain = new GoTweenChain();
			chain.append(rotTween);
			chain.play();

			ChangeMaterial();

		}

		if(Input.GetKeyDown("l")) // next page in instructions
		{
			instructRotationIndex++;
			if (instructRotationIndex > instructRotation.Length-1)
			{
				instructRotationIndex--;
				GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, -400 )));
				chain = new GoTweenChain();
				chain.append(instruTween);
				chain.play();

				GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(0, 0, 0)));
				chain = new GoTweenChain();
				chain.append(rotTween);
				chain.play();

			}
			
			ChangeMaterial();
		}

		if(Input.GetKeyDown("k")) // previous page in instructions
		{
			instructRotationIndex--;
			if (instructRotationIndex < 0)
			{
				instructRotationIndex = 0;
				GoTween instruTween = new GoTween(Instructions, 3f, new GoTweenConfig().position (new Vector3( 0, -800, -400 )));
				chain = new GoTweenChain();
				chain.append(instruTween);
				chain.play();

				GoTween rotTween = new GoTween(IntroScreen, 3f, new GoTweenConfig().position (new Vector3( 0, -700, 0 )).eulerAngles(new Vector3(0, 0, 0)));
				chain = new GoTweenChain();
				chain.append(rotTween);
				chain.play();
			}
			
			ChangeMaterial();

		}
	}
	void ChangeMaterial()
	{
	
		currentMaterial = instructRotation[instructRotationIndex];
		Instructions.renderer.material = currentMaterial;

	}
}
