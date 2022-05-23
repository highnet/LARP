using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : ConnectionPoint
{
    public new Renderer renderer;
    public Material offMaterial;
    public Material onMaterial;
    public float connectionRange;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }



    public void TryMakeNewConnections()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, connectionRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Outlet")
            {
                Outlet outlet = colliders[i].GetComponent<Outlet>();
                TryMakeNewConnection(outlet);

            }
            else if (colliders[i].tag == "Relay Out")
            {
                RelayOut rleayOutCollided = colliders[i].GetComponent<RelayOut>();
                TryMakeNewConnection(rleayOutCollided, new bool[] {rleayOutCollided.relayIn.connectedTo != null} );

            }
        }
    }

    public void UpdateMaterial()
    {
        if (connectedTo != null)
        {
            renderer.material = onMaterial;
        }
        else
        {
            renderer.material = offMaterial;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ResetConnections();
        TryMakeNewConnections();
        UpdateMaterial();



    }

}
