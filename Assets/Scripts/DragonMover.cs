using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMover : MonoBehaviour {

    Rigidbody2D rb;
    public float boost;
    public float turningBoost;
    float rotationBoost = 0f;
    public float rAmount;
    Animator anim;
    AnimatorStateInfo animInfo;
    bool isTurning = false;
    public float turningX;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
       
    }

    void Start()
    {
        rb.velocity = Vector2.right * boost;
        rb.rotation = 0f;
    }

    private void Update()
    {
        anim.SetBool("isTurning", isTurning);
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
    }

    private void FixedUpdate()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("DragonEdge"))
        {
            rotationBoost += rAmount * Time.deltaTime;
            rb.rotation = Mathf.Lerp(0f, 100f, rotationBoost);
            rb.velocity = new Vector2((rb.velocity.x - Time.deltaTime), (1f * turningBoost));
            isTurning = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("DragonEdge"))
        {
            rb.rotation = (0f);
            rb.velocity = Vector2.left * boost;
            isTurning = false;
        }
    }

    
}
