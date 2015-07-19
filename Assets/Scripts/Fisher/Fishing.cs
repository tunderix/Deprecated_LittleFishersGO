using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fishing : MonoBehaviour {


	GameObject fishdb;
	GameObject manager;
	public GameObject HookPrefab;

	// Use this for initialization
	void Start () 
	{
		//initialize Gameobjects

		fishdb = GameObject.FindGameObjectWithTag ("FishDatabase");
		manager = GameObject.FindGameObjectWithTag ("GameManager");
	}


	//FISHING STARTING
	public void startFishing(Vector3 targetPosition, GameObject player)
	{
		//First check the range
		float range = player.GetComponent<PlayerStatus> ().fishingRod.rodRange;
		if (Vector3.Distance (player.transform.position, targetPosition) < range) 
		{
			//Set fishing status to 2
			GameObject.FindGameObjectWithTag ("MyFisher").GetComponent<PlayerStatus> ().fishingStatus = 2;

			//summon hook
			summonHook(targetPosition);

		} 
		else 
		{
			makeNotification("Range not enough");
			interruptFishing(player);
		}
	}

	public void FishCaught(GameObject player, Vector3 position)
	{
		//INITIALIZE


		//SET PLAYERs fishing status to reward
		player.GetComponent<PlayerStatus>().fishingStatus = 4;

		//which areas were under hook? 
		int fishSize = fishAreas();

		//Select Fish
		Fish selectedFish = fishSelection (fishSize);

		//Combat PLAYER VS FISH
		bool combatWin = combat (player, selectedFish);

		//REWARD
		if (combatWin) 
		{
			//Randomize if loot is fish or other item.

			//Notify Player on Fish
			makeNotification("You got REWARD_NAME" );

			//Player won agains fish. Reward XP and Fish;
			//reward (player,10,selectedFish);
		} 
		else 
		{
			//Notify Player on Fish
			makeNotification("Fish was too strong" );

			//player Lost against fish... Reward only XP
			//reward (player,0);
		}

		//Do the reset things...
		//Destroy fishingmarker and make it unclickable
		interruptFishing(player);

	}

	void reward(GameObject player,int xp)
	{
		//Set Fish to inventory
		//GameObject.FindGameObjectWithTag("MyFisher").GetComponent<PlayerStatus>().AddItem(1);
		
		//Update GUI inventory.
		//GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIControl>().drawInventory();
		
		//Give player Experience
		//player.GetComponent<PlayerStatus>().GivePlayerExperience(pst,fst,fishsize);
	}

	Fish fishSelection(int fSize)
	{
		//init
		////setup fSize so it can be read on pool compare



		//Get all the fishes in fishdb
		#region fishdb
		fishdb = GameObject.FindGameObjectWithTag ("FishDatabase");

		//Create a pool of fishes matching the fishsize
		List<Fish> fishPool = new List<Fish>();
		foreach(Fish fish in fishdb.GetComponent<fishDatabase>().fishes) 
		{
			if(fish.fishSize == Fish.FishSize.Small) ///korjaaa tää
			{
				fishPool.Add(fish);
			}
		}
		#endregion

		int randomID = Random.Range (0, fishPool.Count);

		return fishPool[randomID];
	}
	int fishAreas()
	{
		//return FishSize
		int fishsize = Random.Range (0, 4);
		return fishsize;
	}
	bool combat(GameObject player, Fish fish)
	{
		//initialize Attributes 
		Rod rod = player.GetComponent<PlayerStatus>().fishingRod;
		int level = player.GetComponent<PlayerStatus>().level;
		int str = player.GetComponent<PlayerStatus> ().strength;

		int pst = CalculatePST (str, level, rod.rodStrengthModifier);
		int fst = CalculateFST(1); //korjaa täääki
		
		//Check if FishStrength or PlayerStrength is greater
		if (pst > fst)
		{
			return true;
			
		} 
		else
		{
			return false;
		}
	}


	public void interruptFishing(GameObject fisher)
	{
		//destroy all Fishing objects player owns.
		GameObject fishingMarker;
		fishingMarker = GameObject.FindGameObjectWithTag ("FishingMarker");
		//Set Fishing marker to go for Destroy animation.
		fishingMarker.GetComponentInChildren<FishOn>().isClickable = false;
		fishingMarker.GetComponentInChildren<FishOn>().setHookToVanish ();

		//RESET players fishing statuses.
		fisher.GetComponent<PlayerStatus> ().fishingStatus = 1;
	}
	public void stopFishing(GameObject fisher)
	{
		//destroy Fishing marker
		GameObject fishingMarker;
		fishingMarker = GameObject.FindGameObjectWithTag ("FishingMarker");
		//Set Fishing marker to go for Destroy animation. 
		fishingMarker.GetComponentInChildren<FishOn>().isClickable = false;
		fishingMarker.GetComponentInChildren<FishOn>().setHookToVanish ();

		//RESET players fishing statuses. 
		fisher.GetComponent<PlayerStatus> ().fishingStatus = 0;

		//Deactivate Fishing Range
		fisher.GetComponent<PlayerActions> ().setFishingRangeDeactiveIfActive ();
	}
	string fishSizeConverter(int i)
	{
		string fsize = "";
		
		switch(i)
		{
		case 0:
			fsize = "Tiny";
			break;
		case 1:
			fsize = "Small";
			break;
		case 2:
			fsize = "Medium";
			break;
		case 3:
			fsize = "Large";
			break;
		case 4:
			fsize = "Huge";
			break;
		}
		return fsize;
	}

	public int CalculateFST(int size)
	{
		//IDENTIFY FISH
		Fish fish = fishdb.GetComponent<fishDatabase> ().fishes [size];

		if (fish.fishSize == Fish.FishSize.Tiny) 
		{
			return Random.Range (2, 8);
		}
		else if (fish.fishSize == Fish.FishSize.Small) 
		{
			return Random.Range (5, 12);
		}
		if (fish.fishSize == Fish.FishSize.Medium) 
		{
			return Random.Range (8, 16);
		}
		else if (fish.fishSize == Fish.FishSize.Large) 
		{
			return Random.Range (11, 20);
		}
		if (fish.fishSize == Fish.FishSize.Huge) 
		{
			return Random.Range (14, 30);
		}
		else 
		{
			return 0;
		}
		
	}

	public int CalculatePST(int pstr, int plevel,int rodstr)
	{
		return pstr + plevel + rodstr;
	}

	void summonHook(Vector3 position)
	{
		//manager.transform.GetComponent<NetworkManager> ().SpawnFishingHook (position);
		Instantiate (HookPrefab , position, Quaternion.identity);
	}

	void FishOn()
	{

	}

	void makeNotification(string note)
	{
		//FIND NOTIFICATION SCRIPT AND ACCESS METHOD NOTIFICATE
		manager.transform.GetComponent<GUIControl> ().Notificate (note);
	}
}
