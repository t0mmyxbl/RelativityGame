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
        if (Input.GetKeyDown("g"))
        {
           ChangeGravity();
        }

    }

    void ChangeGravity()
    {
    		gravity *= -1;
            FPC.m_JumpSpeed *= -1;
    		transform.Rotate(0, 0, 180, Space.Self);
            FPC.m_MouseLook.Init(transform, FPC.m_Camera.transform);
    }		

}