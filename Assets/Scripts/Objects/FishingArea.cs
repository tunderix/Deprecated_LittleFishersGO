using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishingAreas : MonoBehaviour 
{

	public List<FishPool> fishPools = new List<FishPool> ();

	//Old idea for Fishing Areas!
	/*
	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.name.ToString() == "FishingMarker") 
		{
			Debug.Log("collision: fishingarea-hook" + col.gameObject.name.ToString());

			//SPLIT fishing areaNAME and pick the last number of it.. 
			string[] objectNameSplit = this.gameObject.name.ToString().Split('_');

			//Send this number to hook to tell which fishing area to set for FishingRewards
			col.gameObject.GetComponent<FishOn>().setFishingAreas(int.Parse(objectNameSplit[1]));

		} 
		else 
		{

		}
	}*/
}
