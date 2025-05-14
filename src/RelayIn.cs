using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayIn : ConnectionPoint
{
    public float connectionRange;
    public RelayOut relayOut;




    public void TryMakeNewConnections()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, connectionRange);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Outlet")
            {
                Outlet outlet = colliders[i].GetComponent<Outlet>();
                TryMakeNewConnection(outlet);

            }
            else if (colliders[i].tag == "Relay Out")
            {
                RelayOut relayOutCollided = colliders[i].GetComponent<RelayOut>();
                TryMakeNewConnection(relayOutCollided, new bool[] {relayOutCollided != this.relayOut , relayOutCollided.relayIn.connectedTo != null});

            }
        }
    }

    private void Update()
    {
        ResetConnections();
        TryMakeNewConnections();

    }

}
