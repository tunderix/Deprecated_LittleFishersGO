using UnityEngine;
using System.Collections;

public class DestroyParentObject : MonoBehaviour {

	void DestroyPathMarkerParent()
	{
		Destroy (this.gameObject.transform.parent.gameObject);
	}
}
