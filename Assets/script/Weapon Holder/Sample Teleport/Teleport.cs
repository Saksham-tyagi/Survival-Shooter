using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject player;

	void OnTriggerEnter( Collider other)
	{
		if (other.tag == "Player")
			GetComponent<Rigidbody>().velocity = Vector3.zero;

		UnityEngine.AI.NavMeshHit hit;
		if (UnityEngine.AI.NavMesh.SamplePosition (transform.position, out hit, 30, 1)) 
		{
			player.transform.position = hit.position;
		}

		gameObject.SetActive (false);
	}
}