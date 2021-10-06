using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Particles : MonoBehaviour
{
    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
