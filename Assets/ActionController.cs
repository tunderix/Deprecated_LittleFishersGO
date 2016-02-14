using UnityEngine;
using System.Collections;

public class ActionController : MonoBehaviour {

	public GameObject gameManager;
	private GameObject player; 
	public GameObject itemDataBase;

	public enum ActionButton
	{
		ab1,
		ab2,
		ab3,
		ab4
	}

	void Start () {
		
	}

	void Update () {
	
	}

	public void onActionButtonClick(ActionButton ab)
	{
		player = GameObject.FindGameObjectWithTag ("MyFisher");

		switch (ab) {
		case ActionButton.ab1:
			addItem ();
			break;
		case ActionButton.ab2:
			removeInventoryItems ();
			break;
		case ActionButton.ab3:
			break;
		case ActionButton.ab4:
			break;
		default:
			break;
		}
	}

	public void addItem(){
		Fish randomfish = itemDataBase.GetComponent<itemDatabase> ().getRandomFish();
		Debug.Log ("Got Fish : " + randomfish.fishSize);
		Sprite tempSprite = Resources.Load<Sprite> (randomfish.getIconPath());
		InventoryItem invItem = new InventoryItem(tempSprite,randomfish,randomfish.itemDesc);

		bool success = player.GetComponent<PlayerInventory> ().addItem (invItem);

		if (success) {
			Debug.Log ("Success In Adding Fish on inventory");
		} else {

			Debug.Log ("Failure In Adding Fish on inventory");
		}

		gameManager.GetComponent<GUIControl> ().updateGUI ();
	}

	private void removeInventoryItems(){
		player.GetComponent<PlayerInventory> ().emptyPlayerInventory();
		gameManager.GetComponent<GUIControl> ().updateGUI ();
	}

	public void sellItemOnSlot(int slotNumber)
	{
		/*
		//it is my own fisher in control.  
		if (gameManager.GetComponent<ObjSelection> ().currentlySelectedUnit == GOme) 
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
		*/
	}

}
