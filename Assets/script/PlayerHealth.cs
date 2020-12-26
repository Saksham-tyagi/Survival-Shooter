using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	Animator anim;
	AudioSource playerAudio;
	PlayerController playerController;
	CrackerBomb playerShooting;
	bool isDead ;
	bool damaged;
	public int amount = 2;

	void Awake () 
	{
		anim = GetComponent<Animator> ();
		playerAudio = GetComponent<AudioSource> ();
		playerController = GetComponent<PlayerController> ();
		playerShooting = GetComponentInChildren<CrackerBomb>();
		currentHealth = startingHealth;
	}

	void Update () 
	{
		if (damaged) {
			damageImage.color = flashColour;
		} 
		else 
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

//	public void TakeDamage()
//	{
//		damaged = true;
//
//		currentHealth -= amount;
//
//		healthSlider.value = currentHealth;
//
//		playerAudio.Play ();
//
//		if (currentHealth <= 0 && !isDead) 
//		{
//			Death ();
//		}
//	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			damaged = true;

			currentHealth -= amount;

			healthSlider.value = currentHealth;

			playerAudio.Play ();

			if (currentHealth <= 0 && !isDead) 
			{
				Death ();
			}
		}
	}

	public void Death()
	{
		isDead = true;

		//playerShooting.DisableEffects();

		anim.SetTrigger("IsDead");

//		playerAudio.clip = deathClip;
//		playerAudio.Play ();
//
		playerController.enabled = false;
		playerShooting.enabled = false;
	}
}
