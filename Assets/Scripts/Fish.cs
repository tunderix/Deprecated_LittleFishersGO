using UnityEngine;
using System.Collections;

[System.Serializable]
public class Fish {
	public string name;
	public int id;
	public int value;
	public FishSize fishSize;
	
	public enum FishSize{
		Tiny,
		Small,
		Medium,
		Large,
		Huge
	}
	
	public Fish(string fname, int fid, int fvalue,FishSize ftype)
	{
		name = fname;
		id = fid;
		value = fvalue;
		fishSize = ftype;
	}
	public Fish()
	{
		
	}
	
	
	
}
