using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, SlotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item> ();
	private itemDatabase database;
	private bool showInventory;
	private bool showTooltip;
	private string tooltip;
	int inventoryOffsetX;
	int inventoryOffsetY;

	// Use this for initialization
	void Start () {




		for(int i = 0; i < (slotsX*SlotsY); i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}

		//SET OFFSET FOR GUI
		inventoryOffsetX = Screen.width - (slotsX * 60);
		inventoryOffsetY = Screen.height - (SlotsY * 60);

		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<itemDatabase> ();

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
	
	// Update is called once per frame
	void OnGUI () 
	{
		tooltip = "";
		GUI.skin = skin;

		if (showInventory) 
		{
			DrawInventory ();
		}

		if(showTooltip)
		{
			GUI.Box(new Rect(Event.current.mousePosition.x + 15,Event.current.mousePosition.y,200,200), tooltip, skin.GetStyle("Tooltip"));
		}


	}
	void DrawInventory()
	{

		int i = 0;
		for(int y = 0; y < SlotsY; y++)
		{
			for(int x = 0; x < slotsX; x++)
			{

				Rect slotRect = (new Rect(x*60+inventoryOffsetX,y*60+inventoryOffsetY,55,55));
				GUI.Box(slotRect,"", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName != null)
				{
					//GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if(slotRect.Contains(Event.current.mousePosition))
					{
						tooltip = createToolTip(slots[i]);
						showTooltip = true;
					}

				}
				if(tooltip == "")
				{
					showTooltip = false;
				}

				i++;
			}
		}
	}

	string createToolTip(Item item)
	{
		tooltip = "" + item.itemName + "\n\n" + item.itemDesc;
		return tooltip;
	}

	void RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}

	public void AddItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemName == null)
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id)
					{
						inventory[i] = database.items[j];
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
}
