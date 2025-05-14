using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : ConnectionPoint
{
    public ParticleSystem electricityConnection;
    public ParticleSystem electricityIdle;

    private void Update()
    {

        UpdateElectricityParticleSystems();

    }

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
}
