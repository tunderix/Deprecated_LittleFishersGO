using UnityEngine;
using System.Collections;

public class namePlate : MonoBehaviour {

	public string playerName;
	public TextMesh NAMEPLATE;
	private PhotonView photonView;
	
	void Start () 
	{
		photonView = GetComponent<PhotonView> ();
		NAMEPLATE = gameObject.GetComponent<TextMesh>();
		playerName = GetComponentInParent<PlayerStatus> ().playerName;
		photonView.RPC ("setName", PhotonTargets.All, playerName);
	}    
	
	[PunRPC]
	public void setName (string name) {
		NAMEPLATE.text = name;
	}

}
