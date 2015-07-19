using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	void readyToFish()
	{
		if (gameObject.GetComponent<PlayerStatus> ().fishingStatus > 0) {//PLAYER FISHING
			//Stop Fishing
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<Fishing> ().stopFishing (gameObject);
		} else {//PLAYER IS NOT FISHING
			//Stop Movement of player
			gameObject.GetComponent<NavigationMovement> ().stayStill ();
			
			// Set Fishing range ON
			setFishingRangeActive ();
			
			//Set fisherstatus to startstatus...
			gameObject.GetComponent<PlayerStatus> ().fishingStatus = 1;
		}
	}

	public bool fishingRangeActive()
	{
		GameObject MyFisher = GameObject.FindGameObjectWithTag ("MyFisher");
		// Set player range indicator ON
		GameObject MyFisherRange =  MyFisher.transform.FindChild ("fishingRange").gameObject;
		if (MyFisherRange.GetActive ()) 
		{
			return true;
		} 
		else 
		{
			return false;
		}
	}
	public void setFishingRangeActive()
	{
		GameObject MyFisher = GameObject.FindGameObjectWithTag ("MyFisher");
		// Set player range indicator ON
		GameObject MyFisherRange =  MyFisher.transform.FindChild ("fishingRange").gameObject;
		MyFisherRange.SetActive (true);
	}
	public void setFishingRangeDeactiveIfActive()
	{
		GameObject MyFisher = GameObject.FindGameObjectWithTag ("MyFisher");
		// Set player range indicator ON
		GameObject MyFisherRange =  MyFisher.transform.FindChild ("fishingRange").gameObject;
		if (MyFisherRange.GetActive()) 
		{
			MyFisherRange.SetActive (false);
		} 
		else 
		{
			//Debug.Log("Tried to make range deactive. Was already Deactive?");
		}
		
	}
}
