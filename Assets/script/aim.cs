using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour {

	public GameObject crossHair;
	private bool scoped = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.V)) 
		{
			scoped = !scoped;
			if (scoped)
				OnScoped ();				
			else
				OnUnscoped ();
		}

	}

	void OnUnscoped ()
	{
		crossHair.SetActive (false);
	}

	void OnScoped()
	{


		crossHair.SetActive (true);
		
	}

		

}
