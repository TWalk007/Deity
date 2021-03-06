﻿using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rb;

    public float movementSpeed;

    private void Start()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 200 * Time.deltaTime * movementSpeed, ForceMode.Force);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -200 * Time.deltaTime * movementSpeed, ForceMode.Force);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-200 * Time.deltaTime * movementSpeed, 0, 0, ForceMode.Force);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(200 * Time.deltaTime * movementSpeed, 0, 0, ForceMode.Force);
        }
    }
}
