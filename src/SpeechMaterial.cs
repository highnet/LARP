using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechMaterial : MonoBehaviour
{
    private new Renderer renderer;
    public Color baseColor;
    public AudioSourceSampleData audioSourceSampleData;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", baseColor);

    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetFloat("_Shininess", audioSourceSampleData.clipLoudness * 10);
    }

    private void FixedUpdate()
    {

    }
}
