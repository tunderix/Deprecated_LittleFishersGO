using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public string itemDesc;
	public int itemValue;

	public Item(string name, int id, string description, int value)
	{
		itemName = name;
		itemDesc = description;
		itemValue = value;
	}

	public Item(){

	}
}
