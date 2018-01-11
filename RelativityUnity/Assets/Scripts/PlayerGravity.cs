using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerGravity : MonoBehaviour {

	private Rigidbody rb;
    public float gravity = -6;
	//public bool isChanging = false;
	//public float rotationSpeed = 1;
	private AutoMoveAndRotate autoMove;
	private FirstPersonController FPC;
	private Camera playerCamera;
	public bool onFloor = true;
	public bool onRoof = false;

	void Start()
	{
		autoMove = GetComponent<AutoMoveAndRotate>();

		FPC = GetComponent <FirstPersonController> ();
		rb = GetComponent<Rigidbody>();
		playerCamera = GetComponent<Camera> ();
		autoMove.enabled = false;
	}

	void FixedUpdate()
	{

        if (Input.GetKeyDown("g"))
        {
			onFloor = false;
			onRoof = false;
           ChangeGravity();
        }
		detectFloorOrRoof ();

     //rb.AddForce(0, gravity*5, 0);

    }

void ChangeGravity()
{

		//Cursor.lockState = CursorLockMode.Locked;
		gravity *= -1;
		transform.Rotate(0, 0, 180, Space.Self);
		StartCoroutine (SpinPlayer ());

		//Cursor.lockState = CursorLockMode.None;
}

    IEnumerator SpinPlayer(){

		//FPC.enabled = false;
		//autoMove.enabled = true;


		yield return new WaitForSeconds (2);
		//autoMove.enabled = false;
        //FPC.m_MouseLook.Init(transform, FPC.m_Camera.transform);

        //FPC.m_MouseLook.isRotated = !FPC.m_MouseLook.isRotated;
        //FPC.enabled = true;

}

	void detectFloorOrRoof(){
		Ray rayUp = new Ray(transform.position, transform.up);
		Ray rayDown = new Ray (transform.position, -transform.up);

		RaycastHit hit;

		if (Physics.Raycast (rayDown, out hit, 5)) {

			print ("hitfloor");
			//StartCoroutine (waitForSpin ());
			onFloor = true;
			onRoof = false;
		}
		if (Physics.Raycast (rayUp, out hit, 5)) {
			print ("hitroof");
			//StartCoroutine (waitForSpin ());
			onFloor = false;
			onRoof = true;
		}
			
	}

}