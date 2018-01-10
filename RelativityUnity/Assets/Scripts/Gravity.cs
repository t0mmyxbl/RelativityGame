using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody rb;
    public float gravity = -6;
	public bool isChanging;

	void Start()
	{
		
		rb = GetComponent<Rigidbody>();
		isChanging = false;
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

		transform.localRotation = Quaternion.Euler(180, 0, 0);

		Cursor.lockState = CursorLockMode.None;
		isChanging = false;
}

}