using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Flammable
{
    public ParticleSystem fire;
    public ParticleSystem fireSparks;
    public GameObject wick;
    public Timescale timescale;


    private void Start()
    {
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

        if (beginLit)
        {
            LightCandle();
        }
        else
        {
            ExtinguishCandle(false);
        }
        StartCoroutine("CheckBurn");
    }
    public IEnumerator CheckBurn()
    {
        while (true)
        {
            yield return new WaitForSeconds(burnDuration / tickrate);
            if (lit && timescale.timeState == Timescale.TimeState.Playing)
            {
                burnProgess += (1.0f / tickrate);

                if (burnProgess > 1.0f)
                {
                    burnProgess = 1.0f;
                }
            }
        }
    }
    private void Update()
    {
        wick.transform.localPosition = new Vector3(0f, (burnProgess - 0.0f) / (1.0f - 0.0f) * (0.8f - 1.2f) + 1.2f, 0f);

        if (timescale.timeState == Timescale.TimeState.Playing)
        {
            if (lit && burnProgess >= 1.0f)
            {
                ExtinguishCandle(false);
            }
        } 

    }


    public void LightCandle()
    {
        var emission = fire.emission;
        emission.enabled = true;
        emission = fireSparks.emission;
        emission.enabled = true;
        lit = true;

    }

    public void ExtinguishCandle(bool resetBurnProgess)
    {
        if (resetBurnProgess)
        {
            burnProgess = 0.0f;
        }
        var emission = fire.emission;
        emission.enabled = false;
        emission = fireSparks.emission;
        emission.enabled = false;
        lit = false;
    }


}
