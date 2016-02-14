using UnityEngine;
using System.Collections;

[System.Serializable]
public class FishableItem : Item {

	public FishableType fishableType;

	public enum FishableType
	{
		Fish,
		Trash
	}

	public FishableItem(string name, string description, int value, FishableType type )
	{
		itemName = name;
		itemDesc = description;
		itemValue = value;
		fishableType = type;
	}

	public FishableItem(){

	}
}
