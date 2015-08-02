using UnityEngine;
using System.Collections;

public class MainMenuTab : MonoBehaviour {

	Animator anim;

	/// <summary>
	/// This is mainMenuTab
	/// </summary>
	/// 
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		anim.SetBool ("roomSelectionActive", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void tabSelect()
	{
		if (anim.GetBool ("roomSelectionActive") == false) 
		{
			anim.SetBool ("roomSelectionActive", true);
		} 
		else 
		{
			anim.SetBool ("roomSelectionActive", false);
		}

	}
}
