using UnityEngine;

public class Target : MonoBehaviour {


	Animator anim;
	public float health = 50f;
	public bool IsDead = false;


	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	public void TakeDamage (float amount)
	{
		health -= amount;
		if (health <= 0f) 
		{
			IsDead = !IsDead;
			Die ();

		}
	}

	void Die()
	{
		anim.SetBool ("IsDead", IsDead);
		Destroy (gameObject, 10f);
	}

}
