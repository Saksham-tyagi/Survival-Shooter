using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBomb : MonoBehaviour {
	public float damage = 40f;
	public float range = 50f;
	public float impactForce = 150f;

	public Camera fpsCam;
	public ParticleSystem smallExplosionFlash;
	public GameObject impactEffectExplosion;

	void Update() 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot ();
		}

	}

	void Shoot()
	{
		smallExplosionFlash.Play ();
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
		{
			Debug.Log (hit.transform.name);

			Target target =	hit.transform.GetComponent<Target> ();
			if (target != null) 
			{
				target.TakeDamage (damage);
			}

			//to add force
			if (hit.rigidbody != null) 
			{
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			GameObject impactGO = Instantiate (impactEffectExplosion, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGO, 1f);
		}

	}

}
