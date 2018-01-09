using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private float speed;

        private Rigidbody rb;
        //private CharacterController m_CharacterController;


    // Use this for initialization
    void Start()
        {
            //m_CharacterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            //RotateView();

            if (Input.GetKey(KeyCode.D))
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += Vector3.forward * speed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position += Vector3.back * speed * Time.deltaTime;
                }
    }

    }
