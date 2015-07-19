using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStatus : Photon.MonoBehaviour {

	public Rod fishingRod;
	public int money;
	public int level;
	public int strength;
	public int experience;
	public int fishingStatus; //fishing status: 0=fishing not active, 1=hook in, 2=HookInWater, 3=FishON
	public bool isMoving; 
	public bool shoppingEnabled;
	public string playerName;

	//PLAYER INVENTORY Variables
	public List<Item> inventory = new List<Item>();
	private itemDatabase database;

	// Use this for initialization
	void Start () 
	{
		//Init player variables. Playername comes from network manager...
		experience = 0;
		money = 20;
		EquipRod(0);
		level = 1;
		strength = 5;
		isMoving = false;
		shoppingEnabled = false;
		fishingStatus = 0;

		//Get database for items...
		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<itemDatabase> ();

		//Load inventory with blanko...
		for(int i = 0; i < 6; i++)
		{
			inventory.Add(new Item());
		}
		AddItem (1);
	}

	public void EquipRod(int id)
	{
		fishingRod = GameObject.FindGameObjectWithTag ("RodDatabase").GetComponent<RodDatabase> ().rods [id];
	}
	public void GivePlayerExperience(int pst,int fst,int fishsize)
	{
		//set player exp
		calculateAndSetExperience (pst,fst,fishsize);

		//Check if player exp reached level marker //set player level
		level = calculatePlayerLevel();

		//notify on level up and update GUI
		notificate ("LevelUP, Your level is now " + level);
		GameObject.Find("playerLevel").GetComponent<Text> ().text = "Level: " + level;
	}
	void calculateAndSetExperience(int pst,int fst,int fishsize)
	{
		//Calculate experienceGain
		if(pst-fst > 0)
		{
			experience = experience + (pst-fst) + fishsize*2;
		}
		else
		{
			experience = experience + fishsize*2;
		}

		//update GUI


	}
	private int calculatePlayerLevel()
	{
		int[] levelMarks = new int[20];
		int tempExpSumOfLevels = 0;
		int tempLevel = 0 ;

		int levelGap = 50;
		//Generate level marks
		for (int i=0; i<20; i++) 
		{
			levelMarks[i] = levelGap+(i*20);
			tempExpSumOfLevels = tempExpSumOfLevels + levelMarks[i];

			if(experience<tempExpSumOfLevels)
			{
				tempLevel = i+1;
				break;
			}
		}

		//Check if level up

		return tempLevel;
	}

	public void RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemID == id)
			{
				inventory[i] = null;
				break;
			}
		}
	}
	public void AddItem(int id)
	{

		for (int i = 0; i < inventory.Count; i++) 
		{
			if (inventory [i].itemName == null) 
			{
				for (int j = 0; j < database.items.Count; j++) 
				{
					if (database.items [j].itemID == id) 
					{
						inventory [i] = database.items [j];
					}
				}
			
				break;
			}
		}
		
	}


	bool InventoryContains(int id)
	{
		bool result = false;
		for (int i = 0; i < inventory.Count; i++) 
		{
			result = inventory[i].itemID == id;
			if(result)
			{
				break;
			}
		}
		return result;
	}

	public List<Item> InventoryContents()
	{
		return inventory;
	}



	void notificate(string note)
	{
		//FIND NOTIFICATION SCRIPT AND ACCESS METHOD NOTIFICATE
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<GUIControl> ().Notificate (note);
	}
	public void TakeMoney(int amount)
	{
		money = money - amount;
	}
	public void GiveMoney(int amount)
	{
		money = money + amount;
	}
}
