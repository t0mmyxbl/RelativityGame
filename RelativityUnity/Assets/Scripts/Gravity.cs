using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody rb;
    public float gravity = -6;

	void Start()
	{
		//inverted = false;
		rb = GetComponent<Rigidbody>();
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
    gravity *= -1;
}

}