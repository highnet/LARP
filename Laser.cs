using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject emitter;
    public Timescale timeScale;

    LineRenderer beamRenderer;

    // Start is called before the first frame update
    void Start()
    {
        beamRenderer = GetComponent<LineRenderer>();
        timeScale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();
    }


    private void FixedUpdate()
    {

        beamRenderer.positionCount = 1;
        beamRenderer.SetPosition(0, emitter.transform.position);

        if (timeScale.timeState == Timescale.TimeState.Playing) { 
        PropagateLaser(emitter.transform.position, transform.right);
        }

    }

    public void PropagateLaser(Vector3 origin, Vector3 direction)
    {
        RaycastHit hit;

        int layerMask = 1 << 6;

        if (Physics.Raycast(origin, direction, out hit, 50, ~layerMask))
        {
            beamRenderer.positionCount += 1;

            beamRenderer.SetPosition(beamRenderer.positionCount - 1, hit.point);
            if (hit.rigidbody != null)
            {

                if (hit.rigidbody.gameObject.layer == 7 && beamRenderer.positionCount < 10)
                {
                    PropagateLaser(hit.point, Vector3.Reflect(direction, hit.normal));

                }
            }

        }


    }
}
