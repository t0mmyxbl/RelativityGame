using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Gravity : MonoBehaviour {

	private Rigidbody rb;
    public float gravity = -6;
	public bool isChanging = false;
	//public float rotationSpeed = 1;
	private AutoMoveAndRotate autoMove;
	private FirstPersonController FPC;
	private Camera camera;

	void Start()
	{
		autoMove = GetComponent<AutoMoveAndRotate>();

		FPC = GetComponent <FirstPersonController> ();
		rb = GetComponent<Rigidbody>();
		camera = GetComponent<Camera> ();
		autoMove.enabled = false;
	}

	void FixedUpdate()
	{
        if (Input.GetKeyDown("g"))
        {
           ChangeGravity();
        }

     rb.AddForce(0, gravity*5, 0);

		//if (!inverted)
		//camera.transform.localRotation = Quaternion.identity;
		//else
		camera.transform.localRotation = rb.transform.localRotation;
			


    }



void ChangeGravity()
{
		isChanging = true;
		Cursor.lockState = CursorLockMode.Locked;
		gravity *= -1;
		StartCoroutine (SpinPlayer ());


		//void FixedUpdate() {
			//float turn = Input.GetAxis("Horizontal");
			//rb.AddTorque(transform.right * rotationSpeed * turn);
		//rb.AddTorque(180, 0, 0, ForceMode.VelocityChange);
	

		//transform.eulerAngles = new Vector3(0, 0, 180);
		//void Update() {
		//for (int i = 0; i < 180; i++)
			//rb.transform.rotate(Quaternion.Slerp(Quaternion.identity, Quaternion.Euler(180,0,0), Time.fixedDeltaTime * rotationSpeed));
			//rb.transform.Rotate(Vector3.right, Time.deltaTime, Space.World);
		//}
	







		//transform.localRotation = Quaternion.Euler(180, 0, 0);

		Cursor.lockState = CursorLockMode.None;
		isChanging = false;
}






	IEnumerator SpinPlayer(){



		FPC.enabled = false;
		autoMove.enabled = true;
		yield return new WaitForSeconds (2);
		autoMove.enabled = false;
		FPC.enabled = true;

}

}