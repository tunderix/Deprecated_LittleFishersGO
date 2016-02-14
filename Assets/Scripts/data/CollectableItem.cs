using UnityEngine;
using System.Collections;

public class CollectableItem : Item {
	public ItemType itemType;


	public enum ItemType
	{
		Fish,
		Trash,
		Bait
	}

	public CollectableItem(string name, string description, int value, ItemType type )
	{
		itemName = name;
		itemDesc = description;
		itemValue = value;
		itemType = type;
	}
}
