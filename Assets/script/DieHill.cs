using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieHill : MonoBehaviour {

	public bool IsDead = false;

	public GameObject player;
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			IsDead = !IsDead;
			Die ();
		}
	}



	void Die()
	{
		anim.SetBool ("IsDead", IsDead);


		LoadByIndex (0);
	}

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

}
