using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	private bool spawnPointUsed = false;

	public void setUsed()
	{
		spawnPointUsed = true;
	}
	public bool isUsed()
	{
		return spawnPointUsed;
	}
}
