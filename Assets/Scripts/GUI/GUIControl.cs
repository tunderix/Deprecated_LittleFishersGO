using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GUIControl : Photon.MonoBehaviour {


	public GUISkin skin;

	public GameObject noti;
	GameObject Notif;
	public GameObject Canvas;
	public GameObject lblPlayerLevel;
	public GameObject lblPlayerStrength;
	public GameObject manager;
	public GameObject inventory;
	private string tooltip;
	private bool showInventory;
	
	void Start ()
	{
		showInventory = false;
		//ClearInventoryContentsOnGUI ();
	}

	#region GUI INPUT
	public void onActionButtonClick(int btnNumber)
	{
		//Initialize
		GameObject MyFisher = GameObject.FindGameObjectWithTag ("MyFisher");
		
		//ActionButtons.
		if (btnNumber == 1) 
		{
			if(MyFisher.GetComponent<PlayerStatus>().fishingStatus > 0)
			{//PLAYER FISHING
				//Stop Fishing
				manager.GetComponent<Fishing>().stopFishing(MyFisher);
			}
			else
			{//PLAYER IS NOT FISHING
				//Stop Movement of player
				MyFisher.GetComponent<NavigationMovement>().stayStill();
				
				// Set Fishing range ON
				setFishingRangeActive();
				
				//Set fisherstatus to startstatus...
				MyFisher.GetComponent<PlayerStatus> ().fishingStatus = 1;
			}	
		}
		else if (btnNumber == 2) 
		{
			MyFisher.GetComponent<PlayerStatus> ().AddItem(1);
		}
		else if (btnNumber == 3) 
		{
			updateGUI();
		}
		else if (btnNumber == 4) 
		{
		}
	}
	#endregion

	#region GUI UPDATE
	public void updateGUI()
	{//Update all contents of gui...

		//INIT

		//Update TopPanel
		updateTopPanel ();

		//Update LeftPanel


		//Update RightPanel


		//Update BottomPanel
		updateBottomPanel ();

	}
	void updateTopPanel ()
	{
		//Update RoomName
		updateRoomName ();

	}
	void updateRoomName ()
	{
		//Store path for UI Object
		string str = "/InGameGUI/TopPanel/txtRoomName";
		
		//Get Gameobject roomname..
		GameObject UI_txtRoom = GameObject.Find(str);
		
		//Store Value
		string roomname = PhotonNetwork.room.name;
		
		//Do the update!
		UI_txtRoom.GetComponent<Text> ().text = roomname;
	}
	void updateBottomPanel ()
	{
		//init
		//Get My Fisher
		GameObject MyFisher = GameObject.FindGameObjectWithTag("MyFisher");
		//Get current selection
		GameObject SelectedObject = manager.GetComponent<ObjSelection> ().currentlySelectedUnit;

		//Minimap
		//No need...?

		//ActionButtonPanel?
		//Need?

		//update Resources
		updateResources (MyFisher);
		
		//update PlayerXP
		updatePlayerXP (MyFisher);

		if (SelectedObject.name.Contains ("Fisher")) 
		{
			//update Inventory
			updateInventory (SelectedObject);
		
			//update FisherStatuses
			updateFisherStatus (SelectedObject);
		}
	}
	void updateInventory (GameObject Player)
	{
		//Get fishers inventory contents
		List<Item> inventoryContents = Player.GetComponent<PlayerStatus> ().InventoryContents ();

		//Draw players inventorycontents. 
		//for each inventorycontent
		for (int i = 0; i < inventoryContents.Count; i++) 
		{
			////create path for UI object....
			string str = "/InGameGUI/BotPanel/InventoryPanel/icon" + (i+1).ToString ();
			//Object from GUI
			GameObject icon = GameObject.Find(str);

			//Debug.Log("Icons from GUI found...");

			if (inventoryContents [i].itemName != null) 
			{// Found item on this slot, Set inventoryIcon to be of right ITEM...
				//Debug.Log("Icon:" + icon.GetComponent<Image> ().sprite);
				icon.GetComponent<Image> ().sprite = inventoryContents[i].itemIcon;
				
			}
			else
			{ //InventorySlot Has no item.
				//Set Blanko as image
				icon.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Item Icons/Blanko");
			}
		}

	}
	void updateFisherStatus (GameObject Player)
	{
		//Store path for UI Object
		string str1 = "/InGameGUI/BotPanel/FisherStatus/Player_Name";
		string str2 = "/InGameGUI/BotPanel/FisherStatus/Player_str";
		string str3 = "/InGameGUI/BotPanel/FisherStatus/Player_lvl";

		//Get corresponding InventoryIcon from GUI
		GameObject UI_txtName = GameObject.Find(str1);
		GameObject UI_txtStr = GameObject.Find(str2);
		GameObject UI_txtLvl = GameObject.Find(str3);

		//Store Value
		string name = Player.GetComponent<PlayerStatus>().playerName;
		string strength = Player.GetComponent<PlayerStatus>().strength.ToString();
		string level = Player.GetComponent<PlayerStatus>().level.ToString();

		//Do the update!
		UI_txtName.GetComponent<Text> ().text = name;
		UI_txtStr.GetComponent<Text> ().text = strength;
		UI_txtLvl.GetComponent<Text> ().text = level;


	}
	void updateResources (GameObject Fisher)
	{
		//Store path for UI Object
		string str1 = "/InGameGUI/BotPanel/Resources/gold_txt";
		
		//Get corresponding InventoryIcon from GUI
		GameObject UI_txtGold = GameObject.Find(str1);

		//Store Value of MY MONEY
		string amount = Fisher.GetComponent<PlayerStatus>().money.ToString();
		
		//Do the update!
		UI_txtGold.GetComponent<Text> ().text = amount;
		
	}
	void updatePlayerXP (GameObject MyFisher)
	{
		
	}
	#endregion
	GameObject getMe()
	{
		GameObject MyFisher = GameObject.FindGameObjectWithTag ("MyFisher");
		return MyFisher;
	}
	string createToolTip(Item item)
	{
		tooltip = "" + item.itemName + "\n\n" + item.itemDesc;
		return tooltip;
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

	public void sellItem(int btnNumber)
	{
		//INIT
		int invSlotID = btnNumber - 1;
		GameObject GOme = GameObject.FindGameObjectWithTag ("MyFisher");
		GameObject GOmanager = GameObject.FindGameObjectWithTag ("GameManager");

		//it is my own fisher in control.  
		if (GOmanager.GetComponent<ObjSelection> ().currentlySelectedUnit == GOme) 
		{
			//we are at shop range.
			if(GOme.GetComponent<PlayerStatus>().shoppingEnabled == true)
			{
				//GET inventory contents of player.
				List<Item> inv = GOme.GetComponent<PlayerStatus>().InventoryContents();


				//Remove Item from slot
				GOme.GetComponent<PlayerStatus>().RemoveItem(inv[invSlotID].itemID);

				//UpdateInventory on GUI
				
				//Add Money for player
				GOme.GetComponent<PlayerStatus>().GiveMoney(10);
				
				//Record sold Fish value/Weight for GameResults
				
				//Inform player of selling
				Notificate ("Sold item from slot " + (btnNumber - 1) + ". You got 10 Gold");
			}
		}
	}



	#region Helpers
	public void Notificate(string txt)
	{
		Notif = Instantiate(noti);
		Notif.GetComponent<Text> ().text = txt;
		Notif.transform.SetParent(Canvas.transform,false);
	}
	public void setInventoryVisible()
	{
		showInventory = true;
	}
	public void setInventoryNotVisible()
	{
		showInventory = false;
	}
	public bool isInventoryVisible ()
	{
		return showInventory;
	}
	
	#endregion

}
