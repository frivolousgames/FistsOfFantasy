using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicStay : MonoBehaviour {

    public LayerMask groundLayer;
    bool isGrounded;
    BoxCollider2D col;
    Rigidbody2D rb;
    CapsuleCollider2D cap;
    private void Awake()
    {
        col = this.GetComponent<BoxCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        cap = this.GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
    
        isGrounded = Physics2D.IsTouchingLayers(col, groundLayer);
        if(isGrounded == true)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            cap.isTrigger = true;
            this.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, Mathf.Lerp(transform.rotation.z, 178f, .5f), 0f);
        }
    }

}
