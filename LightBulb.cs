using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public new Renderer renderer;
    public Material offMaterial;
    public Material onMaterial;
    public GameObject connectedTo;
    public float connectionRange;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (connectedTo != null)
        {
            if (connectedTo.GetComponent<Outlet>() != null)
            {
                connectedTo.GetComponent<Outlet>().connectedTo = null;
            } else if (connectedTo.GetComponent<RelayOut>() != null)
            {
                connectedTo.GetComponent<RelayOut>().connectedTo = null;
            }
        }

        connectedTo = null;

        Collider[] colliders = Physics.OverlapSphere(transform.position, connectionRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Outlet")
            {
                Outlet outlet = colliders[i].GetComponent<Outlet>();
                if (connectedTo == null && outlet.connectedTo == null)
                {
                    outlet.connectedTo = this.gameObject;
                    connectedTo = colliders[i].gameObject;
                }
            }
            else if (colliders[i].tag == "Relay Out")
            {
                RelayOut relayOut = colliders[i].GetComponent<RelayOut>();
                if (connectedTo == null && relayOut.connectedTo == null && relayOut.relayIn.connectedTo != null)
                {
                    relayOut.connectedTo = this.gameObject;
                    connectedTo = colliders[i].gameObject;
                }
            }
        }

        if (connectedTo != null)
        {
            renderer.material = onMaterial;
        } else
        {
            renderer.material = offMaterial;
        }
    }

}
