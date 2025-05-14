using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTraveller : MonoBehaviour
{
   public float portalTravelTimer;
   public float portalTravelCooldown;

    private void Update()
    {
        if (portalTravelTimer < 0)
        {
            portalTravelTimer = 0;
        }
        else
        {
            portalTravelTimer -= Time.unscaledDeltaTime;
        }
    }
}

