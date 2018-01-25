using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerGravity : MonoBehaviour {


    public float gravity = -6;
	private FirstPersonController FPC;

	void Start()
	{
		FPC = GetComponent <FirstPersonController> ();
	}

	void FixedUpdate()
    {

        if (gravity < 0)
        {
            FPC.setdirection(Vector3.down);
        }
        else
            if (gravity > 0)
            {
            FPC.setdirection(Vector3.up);
            }
        if (Input.GetKeyDown("g"))
        {
           ChangeGravity();
        }

    }

    void ChangeGravity()
    {
            Physics.gravity *= -1;


    		gravity *= -1;
            FPC.m_JumpSpeed *= -1;
    		transform.Rotate(0, 0, 180, Space.Self);
            FPC.m_MouseLook.Init(transform, FPC.m_Camera.transform);
    }		

}