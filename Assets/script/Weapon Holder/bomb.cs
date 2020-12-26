using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {
	public int damage = 40;
	public float range = 50f;
	public float impactForce = 150f;

	public Camera fpsCam;
	public ParticleSystem smallExplosionFlash;
	public GameObject impactEffectExplosion;

	//public AudioClip ImpactExplosion;

	int shootableMask;


	void Awake()
	{
		shootableMask = LayerMask.GetMask ("Shootable");

	}

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
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range, shootableMask)) 
		{
			EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) 
			{
				enemyHealth.TakeDamage (damage);
			}
			//Target target =	hit.transform.GetComponent<Target> ();
			//			if (target != null) 
			//			{
			//				target.TakeDamage (damage);
			//			}

			//to add force
			if (hit.rigidbody != null) 
			{
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}
			//AudioSource.PlayClipAtPoint (ImpactExplosion, -hit.normal);

			GameObject impactGO = Instantiate (impactEffectExplosion, hit.point, Quaternion.LookRotation (hit.normal) );

			Destroy (impactGO, 1f);
		}

	}

}
