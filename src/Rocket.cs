using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public bool triggered;
    private Rigidbody rigidBody;
    public float speed;

    private void Start()
    {
        rigidBody = GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (triggered)
        {
            rigidBody.AddForce(rigidBody.transform.forward * speed);
        }
    }
}
