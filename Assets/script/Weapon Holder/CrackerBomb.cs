using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrackerBomb : MonoBehaviour {
	public int damagePerShot = 40;
	public float range = 50f;
	public float impactForce = 150f;
	public float timeBetweenBullets = 0.20f;

	//public Camera fpsCam;
	public GameObject Bomb;
	public ParticleSystem smallExplosionFlash;
	public GameObject impactEffectExplosion;

	float timer;
	int shootableMask;
	LineRenderer gunLine;
	AudioSource gunAudio;
	float effectsDisplayTime = 1f;


	void Awake()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();

	}

	void Update() 
	{
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets ) 
		{
			Shoot ();

		}

		if (timer >= timeBetweenBullets * effectsDisplayTime) 
		{
			DisableEffects ();
		}
   }

	public void DisableEffects ()
	{
		gunLine.enabled = false;

	}

	void Shoot()
	{
		timer = 0f;


		gunAudio.Play ();

		smallExplosionFlash.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		RaycastHit shootHit;
		if (Physics.Raycast (Bomb.transform.position, Bomb.transform.forward, out shootHit, range, shootableMask)) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damagePerShot);
			}

			gunLine.SetPosition (1, shootHit.point);

			//Target target =	hit.transform.GetComponent<Target> ();
//			if (target != null) 
//			{
//				target.TakeDamage (damage);
//			}

			//to add force
			if (shootHit.rigidbody != null) {
				shootHit.rigidbody.AddForce (-shootHit.normal * impactForce);
			}


			GameObject impactGO = Instantiate (impactEffectExplosion, shootHit.point, Quaternion.LookRotation (shootHit.normal));

			Destroy (impactGO, 1f);
		} 
		else 
		{
			gunLine.SetPosition (1, transform.position + transform.forward * range);
		}
	}

}
