using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    public List<Collider> colliders;

    // Start is called before the first frame update
    void Start()
    {
        Collider thisCollider = GetComponent<Collider>();
        for(int i = 0; i < colliders.Count; i++)
        {
            Physics.IgnoreCollision(thisCollider, colliders[i]);
        }
    }
}
