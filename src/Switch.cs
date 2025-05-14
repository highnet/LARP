using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject switchFlipper;
    public bool activated;
    public MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (switchFlipper.transform.eulerAngles.z >= 145f)
        {
            activated = true;
            meshCollider.isTrigger = true;
        } else
        {
            activated = false;
            meshCollider.isTrigger = false;

        }
    }

}
