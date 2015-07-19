using UnityEngine;
using System.Collections;

public class NavigationMovement : Photon.MonoBehaviour 
{

	public float distanceAway;
	private NavMeshAgent navComp;
	public GameObject PathMarkerPrefab;

	void Start()
	{
		navComp = this.gameObject.GetComponent<NavMeshAgent> ();

	}

	[PunRPC] void setTarget(Vector3 targetPosition)
	{
		if (navComp != null) 
		{
			navComp.SetDestination (targetPosition);
		}

		GameObject.FindGameObjectWithTag("MyFisher").GetComponent<PlayerStatus>().isMoving = true;
	}

	public void stayStill()
	{

		Vector3 thisPoint = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		photonView.RPC ("setTarget", PhotonTargets.All, thisPoint);
		GameObject.FindGameObjectWithTag ("MyFisher").GetComponent<PlayerStatus> ().isMoving = false;

	}

	public void NavigateTo(Vector3 pos)
	{
		SpawnPathMarker (pos);
		if (photonView.isMine) 
		{
			photonView.RPC("setTarget", PhotonTargets.All, pos);
		}

	}

	public void navigateToClosestPoint(Vector3 point)
	{
		//Find closest point of path
		NavMeshHit myNavHit;
		
		if (NavMesh.SamplePosition (point, out myNavHit, 100, -1)) 
		{
			//Set player movement on closest point of click.
			NavigateTo (myNavHit.position);
		}
		else
		{
			Debug.Log("Navigation Closest Position not found");
		}		
	}

	void SpawnPathMarker(Vector3 point)
	{
		//Spawn a PathMarker at given point
		GameObject TargetObj = Instantiate (PathMarkerPrefab, point, Quaternion.identity) as GameObject;
		TargetObj.name = "PathMarker Instantiated";
	}
}
