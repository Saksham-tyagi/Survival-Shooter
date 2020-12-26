using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTagger : MonoBehaviour {

	public GameObject theTerrain;
	public string thisTag;
	string defaultTag;

	// Use this for initialization
	void Start () {
		defaultTag = theTerrain.tag;	
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			theTerrain.tag = thisTag;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			theTerrain.tag = defaultTag;
		}
	}
}
