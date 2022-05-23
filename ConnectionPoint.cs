using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{

    public ConnectionPoint connectedTo;
    public bool readyToConnect;

    public void ResetConnections() {

        if (connectedTo != null)
        {
            connectedTo.GetComponent<ConnectionPoint>().connectedTo = null;
        }

        connectedTo = null;
    }


    public void TryMakeNewConnection(ConnectionPoint other, params bool[] extraConditions)
    {

        for(int i = 0; i < extraConditions.Length; i++)
        {
            if (extraConditions[i] == false)
            {
                return;
            }
        }

        if (this.connectedTo != null || other.connectedTo != null)
        {
            return;
        }


        this.connectedTo = other;
        other.connectedTo = this;
    }
}
