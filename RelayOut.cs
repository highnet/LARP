using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayOut : MonoBehaviour
{

    public GameObject connectedTo;
    public ParticleSystem electricityConnection;
    public RelayIn relayIn;

    private void Update()
    {

        if (connectedTo != null)
        {
            electricityConnection.gameObject.transform.LookAt(connectedTo.transform);
        }
        else
        {
            electricityConnection.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
