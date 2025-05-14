using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarMagnet : MonoBehaviour
{


    public GameObject northPole;
    public GameObject southPole;

    public float interactionRange;
    public float interactionStrenght;

    float maxInteractionStrenght;

    // Start is called before the first frame update
    void Start()
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

                    // add force to northpole
                    Vector3 forceComponent = (magnet.southPole.transform.position - northPole.transform.position).normalized * magnet.interactionStrenght / Vector3.SqrMagnitude(northPole.transform.position - magnet.southPole.transform.position);
                    forceComponent += (magnet.northPole.transform.position - northPole.transform.position).normalized * -magnet.interactionStrenght / Vector3.SqrMagnitude(northPole.transform.position - magnet.northPole.transform.position);

                    forceComponent = Vector3.ClampMagnitude(forceComponent, maxInteractionStrenght);

                    GetComponent<Rigidbody>().AddForceAtPosition(forceComponent, northPole.transform.position);

                    // add force to southpole
                    forceComponent = (magnet.northPole.transform.position - southPole.transform.position).normalized * magnet.interactionStrenght / Vector3.SqrMagnitude(southPole.transform.position - magnet.northPole.transform.position);
                    forceComponent += (magnet.southPole.transform.position - southPole.transform.position).normalized * -magnet.interactionStrenght / Vector3.SqrMagnitude(southPole.transform.position - magnet.southPole.transform.position);

                    forceComponent = Vector3.ClampMagnitude(forceComponent, maxInteractionStrenght);

                    GetComponent<Rigidbody>().AddForceAtPosition(forceComponent, southPole.transform.position);
                }



            }


                foreach (Magnetizable magnetizable in col.gameObject.GetComponents<Magnetizable>())
                {

                    
                    Vector3 forceComponent = (magnetizable.transform.root.position - transform.root.position).normalized * interactionStrenght / Vector3.SqrMagnitude(transform.root.position - magnetizable.transform.root.position);

                    forceComponent = Vector3.ClampMagnitude(forceComponent, maxInteractionStrenght);

                    GetComponent<Rigidbody>().AddForce(forceComponent);
                }

            


        }


    }
}
