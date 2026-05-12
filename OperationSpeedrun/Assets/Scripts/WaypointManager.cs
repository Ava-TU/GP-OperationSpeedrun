using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour
{
	public enum PathType
	{
		Loop,
		ReverseWhenComplete
	}

	public Transform[] waypoints;
	public PathType pathType = PathType.Loop;

	private int direction = 1;
	int index;

	public Vector3 GetCurrentWayPoint()
	{
		return waypoints[index].position;
	}

	public Vector3 GetNextWaypoint()
	{
		if (waypoints.Length == 0) return transform.position;

		index = GetNextWaypointIndex();
		Vector3 nextWaypoint = waypoints[index].position;

		return nextWaypoint;
	}

	private int GetNextWaypointIndex()
	{
		//move to next index in array
		index += direction;

		if (pathType == PathType.Loop)
		{
			index %= waypoints.Length;
		}
		else if (pathType == PathType.ReverseWhenComplete)
		{
			//Reverse direction if at bounds
			if (index >= waypoints.Length || index < 0)
			{
				direction *= -1;
				index += direction * 2;
			}
		}

		return index;
	}

	private void OnDrawGizmos()
	{
		if (waypoints == null || waypoints.Length == 0) return;

		Gizmos.color = Color.white;

		//Draw lines between waypoints
		for (int i = 0; i < waypoints.Length - 1; i++)
		{
			Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
		}

		//loop back to start if the path is a loop
		if (pathType == PathType.Loop)
		{
			Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);
		}

		Gizmos.color = Color.red;

		//Draw the waypoints as spheres
		foreach (Transform waypoint in waypoints)
		{
			Gizmos.DrawSphere(waypoint.position, 0.2f);
		}
	}



	//int nextIndex;
	//public GameObject[] waypoints;

	//public GameObject NextWaypoint (GameObject current)
	//{
		//if (current != null) 
		//{
			// Find array index of given waypoint
			
			//for (int i = 0; i < waypoints.Length; i++) 
			//{
				// Once found calculate next one
				
				//if (current == waypoints [i]) 
				//{
					// Modulus operator helps to avoid to go out of bounds
					// And resets to 0 the index count once we reach the end of the array
					//nextIndex = (i + 1) % waypoints.Length;
				//}
			//}
		//} 
		//else 
		//{
			// Default is first index in array
			//nextIndex = 0;
		//}
		
		//return waypoints [nextIndex];
	//}
}
