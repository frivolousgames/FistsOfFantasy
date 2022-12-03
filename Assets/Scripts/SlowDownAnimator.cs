using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownAnimator : MonoBehaviour {

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(PlayerHealth.isDead == true)
        {
            anim.speed = .4f;
        }
    }
}
