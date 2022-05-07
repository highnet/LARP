using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetizable : MonoBehaviour
{

    public float interactionRange;
    float maxInteractionStrenght;

    private void Start()
    {
        maxInteractionStrenght = 200f;
    }

    private void FixedUpdate()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange);

        foreach (Collider col in hitColliders)
        {
            if (col.transform.root != gameObject.transform.root)
            {


                foreach (BarMagnet magnet in col.gameObject.GetComponents<BarMagnet>())
                {

                    // add force to southpole
                    Vector3 forceComponent = (magnet.transform.position - transform.root.position).normalized * magnet.interactionStrenght / Vector3.SqrMagnitude(transform.root.position - magnet.transform.position);
                    
                    forceComponent = Vector3.ClampMagnitude(forceComponent, maxInteractionStrenght);

                    GetComponent<Rigidbody>().AddForce(forceComponent);
                }



            }


        }


    }
}
