using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCollider : MonoBehaviour {

    ParticleSystem ps;
    Collider2D col;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }
}
