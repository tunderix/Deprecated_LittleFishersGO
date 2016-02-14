using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemDatabase : MonoBehaviour 
{
	public List<Fish> fishes = new List<Fish>();
	public List<Trash> trashes = new List<Trash>();

	void Start()
	{
		//First Generate Fishes:
		fishes.Add (new Fish ("Angelfish","Tiniest", 4,Fish.FishSize.Tiny));
		fishes.Add (new Fish ("Sucke whitefang","Might sell for...hmmm, maybe not much!", 23,Fish.FishSize.Small));
		fishes.Add (new Fish ("Mama sakker","mmm... medium", 40,Fish.FishSize.Medium));
		fishes.Add (new Fish ("White Whale","LapaLarge... Not Whale thou..", 100,Fish.FishSize.Large));
		fishes.Add (new Fish ("Paradisefish","Omg HUUUge fish!", 200,Fish.FishSize.Huge));

		//Then Generate Trashes:
		trashes.Add (new Trash ("Old Boots","Rotten smelly boots. Prolly not worth it", 2));
		trashes.Add (new Trash ("Rusty Bicycle","Rusty bike", 10));
	}

	public Fish getRandomFish(){
		int randomNumber = Random.Range(0,fishes.Count);
		return fishes [randomNumber];
	}
}
