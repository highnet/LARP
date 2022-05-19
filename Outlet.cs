using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : MonoBehaviour
{

    public GameObject connectedTo;

    public ParticleSystem electricityConnection;
    public ParticleSystem electricityIdle;

    private void Update()
    {
        if (connectedTo != null)
        {
            electricityConnection.gameObject.transform.LookAt(connectedTo.transform);
        } else
        {
            electricityConnection.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
