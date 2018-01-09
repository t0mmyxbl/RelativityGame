using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {


	public float thrust;
	public Rigidbody rb;
    //GameObject obj;
	bool inverted;


	void Start()
	{
		inverted = false;
		rb = GetComponent<Rigidbody>();
        //obj = GetComponent<GameObject>();

	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown ("g"))
			ChangeGravity ();

        if (gameObject.tag != "Player")
        {
		    if (inverted)
			    rb.AddForce (0, 5, 0);
		    else
			    rb.AddForce (0, -5, 0);
        }
        else
        {
            if (inverted)
                rb.transform.Translate(0, 0.1f, 0);
            else
                rb.transform.Translate(0, -0.1f, 0);
        }



	}



void ChangeGravity()
{
	if (inverted)
		inverted = false;
	else
		inverted = true;
}

}