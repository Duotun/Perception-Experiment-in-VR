using UnityEngine;
using System.Collections;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class follow : MonoBehaviour {

	public Transform target;
	Vector3 destination;
	UnityEngine.AI.NavMeshAgent agent;
	
	void Start () {
		// Cache agent component and destination
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		destination = agent.destination;
	}
	
	void Update () {
		// Update destination if the target moves one unit
		if (Vector3.Distance (destination, target.position) > 1.0f) {
			destination = target.position;
			agent.destination = destination;
		}
	}
}
