using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public GameObject rightPlatform;
    public GameObject leftPlatform;

    public Rigidbody rightPlatformRigidbody;
    public Rigidbody leftPlatformRigidbody;

    public BasicButton basicButton;
    public bool activated;
    public bool armed;

    private void Update()
    {
        if (!activated && basicButton.triggered)
        {
            activated = true;
        }
    }

    private void FixedUpdate()
    {
        if (activated && !armed)
        {
            rightPlatformRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            leftPlatformRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

            armed = true;
        } 
    }
}
