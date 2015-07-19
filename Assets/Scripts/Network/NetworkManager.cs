using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject FisherPrefab;
	private GameObject[] spawnTargets;
	public GameObject mCam;

	void Start () 
	{
		//init
		if (PhotonNetwork.inRoom) 
		{
			SpawnMyPlayer ();
		}
	}
	void OnJoinedRoom()
	{
		//Spawn a new player and set it MINE. 

	}

	void SpawnMyPlayer ()
	{
		//Instantiate new fisher.
		GameObject Fisher = PhotonNetwork.Instantiate (FisherPrefab.name, spawnPoint (), Quaternion.identity, 0);

		//set player Properties...
		Fisher.tag = "MyFisher";
		Fisher.GetComponent<NavigationMovement> ().stayStill ();
		Fisher.GetComponent<PlayerStatus> ().playerName = PhotonNetwork.playerName;

		//Tell Selection to select Myfisher....
		GameObject.FindGameObjectWithTag ("GameManager").GetComponent<ObjSelection> ().currentlySelectedUnit = Fisher;

		//SetCamera to look at player at start..
		mCam.GetComponent<CameraMovement> ().setCamPosition (Fisher.transform.position);

		//Tell UI TO to show selected unit... DO NOT. Too FAST for FisherSpawn.... Creates errors...
		//GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GUIControl> ().updateGUI ();
	}
	Vector3 spawnPoint()
	{
		//Init 
		GameObject selectedSpawn = null;

		//Search for all SpawnPoints... 
		spawnTargets = GameObject.FindGameObjectsWithTag ("SpawnPoint");

		//Cycle throuh all spawns... 
		foreach (GameObject spawn in spawnTargets) 
		{
			//Get a free spawnpoint.
			if(spawn.GetComponent<SpawnPoint>().isUsed())
			{
				//Spawnpoint is already Used, no way....
			}
			else
			{
				//Spawnpoint can be chosen... 
				selectedSpawn = spawn;
			}
		}

		//return selected spawn.
		return selectedSpawn.transform.position;
	}
	public void SpawnFishingHook(Vector3 position)
	{
		//PhotonNetwork.Instantiate(fishingMarkerPrefabName, position, Quaternion.identity, 1);
		//Debug.Log("HookSummon.. " + position);
		
	}	
}
