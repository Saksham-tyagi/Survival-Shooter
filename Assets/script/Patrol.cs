using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	NavMeshAgent agent;
	Animator anim;
	public Transform target;
	Vector3 lastKnownPosition;
	public Transform eye;

	bool patrolling;
	public Transform[] patrolTargets;
	private int destPoint;
	bool arrived;

	public float Forward;
	public bool Attack;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();	
		anim = GetComponent<Animator> ();
		lastKnownPosition = transform.position;
	}

	bool CanseeTarget()
	{
		bool canSee = false;
		Ray ray = new Ray (eye.position, transform.position - eye.position);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit))
		{
			if (hit.transform != target) {
				canSee = false;
			} 
			else 
			{
				lastKnownPosition = target.transform.position;
				canSee = true;
			}
		}

		return canSee;
	}

	// Update is called once per frame
	void Update ()
	{
		if (agent.pathPending) 
		{
			return;
		}

		if (patrolling) 
		{ 
			if (agent.remainingDistance < agent.stoppingDistance) {
				if (!arrived) {
					arrived = true;
					StartCoroutine ("GoToNextPoint");
				} 
			} else {
				arrived = false;
			}
		}

		if (CanseeTarget ()) 
		{
			agent.SetDestination (target.transform.position);
			patrolling = false;
			if (agent.remainingDistance < agent.stoppingDistance) 
			{
				anim.SetBool ("Attack", true);
			}  
			else 
			{
				anim.SetBool ("Attack", false);
			}
		}

	else
	{
		anim.SetBool ("Attack", false);
			if(!patrolling)
		    {
				agent.SetDestination (lastKnownPosition);
				if (agent.remainingDistance < agent.stoppingDistance) 
				{
					patrolling = true;
					StartCoroutine("GoToNextPoint");
				}
			}
	 }
		anim.SetFloat ("Forward", agent.velocity.sqrMagnitude);
}
  
IEnumerator GoToNextPoint()
{
	if (patrolTargets.Length == 0)
	{
		yield break;
	}

	patrolling = true; 
	yield return new WaitForSeconds(2f);
	arrived = false;
	agent.destination= patrolTargets[destPoint].position;
	destPoint = (destPoint + 1) % patrolTargets.Length; 


}

}