using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayOut : ConnectionPoint
{

    public ParticleSystem electricityConnection;
    public RelayIn relayIn;

    public void UpdateElectricityParticleSystems()
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

    private void Update()
    {

        UpdateElectricityParticleSystems();

    }
}
