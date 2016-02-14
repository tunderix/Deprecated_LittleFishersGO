using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour 
{
	GameObject player;
	GameObject gamemanager;

	public GameObject cameraObject;


	void Start ()
	{
		gamemanager = GameObject.FindGameObjectWithTag ("GameManager");

	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.H)) 
		{
			//STOP PLAYER MOVEMENT
			GameObject.FindGameObjectWithTag("MyFisher").GetComponent<NavigationMovement>().stayStill();
		}
		if (Input.GetKeyUp (KeyCode.Q)) 
		{
			gamemanager.GetComponent<ActionController>().onActionButtonClick(ActionController.ActionButton.ab1);
		}
		if (Input.GetKeyUp (KeyCode.W)) 
		{
			gamemanager.GetComponent<ActionController>().onActionButtonClick(ActionController.ActionButton.ab2);
		}
		if (Input.GetKeyUp (KeyCode.E)) 
		{
			gamemanager.GetComponent<ActionController>().onActionButtonClick(ActionController.ActionButton.ab3);
		}
		if (Input.GetKeyUp (KeyCode.R)) 
		{
			gamemanager.GetComponent<ActionController>().onActionButtonClick(ActionController.ActionButton.ab4);
		}
		if (Input.GetKeyUp (KeyCode.Return)) 
		{
			//Summon Main Menu?
		}
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			cameraObject.GetComponent<CameraMovement> ().toggleCameraMovement ();
		}
	}
}
