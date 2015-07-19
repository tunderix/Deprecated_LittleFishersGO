using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : Photon.MonoBehaviour 
{
	public UnityEngine.UI.InputField input;
	public UnityEngine.UI.Text Announcer;
	public UnityEngine.UI.Text txtName;
	public GameObject NamePanel;
	public GameObject RoomPanel;
	public GameObject room;
	public GameObject roomsAnchor;
	public UnityEngine.UI.InputField createRoomInput;
	public UnityEngine.UI.InputField createRoomInputPlayers;


	void Start()
	{
		//Connect to photon servers...
		PhotonNetwork.ConnectUsingSettings ("V0.0.0.01");

		//Set GUI to start with NamePanel. 
		NamePanel.SetActive (true);
		RoomPanel.SetActive (false);
	}
	public void refreshRoomsOnGUI()
	{
		if (PhotonNetwork.insideLobby == true) {
			//Update rooms
			int i = 0;

			//Get a list of rooms from Photon.
			foreach (RoomInfo game in PhotonNetwork.GetRoomList()) 
			{
				//instantiate a prefab for room.
				float positionY = (-32.0f * i) + 50.0f;
				GameObject roomie = Instantiate (room);
				RectTransform roomiesRect = roomie.GetComponent<RectTransform> ();
				roomie.transform.SetParent (roomsAnchor.transform);
				roomiesRect.anchorMin = new Vector2 (0, 1);
				roomiesRect.anchorMax = new Vector2 (1, 1);
				roomiesRect.localScale = new Vector3 (1, 1, 1);
				roomiesRect.offsetMin = new Vector2 (0, 0);
				roomiesRect.offsetMax = new Vector2 (0, 30);
				roomiesRect.localPosition = new Vector2 (0, positionY);
				//game.name; game.maxPlayers;

				//find the rooms child with NAME TEXT
				GameObject txtChild = ChildWithName ("txtRoomName");
				if (txtChild != null) {
					//Only returns one GameObject... OUR TXT in CHILD
					txtChild.GetComponent<Text> ().text = game.name;
				}

				//Find GameObject PLAYER AMOUNT in room
				GameObject txtChild2 = ChildWithName ("txtRoomPlayers");
				if (txtChild2 != null) {
					//Only returns one GameObject... OUR TXT in CHILD
					txtChild2.GetComponent<Text> ().text = game.playerCount.ToString ();
				}

				//Find GameObject JoinRoom in room
				GameObject btnJoinRoomChild = ChildWithName ("btnRoomJoin");
				if (btnJoinRoomChild != null) {
					//Only returns one GameObject... OUR TXT in CHILD
					btnJoinRoomChild.GetComponent<Button>().onClick.AddListener(() => { JoinRoom(game) ;});
				}

				i++;
			}
		} else {
			Debug.Log ("Not inside lobby");
		}
	}
	public void JoinRoom(RoomInfo game)
	{
		PhotonNetwork.JoinRoom (game.name);
	}

	public void CreateRoom()
	{
		string RoomName = createRoomInput.text;
		byte roomPlayersMax = byte.Parse (createRoomInputPlayers.text);
		//Validation for name and playerMAX
		if (RoomName.Length > 5) 
		{
			if (roomPlayersMax > 0) 
			{
				RoomOptions newroomoptions = new RoomOptions()
				{
					maxPlayers = roomPlayersMax,
					isOpen =true,
					isVisible = true
				};
				PhotonNetwork.JoinOrCreateRoom(RoomName,newroomoptions,TypedLobby.Default);
			} 
			else 
			{
				Debug.Log("Room Max Player fails");
			}
		}
		else 
		{
			Debug.Log("Roomname fails");
		}
	}

	void OnJoinedRoom()
	{
		LoadGameLevel ();
	}


	#region helpers...

	GameObject ChildWithName(string childName)
	{
		GameObject child = GameObject.Find (childName);
		if (child.gameObject.transform.parent.name == "Room(Clone)") 
		{
			Debug.Log("child:" + child.name.ToString());
			return child;
		} 
		else 
		{
			return null;
		}
	}
	void OnJoinedLobby()
	{

	}
	void LoadGameLevel()
	{
		PhotonNetwork.room.visible = true; 
		PhotonNetwork.LoadLevel(1); 
		PhotonNetwork.automaticallySyncScene = true; 
	}

	//Function for checking the playername...
	public void SubmitName()
	{
		string inputName = input.text;
		
		if (input.text.Length>0) 
		{
			NamePanel.SetActive(false);
			RoomPanel.SetActive(true);

			//Set label to show the name... 
			txtName.text = inputName;

			//Set Photon to remember name...
			PhotonNetwork.playerName = inputName;
		} 
		else 
		{
			Announcer.text = "Give a name...";
		}
	}

	void OnGUI()
	{
		//Connection information
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}

	#endregion
}
