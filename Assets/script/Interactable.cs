using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public bool interactable = false;

	public Material[] material;
	Renderer rend;
	//public ParticleSystem healFlash;

	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = material[0];
	}
	
	public void Interact()
	{
	  Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(interactable && Input.GetKeyDown(KeyCode.G))
		{
		    Interact();
			//healFlash.Play ();
		}
		if(interactable)
		{
		   rend.sharedMaterial = material[1];
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			interactable = false;
		}
	}
}
