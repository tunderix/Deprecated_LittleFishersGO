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

	#region GUI UPDATE
	public void updateGUI()
	{//Update all contents of gui...
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

		//update Inventory
		updateInventory (SelectedObject);

		/*
		if (SelectedObject.name.Contains ("Fisher")) 
		{
			//update FisherStatuses
			updateFisherStatus (SelectedObject);
		}
		*/
	}

	void updateInventory (GameObject Player)
	{
		//First, Empty inventoryContents:
		for (int i = 0; i < 6; i++) 
		{
			setImageOnIcon (i, Resources.Load<Sprite> ("Item Icons/Blanko"));
		}

		//Get fishers inventory contents
		List<InventoryItem> inventoryContents = Player.GetComponent<PlayerInventory> ().inventoryContents();

		//Draw players inventorycontents. 
		for (int i = 0; i < inventoryContents.Count; i++) 
		{
			setImageOnIcon (i, inventoryContents [i].iItemIcon);
		}
	}

	private void setImageOnIcon(int i, Sprite sprite){
		////create path for UI object....
		string str = "/InGameGUI/BotPanel/InventoryPanel/icon" + (i+1).ToString ();
		//Object from GUI
		GameObject icon = GameObject.Find(str);
		icon.GetComponent<Image> ().sprite = sprite;
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
