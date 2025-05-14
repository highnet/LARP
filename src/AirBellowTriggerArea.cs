using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBellowTriggerArea : MonoBehaviour
{

    public AirBellow airBellow;

    private void OnTriggerEnter(Collider other)
    {
        airBellow.BlowAir();
    }

}
