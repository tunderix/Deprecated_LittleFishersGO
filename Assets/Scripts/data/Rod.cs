using UnityEngine;
using System.Collections;

[System.Serializable]
public class Rod 
{
	public string rodName;
	public int rodID;
	public string rodDesc;
	public int rodCost;
	public int rodStrengthModifier;
	public int rodRange;

	public Rod(string name, int id, string description, int cost, int strmod, int rng)
	{
		rodName = name;
		rodID = id;
		rodDesc = description;
		rodCost = cost;
		rodStrengthModifier = strmod;
		rodRange = rng;
	}
	public Rod()
	{
		
	}
	
	
	
}
