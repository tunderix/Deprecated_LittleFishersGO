using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{

	public float speed = 10.0f;  
	public Vector3 movement = Vector3.zero;
	float maxScreenWidth =  Screen.width - 5; 
	float maxScreenHeight = Screen.height - 5;

	public int cameraActivationBorders = 5;

	public bool SetCameraOnStandBy = false; 

	public float numberOfPixlesToMove = 1;

	void Start()
	{
		//this.transform.position.y = 60;
	}

	void LateUpdate () {
		if (SetCameraOnStandBy == false) {
			if (Input.mousePosition.x <= cameraActivationBorders) 
			{ //moves screen to the left
				movement.x = movement.x - numberOfPixlesToMove;
			} 
			else if (Input.mousePosition.x >= maxScreenWidth - cameraActivationBorders) 
			{ // moves screen to the right
				movement.x = movement.x + numberOfPixlesToMove;
			} 
			else if (Input.mousePosition.y <= cameraActivationBorders) 
			{// moves screen up
				movement.z = movement.z - numberOfPixlesToMove;
			} 
			else if (Input.mousePosition.y >= maxScreenHeight - cameraActivationBorders) 
			{// moves screen down
				movement.z = movement.z + numberOfPixlesToMove;
			} 
			else 
			{
				movement.x = 0;
				movement.z = 0;
			}
		}


		if (Input.GetKeyUp(KeyCode.Space)) 
		{
			if (SetCameraOnStandBy == true) 
			{
				SetCameraOnStandBy = false;

			}
			else
			{
				SetCameraOnStandBy = true;

			}
			Debug.Log ("Camera toggled" + SetCameraOnStandBy);

		}
		
		
		transform.Translate (movement * speed * Time.deltaTime, Space.Self);
		

	}
	public void setCamPosition(Vector3 rPosition)
	{
		transform.position = rPosition;
	}
}
