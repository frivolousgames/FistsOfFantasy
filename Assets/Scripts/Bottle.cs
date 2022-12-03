using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {

    public float speed;
    float rPower;
    Animator anim;
    Rigidbody2D rb;
    int detachTime;
    public int detachWait = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        rPower = 5;
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
        
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, 1f * rPower);
        
            detachTime++;
            if (detachTime > detachWait)
            {
                transform.parent = null;
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("BottleCollider"))
        {
            anim.SetTrigger("Hit");
            rPower = 0f;
            rb.velocity = Vector3.zero;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
