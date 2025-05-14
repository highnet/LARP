using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : ConnectionPoint
{
    public new Renderer renderer;
    public Material offMaterial;
    public Material onMaterial;
    public float connectionRange;
    public float angularSpeed;
    public bool reversed;

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
                RelayOut relayOut = colliders[i].GetComponent<RelayOut>();
                TryMakeNewConnection(relayOut, new bool[] {relayOut.relayIn.connectedTo != null });

            }
        }
    }

    public void UpdateMaterial()
    {
        if (connectedTo != null)
        {
            renderer.material = onMaterial;
            transform.Rotate(0f, 0f, (reversed ? 1f : -1f) * angularSpeed * Time.deltaTime, Space.Self);
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

