using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteTriggerArea : MonoBehaviour
{
    public Dynamite dynamite;

    private void OnTriggerEnter(Collider other)
    {
        if (dynamite.lit)
        {
            if (other.gameObject.layer == 10)
            {
                if (other.gameObject.tag == "Candle")
                {
                    other.GetComponentInParent<Candle>().LightCandle();
                }
            }
            else if (other.gameObject.tag == "Basket Ball")
            {
                dynamite.ExtinguishDynamite(false);
            }

        }

    }
}
