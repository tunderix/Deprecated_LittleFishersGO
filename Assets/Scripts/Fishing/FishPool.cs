using UnityEngine;
using System.Collections;

[System.Serializable]
public class FishPool {

	public fishPoolFishes fishesInPool;
	public int ratioOfFishes;

	void Start(){
	}
	
	public enum fishPoolFishes
	{
		Tiny,
		Small,
		Medium,
		Large,
		Huge
	}
	public FishPool(fishPoolFishes fip)
	{
		fishesInPool = fip;
	}
	public FishPool()
	{

	}
}
