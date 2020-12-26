using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tossed : MonoBehaviour {

	public GameObject obj;
	public Transform tossPoint;
	GameObject teleportBomb;


	// Use this for initialization
	void Start () 
	{
		teleportBomb = (GameObject)Instantiate (obj);
		teleportBomb.GetComponent<Teleport>().player = gameObject;
		teleportBomb.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			teleportBomb.transform.position = tossPoint.position;
			teleportBomb.transform.rotation = tossPoint.rotation;
			teleportBomb.SetActive (true);
			teleportBomb.GetComponent<Rigidbody>().AddRelativeForce (0,5,7, ForceMode.Impulse);
		}
		
	}
}
