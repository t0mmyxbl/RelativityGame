using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {


	public float thrust;
	public Rigidbody rb;
	bool inverted;


	void Start()
	{
		inverted = false;
		rb = GetComponent<Rigidbody>();

	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown ("g"))
			ChangeGravity ();

		if (inverted)
			rb.AddForce (0, -5, 0);
		else
			rb.AddForce (0, 5, 0);
	}



void ChangeGravity()
{
	if (inverted)
		inverted = false;
	else
		inverted = true;
}

}