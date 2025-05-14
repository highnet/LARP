using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoxingGloveRod : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public BasicButton basicButton;
    public new bool enabled;
    public Vector3 punchDirection;
    public float punchStrength;
    public Timescale timescale;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer  == 3)
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

    }

    private void FixedUpdate()
    {
        if (timescale.timeState == Timescale.TimeState.Playing && !enabled && basicButton.triggered)
        {
            rigidbody.AddForce(punchDirection * punchStrength);
            enabled = true;
        }
    }

}
