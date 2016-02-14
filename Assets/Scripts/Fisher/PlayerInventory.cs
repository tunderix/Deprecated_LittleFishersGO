using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour{

	//PLAYER INVENTORY Variables
	public List<InventoryItem> inventory = new List<InventoryItem>();
	private itemDatabase database;

	public int maxSlots;

	void Start ()
	{
		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<itemDatabase> ();
	}

	public bool addItem(InventoryItem item){

		if (inventory.Count < 6) {
			inventory.Add (item);
			return true;
		}
		return false;
	}

	public void emptyPlayerInventory(){
		inventory = new List<InventoryItem>();
	}

	public List<InventoryItem> inventoryContents()
	{
		return this.inventory;
	}
}
