using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Camera mainCamera;
	public Camera GUICamera;

	private Camera[] cameras;
	private int currentCameraIndex = 0;
	public Camera currentCamera;

	// Use this for initialization
	void Start () {
	
		cameras = new Camera[] { mainCamera, GUICamera };//this is the array of cameras
		currentCamera = mainCamera; //When the program start the main camera is selected as the default camera
		ChangeView();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("ssjtsy"))
		{
			currentCameraIndex++;
			if (currentCameraIndex > cameras.Length-1)
			{currentCameraIndex = 0;}

			ChangeView();
		}
	
	}

	void ChangeView()
	{
		currentCamera.enabled = false;
		currentCamera = cameras[currentCameraIndex];
		currentCamera.enabled = true;
	}
}
