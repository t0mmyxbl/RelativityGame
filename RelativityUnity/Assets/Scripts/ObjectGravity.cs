using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour {

    private Rigidbody rb;
    private float gravity = -6;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("g"))
            gravity *= -1;

        rb.AddForce(0, gravity, 0);

    }


}
