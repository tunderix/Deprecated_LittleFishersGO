using UnityEngine;
using System.Collections;

public class ObjSelection : MonoBehaviour {

	public GameObject currentlySelectedUnit;

	public void SelectObject(GameObject hitGO, int caseNumber)
	{
		//Deactivate current selection
		DeselectGameobjectIfSelected ();
		
		//is there selected Obj under hitGO?
		if(hitGO.transform.FindChild("Selected").gameObject != null)
		{
			//HITGO IS SELECTABLE
			
			//Store selectedOBJ under hitGO
			GameObject SelectedObj = hitGO.transform.FindChild ("Selected").gameObject;
			
			//SET Selection object active to mark him
			SelectedObj.SetActive (true);
			
			//SET new selection
			currentlySelectedUnit = hitGO;
		}
		else // No Selection object
		{
			// HITGO NOT SELECTABLE
			DeselectGameobjectIfSelected();
		}

		//Update UI
		GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GUIControl> ().updateGUI ();
	}
	
	public void DeselectGameobjectIfSelected()
	{
		if (currentlySelectedUnit != null) 
		{
			//disable selection.
			currentlySelectedUnit.transform.FindChild ("Selected").gameObject.SetActive (false);
			
			//set currently selected unit of MOUSE to null
			currentlySelectedUnit = null;
		} 
		else 
		{

		}
	}
}
