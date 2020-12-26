using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	//private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotationX = 0f;
	private float currentCameraRotationX = 0f;

	[SerializeField]
	private float lookSensitivity = 3f;

	[SerializeField]
	private float cameraRotationLimit = 40f;


	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}

	// Gets a movement vector
	//public void Move (Vector3 _velocity)
	//{
	//	velocity = _velocity;
	//}
		
	//Gets a rotational vector
	public void Rotate (Vector3 _rotation)
	{
		rotation = _rotation;
	}

	//Gets a rotational vector for the camera
	public void RotateCamera (float _cameraRotationX)
	{
		cameraRotationX = _cameraRotationX;
	}


	// Run every physics iteration
	void FixedUpdate()
	{
		//PerformMovement ();
		PerformRotation ();
	}

	void Update()
	{
		if (Cursor.lockState != CursorLockMode.Locked) 
		{
			Cursor.lockState = CursorLockMode.Locked;	
			}

		//Apply movement
		//motor.Move(_velocity);

		//Calculate rotation as a 3d vector (turning around)
		float yRot = Input.GetAxisRaw("Mouse X"); 

		Vector3 rotation = new Vector3 (0f, yRot, 0f) * lookSensitivity;

		//apply rotation
		Rotate(rotation);

		//Calculate camera rotation as a 3d vector (turning around)
		float xRot = Input.GetAxisRaw("Mouse Y"); 

		float cameraRotationX = xRot * lookSensitivity;

		//Apply camera rotation
		RotateCamera(cameraRotationX);


	}

	// perform movement based on velocity variable
	/*void PerformMovement()
	{
		if (velocity != Vector3.zero) 
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);  
		}
	}*/
		
	// perform rotation
	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
		if (cam != null) 
		{
			//Set our rotation and clamp it
			currentCameraRotationX -= cameraRotationX;
			currentCameraRotationX = Mathf.Clamp (currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

			// Apply our rotation to the transform of our camera
			cam.transform.localEulerAngles = new Vector3 ( currentCameraRotationX, 0f, 0f);
		}
	}

}
