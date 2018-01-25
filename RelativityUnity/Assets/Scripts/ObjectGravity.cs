using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour {

    private Rigidbody rb;
    private float gravity = -9.81f;
    private bool switching = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("g"))
        {
            switching = true;
            StartCoroutine(WaitForSeconds());
            gravity *= -1;
            rb.isKinematic = false;
        }

        rb.AddForce(0, gravity, 0);

    }

    void OnCollisionEnter(Collision col)
    {
        if (!switching)
        {
            rb.isKinematic = true;
        }

    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        switching = false;
    }


}
