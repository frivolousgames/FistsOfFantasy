using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSmoke : MonoBehaviour {

    ParticleSystem.MainModule smoke;
    float a = 1.75f;
    float b = 0f;
    float t = 5f;
    

    private void Start()
    {
        smoke = GetComponent<ParticleSystem>().main;
        
    }


    private void Update()
    {
        if(transform.parent == null)
        {
            smoke.startLifetime = b;
        }
    }
}
