using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanWindZoneTriggerArea : MonoBehaviour
{
    public Fan fan;
    public Collider windZone;
    public ParticleSystem wind;
    public Vector3 blowDirection;
    public float blowStrength;

    private void Update()
    {
        if (fan.connectedTo != null)
        {
            Collider[] colliders = Physics.OverlapBox(this.transform.position, windZone.bounds.size / 2);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].tag == "Balloon")
                {
                    colliders[i].attachedRigidbody.AddForce(blowDirection * blowStrength);
                }
            }

            var windEmission = wind.emission;
            wind.Emit(5);
        }
    }
}
