using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : Flammable
{
    public ParticleSystem fire;
    public ParticleSystem fireSparks;
    public GameObject wick;
    public Timescale timescale;
    public float explosionRadius;
    public float explosionPower;

    private void Start()
    {
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

        if (beginLit)
        {
            LightDynamite();
        }
        else
        {
            ExtinguishDynamite(false);
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
                ExtinguishDynamite(false);
                BlowUpDynamite();
            }
        }

    }

    public void BlowUpDynamite()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionPower, explosionPosition, explosionRadius, 3.0f);
            }
        }
        transform.position = new Vector3(100f, 100f, 100f);
    }

    public void LightDynamite()
    {
        var emission = fire.emission;
        emission.enabled = true;
        emission = fireSparks.emission;
        emission.enabled = true;
        lit = true;

    }

    public void ExtinguishDynamite(bool resetBurnProgess)
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
