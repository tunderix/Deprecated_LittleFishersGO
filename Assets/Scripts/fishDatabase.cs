using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fishDatabase : MonoBehaviour 
{

	public List<Fish> fishes = new List<Fish>();

	void Start()
	{
		fishes.Add (new Fish ("Angelfish",0,10,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("JellyFish",1,13,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Anthias",2,16,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Bassandgroupers",3,19,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Bassletsandassessors",4,22,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Batfish",5,25,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Blennies",6,28,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Boxfishandblowfish",7,31,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Butterflyfish",8,34,Fish.FishSize.Small));
		fishes.Add (new Fish ("Cardinalfish",9,37,Fish.FishSize.Small));
		fishes.Add (new Fish ("Chromis",10,40,Fish.FishSize.Small));
		fishes.Add (new Fish ("Clownfish",11,43,Fish.FishSize.Small));
		fishes.Add (new Fish ("Damsels",12,46,Fish.FishSize.Small));
		fishes.Add (new Fish ("Dartfish",13,49,Fish.FishSize.Small));
		fishes.Add (new Fish ("Dragonets",14,52,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Eels",15,55,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Filefish",16,58,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Foxface",17,61,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Flatfish",18,64,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Frogfish",19,67,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Goatfish",20,70,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Gobies",21,73,Fish.FishSize.Medium));
		fishes.Add (new Fish ("Grunts",22,76,Fish.FishSize.Large));
		fishes.Add (new Fish ("Hamlet",23,79,Fish.FishSize.Large));
		fishes.Add (new Fish ("Hawkfish",24,82,Fish.FishSize.Large));
		fishes.Add (new Fish ("Hogfish",25,85,Fish.FishSize.Large));
		fishes.Add (new Fish ("Jacks",26,88,Fish.FishSize.Large));
		fishes.Add (new Fish ("Jawfish",27,91,Fish.FishSize.Large));
		fishes.Add (new Fish ("Lionfish",28,94,Fish.FishSize.Large));
		fishes.Add (new Fish ("Parrotfish",29,97,Fish.FishSize.Large));
		fishes.Add (new Fish ("Pipefish",30,100,Fish.FishSize.Large));
		fishes.Add (new Fish ("Pseudochromis",31,103,Fish.FishSize.Large));
		fishes.Add (new Fish ("Rabbitfish",32,106,Fish.FishSize.Large));
		fishes.Add (new Fish ("Rays",33,109,Fish.FishSize.Large));
		fishes.Add (new Fish ("Scorpionfish",34,112,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Seahorse",35,115,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Squirrelfish",36,118,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Sharks",37,121,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Snappers",38,124,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Tangs",39,127,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Tilefish",40,130,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Triggerfish",41,133,Fish.FishSize.Huge));
		fishes.Add (new Fish ("Wrasse",42,136,Fish.FishSize.Huge));
	}

}
