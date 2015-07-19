using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishingArea : MonoBehaviour {


	public List<FishPool> pools = new List<FishPool>();

	public string getFishSizeFromFishingArea(){
		return pickFishSizeInPool ();
	}
	string pickFishSizeInPool(){
		/*List<int> tinyFishesRatio = new List<int>();
		List<int> smallFishesRatio = new List<int>();
		List<int> mediumFishesRatio = new List<int>();
		List<int> largeFishesRatio = new List<int>();
		List<int> hugeFishesRatio = new List<int>();*/
		List<string> sizePool = new List<string>();

		//fill Lists with 
		//Loop through poolElements
		foreach (FishPool pool in pools) {
			//loop amount = amount of fishes in pool
			for(int i = 0; i>pool.ratioOfFishes;i++){
				//add to sizepool: tiny,tiny,tiny,medium,medium
				sizePool.Add(pool.fishesInPool.ToString());
				Debug.Log("\nFishPool: " + pool.fishesInPool.ToString());
			}

			/*if (pool.fishesInPool.ToString() == "Tiny"){
				tinyFishesRatio.Add(pool.ratioOfFishes);
			}
			else if (pool.fishesInPool.ToString() =="Small"){
				smallFishesRatio.Add(pool.ratioOfFishes);
			}
			else if (pool.fishesInPool.ToString() == "Medium"){
				mediumFishesRatio.Add(pool.ratioOfFishes);
			}
			else if (pool.fishesInPool.ToString() == "Large"){
				largeFishesRatio.Add(pool.ratioOfFishes);
			}
			else if (pool.fishesInPool.ToString() == "Huge"){
				hugeFishesRatio.Add(pool.ratioOfFishes);
			}*/
		}

		//determine, which size is the FishSize.
		return sizePool [Random.Range (0, sizePool.Count)];


	}

	/*
	//Old idea for Fishing Areas!
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
	}
	*/
}
