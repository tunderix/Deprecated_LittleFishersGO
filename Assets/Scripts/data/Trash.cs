using UnityEngine;
using System.Collections;

public class Trash : FishableItem {
	public Trash(string name, string description, int value)
	{
		itemName = name;
		itemDesc = description;
		itemValue = value;
		fishableType = FishableType.Trash;
	}
}
