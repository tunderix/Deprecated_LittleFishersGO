using UnityEngine;
using System.Collections;

[System.Serializable]
public class Fish : FishableItem{
	
	public enum FishSize{
		Tiny,
		Small,
		Medium,
		Large,
		Huge
	}

	public FishSize fishSize;
	
	public Fish(string name, string description, int value,FishSize fSize)
	{
		itemName = name;
		itemDesc = description;
		itemValue = value;
		fishSize = fSize;
		fishableType = FishableType.Fish;
	}

	public string getIconPath(){
		switch (fishSize) {
		case FishSize.Huge:
			return "Item Icons/FishHuge";
			break;
		case FishSize.Large:
			return "Item Icons/FishLarge";
			break;
		case FishSize.Medium:
			return "Item Icons/FishMedium";
			break;
		case FishSize.Small:
			return "Item Icons/FishSmall";
			break;
		case FishSize.Tiny:
			return "Item Icons/FishTiny";
			break;
		default:
			return "Item Icons/Blanko";
			break;
		}
	}
}
