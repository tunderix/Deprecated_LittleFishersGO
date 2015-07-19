using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemDatabase : MonoBehaviour 
{
	public List<Item> items = new List<Item>();

	void Start()
	{
		items.Add (new Item ("Tiny Fish",0,"Tiniest", 4,Item.ItemType.Fish));
		items.Add (new Item ("Small Fish",1,"Might sell for...hmmm, maybe not much!", 23,Item.ItemType.Fish));
		items.Add (new Item ("Medium Fish",2,"mmm... medium", 40,Item.ItemType.Fish));
		items.Add (new Item ("Large Fish",3,"LapaLarge... Not Whale thou..", 100,Item.ItemType.Fish));
		items.Add (new Item ("Huge Fish",4,"Omg HUUUge fish!", 200,Item.ItemType.Fish));
		items.Add (new Item ("Old Boots",5,"Rotten smelly boots. Prolly not worth it", 2,Item.ItemType.Trash));
		items.Add (new Item ("Rusty Bicycle",6,"Rusty bike", 10,Item.ItemType.Trash));
		items.Add (new Item ("Bait-Z",7,"SlimyWormThing", 50,Item.ItemType.Bait));
		items.Add (new Item ("Bait-X",8,"Slimy Pinkie", 100,Item.ItemType.Bait));
		items.Add (new Item ("Epic Bait",9,"BestOfBaits", 200,Item.ItemType.Bait));
		items.Add (new Item ("Fishing Bag XL",10,"Huge Backpack... Room for plenty", 150,Item.ItemType.Quest));
	}
	
}
