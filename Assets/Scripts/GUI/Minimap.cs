using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Minimap : MonoBehaviour {

	public GameObject Cam;
	public Image MinimapImage;
	public float minimapWidth, minimapHeight;
	public float PosX, PosY;

	// Use this for initialization
	void Start () {
		PosX = MinimapImage.rectTransform.anchoredPosition.x;
		PosY = MinimapImage.rectTransform.anchoredPosition.y;
		minimapHeight = 100f;
		minimapWidth = 100f;

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void lookAt()
	{

		//Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Input.mousePosition.z);

		//SET CAMERA AT PLAYER
		Cam.transform.position = GameObject.FindGameObjectWithTag("MyFisher").transform.position;
		
		//Debug.Log("Mouse click: " + MousePos.x - 10.0f + "," + MousePos.y - 10.0f);
		
	
		

	}
}
