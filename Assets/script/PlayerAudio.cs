using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour {

	public AudioSource sfxAudios;
	public AudioClip[] floorSteps;

	public float distToGround = 1.3f;
	RaycastHit hitInfo;

	bool Grounded()
	{
		return Physics.Raycast (transform.position + Vector3.up * 0.5f, -Vector3.up, out hitInfo, distToGround);
	}
 
	public void Footsteps()
	{
		if (Grounded ()) 
		{
			int r = Random.Range (0, floorSteps.Length);
			switch (hitInfo.transform.GetComponent<Collider> ().tag) 
			{
			case "Floor":
				sfxAudios.PlayOneShot (floorSteps [r]);
				break;
			default :
				sfxAudios.PlayOneShot (floorSteps [r]);
				break;
			}

		}
	}

}
