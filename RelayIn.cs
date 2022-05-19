using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayIn : MonoBehaviour
{
    public GameObject connectedTo;
    public float connectionRange;
    public RelayOut relayOut;

    private void Update()
    {
        if (connectedTo != null)
        {
            if (connectedTo.GetComponent<Outlet>() != null)
            {
                connectedTo.GetComponent<Outlet>().connectedTo = null;
            } else if (connectedTo.GetComponent<RelayOut>() != null)
            {
                connectedTo.GetComponent<RelayOut>().connectedTo = null;
            }
        }

        connectedTo = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, connectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Outlet")
            {
                Outlet outlet = colliders[i].GetComponent<Outlet>();
                if (connectedTo == null && outlet.connectedTo == null)
                {
                    outlet.connectedTo = this.gameObject;
                    connectedTo = colliders[i].gameObject;
                }
            } else if (colliders[i].tag == "Relay Out")
            {
                RelayOut relayOutCollided = colliders[i].GetComponent<RelayOut>();
                if (connectedTo == null && relayOutCollided.connectedTo == null && relayOutCollided != this.relayOut && relayOutCollided.relayIn.connectedTo != null)
                {
                    relayOutCollided.connectedTo = this.gameObject;
                    connectedTo = colliders[i].gameObject;
                }
            }
        }

    }

}
