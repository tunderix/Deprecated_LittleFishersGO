using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Chat : MonoBehaviour 
{
	public List<string> chatHistory = new List<string>();

	private PhotonView photonView;

	public GameObject inputTxt;
	public GameObject chatWindow;

	void Start()
	{
		photonView = GetComponent<PhotonView> ();
	}
	public void SendChatMsg()
	{
		string msg = inputTxt.GetComponent<InputField>().text;
	
		photonView.RPC ("sendMessage", PhotonTargets.All, msg, PhotonNetwork.playerName);
	}
	void updateChatWindow()
	{
		if (chatHistory.Count > 10) {
			chatHistory.RemoveAt(0);
		}

		//first clear the textfield empty...
		chatWindow.GetComponent<Text> ().text = "";

		foreach (string msg in chatHistory) 
		{
			chatWindow.GetComponent<Text> ().text = chatWindow.GetComponent<Text> ().text + msg + "\n";
		}

	}

	[PunRPC]
	private void sendMessage(string msg, string playerName)
	{
		chatHistory.Add (playerName + ": " + msg);

		//tell to update CHATwindow.
		updateChatWindow ();
	}


}
