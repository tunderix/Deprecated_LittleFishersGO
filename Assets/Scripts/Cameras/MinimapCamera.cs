using UnityEngine;
using System.Collections;

public class MinimapCamera : MonoBehaviour {

	public RenderTexture MiniMapTexture;
	public Material MiniMapMaterial;

	public Transform cam;
	public Terrain mmTerrain;

	void OnGUI()
	{
		//if(Event.current.type == EventType.Repaint)
			//Graphics.DrawTexture(new Rect( 10, Screen.height-110, 100, 100), MiniMapTexture, MiniMapMaterial);
		
	}
	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			Vector3 MousePos = new Vector3(Input.mousePosition.x-10f, Input.mousePosition.y-10f,Input.mousePosition.z-10f );

			if (0 < MousePos.x && MousePos.x < 100) 
			{
				if (0 < MousePos.y && MousePos.y < 100) 
				{
					Vector3 positionToLook = new Vector3(3f*MousePos.x,cam.position.y, 3f*MousePos.y); 

					cam.position = positionToLook;

					//Debug.Log("Mouse click: " + MousePos.x - 10.0f + "," + MousePos.y - 10.0f);
						
				}
			}
		}
	}
}
