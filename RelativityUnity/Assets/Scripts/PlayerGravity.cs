using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerGravity : MonoBehaviour {

	private Rigidbody rb;
    public float gravity = -6;
	public bool isChanging = false;
	//public float rotationSpeed = 1;
	private AutoMoveAndRotate autoMove;
	private FirstPersonController FPC;
	private Camera playerCamera;

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
           ChangeGravity();
        }

     rb.AddForce(0, gravity*5, 0);

    }

void ChangeGravity()
{
		isChanging = true;
		Cursor.lockState = CursorLockMode.Locked;
		gravity *= -1;
		StartCoroutine (SpinPlayer ());

		Cursor.lockState = CursorLockMode.None;
		isChanging = false;
}

    IEnumerator SpinPlayer(){

		FPC.enabled = false;
		autoMove.enabled = true;
		yield return new WaitForSeconds (2);
		autoMove.enabled = false;
        FPC.m_MouseLook.Init(transform, FPC.m_Camera.transform);


         if (autoMove.rotateDegreesPerSecond.value.z == 90)
        {
            autoMove.rotateDegreesPerSecond.value.z = -90;
        }
        else if (autoMove.rotateDegreesPerSecond.value.z == -90)
        {
            autoMove.rotateDegreesPerSecond.value.z = 90;
        }

        FPC.m_MouseLook.isRotated = !FPC.m_MouseLook.isRotated;
        FPC.enabled = true;

}

}