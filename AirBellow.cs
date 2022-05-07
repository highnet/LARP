using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBellow : MonoBehaviour
{
    public GameObject topHandle;
    public GameObject bottomHandle;
    public AirBellowTriggerArea triggerArea;
    public AirBellowAirZone airZone;
    public Vector3 blowDirection;
    public float blowStrength;

    public void BlowAir()
    {
        airZone.BlowAir();
    }
}
