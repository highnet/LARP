using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltTriggerArea : MonoBehaviour
{
    public float strength;
    public bool reverse;
    public new bool enabled;

    public GameObject[] arrows;

    private void OnTriggerStay(Collider other)
    {
        if (enabled)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce((reverse ? Vector3.right : Vector3.left) * strength);
        }
    }

    private void FixedUpdate()
    {

        if (enabled)
        {

            if (reverse)
            {
                arrows[0].gameObject.SetActive(false);
                arrows[1].gameObject.SetActive(false);
                arrows[2].gameObject.SetActive(true);
                arrows[3].gameObject.SetActive(true);
                arrows[2].transform.RotateAround(arrows[2].transform.position, new Vector3(0f, 0f, -1f), strength);
                arrows[3].transform.RotateAround(arrows[3].transform.position, new Vector3(0f, 0f, -1f), strength);
            } else
            {
                arrows[0].gameObject.SetActive(true);
                arrows[1].gameObject.SetActive(true);
                arrows[2].gameObject.SetActive(false);
                arrows[3].gameObject.SetActive(false);
                arrows[0].transform.RotateAround(arrows[0].transform.position, new Vector3(0f, 0f, 1f), strength);
                arrows[1].transform.RotateAround(arrows[1].transform.position, new Vector3(0f, 0f, 1f), strength);
            }

        }
    }
}
