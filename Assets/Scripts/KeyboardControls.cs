using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour 
{
	GameObject player;
	GameObject gamemanager;



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
			gamemanager.GetComponent<GUIControl>().onActionButtonClick(1);
		}
		if (Input.GetKeyUp (KeyCode.W)) 
		{
			gamemanager.GetComponent<GUIControl>().onActionButtonClick(2);
		}
		if (Input.GetKeyUp (KeyCode.E)) 
		{
			gamemanager.GetComponent<GUIControl>().onActionButtonClick(3);
		}
		if (Input.GetKeyUp (KeyCode.R)) 
		{
			gamemanager.GetComponent<GUIControl>().onActionButtonClick(4);
		}
		if (Input.GetKeyUp (KeyCode.Return)) 
		{
			//Summon Main Menu?
		}
	}
}
