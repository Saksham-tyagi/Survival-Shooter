using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMotor))] 

public class PlayerController : MonoBehaviour {

	public float Horizontal;
	public float Vertical;
	public bool IsRunning;
	public bool IsSprinting;
	public bool IsCrouching;
	public bool IsJumping;

	public float speed = 5f; 


	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true;

	//component caching

	private Animator animator;

	void Start () {


		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

		//Claculate movement velocity as a 3d vector
		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");
		IsRunning = Input.GetKey (KeyCode.LeftShift);
		IsSprinting = Input.GetKey (KeyCode.Space);
		IsCrouching = Input.GetKey (KeyCode.C);
		IsJumping = Input.GetKey (KeyCode.R);




		//Animate Movement

		animator.SetFloat("Horizontal",Horizontal);
		animator.SetFloat("Direction", Horizontal, DirectionDampTime, Time.deltaTime);
		animator.SetFloat("Vertical", Vertical);
		animator.SetFloat("Direction", Vertical, DirectionDampTime, Time.deltaTime);
		animator.SetBool ("IsRunning", IsRunning);
		animator.SetBool ("IsSprinting", IsSprinting);
		animator.SetBool ("IsCrouching", IsCrouching);
		animator.SetBool ("IsJumping", IsJumping);



	}


}