using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDelay : MonoBehaviour {

    public float speed = 0;
    Rigidbody2D rb;
    float startTime;
    float duration = 2;
    float t;

    float detachTime;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //SmokeMove();
        speed = 0f;
        startTime = Time.time;
    }

    private void Update()
    {
        t = (Time.time - startTime) / duration;
        SmokeMove();
        detachTime++;
        if (detachTime > 20)
        {
            transform.parent = null;
        }
    }

    void SmokeMove()
    {
        speed = Mathf.SmoothStep(0f, 10f, t);
        if(transform.parent != null)
        {
            if (transform.parent.localScale.x > 0)
            {
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = -transform.right * speed;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        
        //StartCoroutine(SmokeSpeed());
    }
 
}
