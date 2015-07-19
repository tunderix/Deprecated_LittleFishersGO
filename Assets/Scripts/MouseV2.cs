using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseV2 : Photon.MonoBehaviour {

	//Variables
	RaycastHit hit;

	GameObject GameManager;
	private static Vector3 MouseDownPoint;
	private static GameObject rayCastedObject;
	
	void Awake()
	{
		//initialize
		MouseDownPoint = Vector3.zero;
	}
	
	void Start ()
	{
		GameManager = this.gameObject;
	}

	void Update () 
	{
		//Make UI CLICK to not go through!
		if (!EventSystem.current.IsPointerOverGameObject ()) 
		{
			//Shoot Raycasts to read material and colliders
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Debug.Log("RayCasting");
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) 
			{		//Raycasting

				//Store raycast CLICKS
				if(Input.GetMouseButtonDown (0))
				{
					MouseDownPoint = hit.point;
					rayCastedObject = hit.collider.gameObject;
				}
				if(Input.GetMouseButtonDown (1))
				{
					MouseDownPoint = hit.point;
					rayCastedObject = hit.collider.gameObject;
				}

				//Check what Object raycast HIT
				if(rayCastedObject != null)
				{
					if(Input.GetMouseButtonUp (0))
					{
						MouseClick(1, hit.collider.gameObject, hit.point);
					}
					if(Input.GetMouseButtonUp (1))
					{
						MouseClick(2, hit.collider.gameObject, hit.point);
					}
				}
				else
				{
					//NO RAYCAST?
					//NoRaycast();
				}

			}
			else 
			{
				//No RaycasT?
				//NoRaycast();
			}
		} 
		else 
		{
			//CURSOR OVER UI
			CursorOverUI();
		}
	}

	void MouseClick(int clickedBtn, GameObject clickedGO, Vector3 hitpoint)
	{
		if(clickedBtn == 1  && DidUserClickMouse (MouseDownPoint))
		{ //Left Button
			LeftClick(clickedGO);
		}
		else if(clickedBtn == 2  && DidUserClickMouse (MouseDownPoint))
		{ //Right Button
			RightClick(clickedGO, hitpoint);
		}
		else
		{
			//NO CLICK
		}
	}
	void LeftClick(GameObject clickedGO)
	{
		if(clickedGO != null)
		{
			switch (clickedGO.tag)
			{
			case "MyFisher":
				GameManager.GetComponent<ObjSelection>().SelectObject(clickedGO,1);
				break;
			case "Fisher":
				GameManager.GetComponent<ObjSelection>().SelectObject(clickedGO,2);
				break;
			case "Shop":
				GameManager.GetComponent<ObjSelection>().SelectObject(clickedGO,3);
				break;
			default:
				GameManager.GetComponent<ObjSelection>().DeselectGameobjectIfSelected();
				break;
			}
		}
		else
		{
			//ObjectNull, Clicked but didnt find GameObject with collider
			GameManager.GetComponent<ObjSelection>().DeselectGameobjectIfSelected();
		}
	}
	void RightClick(GameObject clickedGO, Vector3 hitpoint)
	{

		if (clickedGO != null) {
			//fishing status: 0=fishing not active, 1=hook in, 2=fishInHook, 3=fish caught?
			GameObject MyFisher = GameObject.FindGameObjectWithTag ("MyFisher");
			if (MyFisher != null) 
			{
				if(MyFisher.GetComponent<PlayerStatus>().fishingStatus > 0)
				{//Player IS fishing ---- Only toggleable with actionbutton1
					int fishingStatus = MyFisher.GetComponent<PlayerStatus> ().fishingStatus;
					
					//ClickState, 1=terrain, 2=water, 3=shop, 4=fishingMarker
					int clickedGOtype = getClickedObjectType(clickedGO);

					//Only water and fishing marker click handled in fishing. 
					if (clickedGOtype == 2) 
					{//water
						//Only used to start of fishing....

						if (fishingStatus == 1) 
						{//Player starting to fish
							//START FISHING
							GameManager.GetComponent<Fishing> ().startFishing (hitpoint, MyFisher);
						}
						else
						{ //player clicked water in other fishing status than start... 
							//Do nothing.
						}
					} 
					else if (clickedGOtype == 4) 
					{//Fishing marker

						if(clickedGO.GetComponent<FishOn>().isClickable)
						{ //When hook is clickable
							//FISH CAUGHT
							GameManager.GetComponent<Fishing> ().FishCaught (MyFisher, hitpoint);
						}
						else
						{//hook is NOT clickable

							if(!clickedGO.GetComponent<FishOn>().NotificationMade)
							{//Notification has NOT been made.... GO ON 
								Notificate("too SOON babe!");
								clickedGO.GetComponent<FishOn>().NotificationMade = true;
							}
							else
							{//notification disabled....
								
							}

							//INTERRUPT FISHING
							GameManager.GetComponent<Fishing> ().interruptFishing (MyFisher);
						}
					}
					else 
					{//Others
						//Do nothing.... only when clicked on water or marker...
					}
				}
				else
				{//Player NOT fishing

					//Only Movement....

					//ClickState, 1=terrain, 2=water, 3=shop, 4=fishingMarker
					int clickedGOtype = getClickedObjectType(clickedGO);

					if (clickedGOtype == 1) {//MainTerrain
						navigate (hitpoint); //Move
					} else {//Others
						navigateClosest (hitpoint);
					}

				}

				
			}
			else
			{
				//MyFisher not found?
				Debug.Log ("MyFisher not found, rightclick");
			}
		}
		else
		{
			//ObjectNull, Clicked but didnt find GameObject with collider
		}
	}

	int getClickedObjectType(GameObject clickedGO)
	{
		//ClickState, 1=terrain, 2=water, 3=shop, 4=fishingMarker
		int clickedGOtype = 0;

		//check and return number.
		switch (clickedGO.name) {
		case "MainTerrain":
			clickedGOtype = 1;
			break;
		case "Water":
			clickedGOtype = 2;
			break;
		case "Shop":
			clickedGOtype = 3;
			break;
		case "FishingMarker":
			clickedGOtype = 4;
			break;
		default:
			clickedGOtype = 0;
			break;
		}

		return clickedGOtype;
	}

	void navigate(Vector3 point)
	{
		GameObject.FindGameObjectWithTag ("MyFisher").GetComponent<NavigationMovement> ().NavigateTo (point);
	}
	void navigateClosest(Vector3 point)
	{
		GameObject.FindGameObjectWithTag ("MyFisher").GetComponent<NavigationMovement> ().navigateToClosestPoint(point);
	}
	#region Helper Functions

	void CursorOverUI()
	{
		//Do nothing?
	}
	void NoRaycast()
	{
		if (Input.GetMouseButtonUp (0) && DidUserClickMouse (MouseDownPoint)) 
		{
			//DeselectInventory ();
			//GameManager.GetComponent<ObjSelection>().DeselectGameobjectIfSelected ();
			
		}
	}

	public bool DidUserClickMouse(Vector3 hitPoint)
	{
		float clickZone = 1.3f;
		if
			(
				(MouseDownPoint.x < hitPoint.x + clickZone && MouseDownPoint.x > hitPoint.x - clickZone)&&
				(MouseDownPoint.y < hitPoint.y + clickZone && MouseDownPoint.y > hitPoint.y - clickZone)&&
				(MouseDownPoint.z < hitPoint.z + clickZone && MouseDownPoint.z > hitPoint.z - clickZone)
				)
				return true; else return false;
	}
	void Notificate(string note)
	{
		//FIND NOTIFICATION SCRIPT AND ACCESS METHOD NOTIFICATE
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIControl> ().Notificate (note);
	}

	#endregion


}