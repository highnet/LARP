using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movementVector;
    public float amplitude;
    public float frequency;
    public float phase;
    public Vector3 originalPosition;
    public float time;
    public new Rigidbody rigidbody;
    public Timescale timescale;


    public List<GameObject> contacts;

    private void OnCollisionEnter(Collision collision)
    {
        contacts.Add(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (contacts.Contains(collision.gameObject))
        {
            contacts.Remove(collision.gameObject);
        }
    }

    private void Start()
    {
        originalPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

    }

    private void FixedUpdate()
    {

        if (timescale.timeState == Timescale.TimeState.Playing)
        {
            time += Time.deltaTime;
            rigidbody.MovePosition(originalPosition + movementVector * amplitude * Mathf.Sin(2 * Mathf.PI * frequency * time + phase));

            for (int i = 0; i < contacts.Count; i++)
            {
                Rigidbody rb = contacts[i].GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(.1f * movementVector * amplitude * Mathf.Sin(2 * Mathf.PI * frequency * time + phase));
                }
            }
        }

    
    }
}
