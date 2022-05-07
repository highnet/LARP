using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float speed;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * speed);
    }
}
