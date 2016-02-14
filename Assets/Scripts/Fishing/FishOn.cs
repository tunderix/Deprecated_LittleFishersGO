using UnityEngine;
using System.Collections;

public class FishOn : Photon.MonoBehaviour 
{
	public bool isClickable = false;
	public bool isInstantiated = false;
	public bool NotificationMade = false;

	public bool fishingArea1 = false; //tiny
	public bool fishingArea2 = false;//small
	public bool fishingArea3 = false;//medium
	public bool fishingArea4 = false;//large
	public bool fishingArea5 = false;//huge

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	public void isReady()
	{
		//Isready happens when collision with different areas 

		//Randomize the length of hooks idletime..
		anim.SetInteger ("IdleLaps", Random.Range(4,10));

		//SET Animation permit to go to idle.
		anim.SetBool ("Idle",true);

		//save variable for knowing this hook has been instantiated..
		isInstantiated = true;
	}
	public void IdleLapDecrease()
	{
		//Check if FishIsAlready in hook...
		if (anim.GetBool ("fishInHook") == false) 
		{ //NOT IN HOOK
			//Next check if IdleLaps has gone to zero or less
			if (anim.GetInteger ("IdleLaps") < 1) 
			{
				//if hook has already sunk before, dont do sinking again...
				if(anim.GetBool ("HookHasReacted") == false)
				{
					//Tell animator that Fish is in hook.... SINK THE HOOK... 
					anim.SetBool ("fishInHook",true);
				}
				else
				{

				}
			} 
			else 
			{
				//If there is idlelaps, Decrease IdleLaps of animation.. 
				anim.SetInteger ("IdleLaps",anim.GetInteger ("IdleLaps")-1);
			}
		} 
		else 
		{ //FISH IN HOOK....
			//Do nothing.... The animation makes it done... 
		}
	}
	public void FishInHook()
	{
		// set hook clickable.... 
		isClickable = true;

		//Tell animation not print hook sink again...
		anim.SetBool ("HookHasReacted",true);

		//tell animator to go for Destroying the marker... 
		setHookToVanish ();

		//set players fishing status :3 --> waiting for player to response...
		GameObject.FindGameObjectWithTag ("MyFisher").GetComponent<PlayerStatus> ().fishingStatus = 3;
	}
	public void setHookToVanish()
	{
		//tell animator to go for Destroying the marker... 
		anim.SetBool ("readyToDestroy",true);
	}


	public void destroyHook()
	{
		Destroy(this.gameObject.transform.parent.gameObject);

		Debug.Log("HookDestroyed.");
	}
	public void setFishingAreas(int area)
	{
		switch (area)
		{
		case 1:
			fishingArea1 = true;
			break;
		case 2:
			fishingArea2 = true;
			break;
		case 3:
			fishingArea3 = true;
			break;
		case 4:
			fishingArea4 = true;
			break;
		case 5:
			fishingArea5 = true;
			break;
		default:
			//CantGetFish in here... NO FISHING AREA
			break;
		}
	}
}
