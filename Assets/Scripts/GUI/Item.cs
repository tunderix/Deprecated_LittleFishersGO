using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Sprite itemIcon;
	public int itemValue;
	public ItemType itemType;

	public enum ItemType
	{
		Fish,
		Bait,
		Boost,
		Quest,
		Trash,
		Empty
	}

	public Item(string name, int id, string description, int value, ItemType type )
	{
		itemName = name;
		itemID = id;
		itemDesc = description;
		itemIcon = Resources.Load<Sprite> ("Item Icons/" + name);
		itemValue = value;
		itemType = type;
	}
	public Item()
	{

	}



}
