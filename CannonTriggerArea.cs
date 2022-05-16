using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTriggerArea : MonoBehaviour
{

    public float strength;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.attachedRigidbody != null)
        {
            Debug.Log("attached body is not null");

            other.attachedRigidbody.AddForce(-transform.right * strength);
            Debug.Log("adding force");

        }
    }
}
