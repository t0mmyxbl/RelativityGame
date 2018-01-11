using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerGravity : MonoBehaviour {


    public float gravity = -6;
	private FirstPersonController FPC;
	public bool onFloor = true;
	public bool onRoof = false;

	void Start()
	{
		FPC = GetComponent <FirstPersonController> ();
	}

	void FixedUpdate()
	{

        if (Input.GetKeyDown("g"))
        {
			onFloor = false;
			onRoof = false;
           ChangeGravity();
        }
		detectRoof ();

    }

void ChangeGravity()
{
		gravity *= -1;
        FPC.m_JumpSpeed *= -1;
		transform.Rotate(0, 0, 180, Space.Self);
        FPC.m_MouseLook.Init(transform, FPC.m_Camera.transform);
}

	void detectRoof(){
        Ray rayUp = new Ray(transform.position, transform.up);
        Ray rayDown = new Ray(transform.position, -transform.up);

        if (gravity < 0)
        {
            rayUp = new Ray(transform.position, transform.up);
            rayDown = new Ray(transform.position, -transform.up);
        }
        else if (gravity > 0)
        {
            rayUp = new Ray(transform.position, -transform.up);
            rayDown = new Ray(transform.position, transform.up);
        }

		RaycastHit hit;
        
		if (Physics.Raycast (rayDown, out hit, 4f)) {

			//print ("hitfloor");
			onFloor = true;
			onRoof = false;
		}else
		if (Physics.Raycast (rayUp, out hit, 4f)) {
            //print("hitroof");
            onFloor = false;
			onRoof = true;
        }
        else
        {
            onFloor = false;
            onRoof = false;
        }
		
	}

}