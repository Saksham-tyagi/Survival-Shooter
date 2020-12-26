using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderDie : MonoBehaviour {

	PlayerHealth playerHealth;
	int damage = 0; 

	// Use this for initialization
	void Start () {
		playerHealth = GetComponent<PlayerHealth> ();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			playerHealth.currentHealth-= damage;
			playerHealth.healthSlider.value = playerHealth.currentHealth;
		}
	}
}
