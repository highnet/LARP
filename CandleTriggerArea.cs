using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTriggerArea : MonoBehaviour
{
    public Candle candle;

    private void OnTriggerEnter(Collider other)
    {
        if (candle.lit)
        {
            if (other.gameObject.layer == 10)
            {
                if (other.gameObject.tag == "Candle")
                {
                    other.GetComponentInParent<Candle>().LightCandle();
                }
            }  else if (other.gameObject.tag == "Basket Ball")
            {
                candle.ExtinguishCandle(false);
            }
            
        }

    }
}
