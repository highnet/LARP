using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Portal otherPortal;
    public Transform parent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base Ball")
        {
            PortalTraveller portalTraveller = other.GetComponent<PortalTraveller>();
            if (portalTraveller.portalTravelTimer <= 0)
            {
                other.transform.position = otherPortal.transform.position;
                Rigidbody rigidbody = other.GetComponent<Rigidbody>();
                Vector3 inVelocity = rigidbody.velocity;
                Vector3 outVelocity = otherPortal.parent.transform.right * inVelocity.magnitude;
                rigidbody.velocity = outVelocity;
                portalTraveller.portalTravelTimer = portalTraveller.portalTravelCooldown;
            }


        }
    }

}
