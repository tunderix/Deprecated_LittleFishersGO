using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float zoomSpeed = 1f;

	void Update(){
		
		// zoom out
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			if (transform.position.y > -30) 
			{
				Vector3 move = transform.position.y * zoomSpeed * transform.forward;
				transform.Translate (move, Space.World);
			}
		}
		// zoom in
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			if (transform.position.y < 30) 
			{
				Vector3 move = transform.position.y * zoomSpeed * -transform.forward;
				transform.Translate (move, Space.World);			
			}
		}
	}
}