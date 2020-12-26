using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion; // Reference to the shatterd version of the object

	public void Destroy()
	{   
		// Spawn a shattered object
		Instantiate (destroyedVersion, transform.position, transform.rotation);

		// Remove the current Object
		Destroy(gameObject);
	}
}
