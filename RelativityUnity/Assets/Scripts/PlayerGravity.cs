using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityStandardAssets.Utility;

public class PlayerGravity : MonoBehaviour {

	[SerializeField] private AudioClip InvertGravitySound;
	[SerializeField] private AudioSource m_AudioSource;

    public float gravity = -6f;
	private FirstPersonController FPC;

	void Start()
	{
		//m_AudioSource = GetComponent<AudioSource>();
		FPC = GetComponent <FirstPersonController> ();
	}

	void Update()
    {

        if (Input.GetKeyDown("g"))
        {
			m_AudioSource.clip = InvertGravitySound;
			m_AudioSource.Play();

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