using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Contains("Fisher")) 
		{
			other.GetComponent<PlayerStatus>().shoppingEnabled = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag.Contains("Fisher")) 
		{
			other.GetComponent<PlayerStatus>().shoppingEnabled = false;
		}
	}
}
