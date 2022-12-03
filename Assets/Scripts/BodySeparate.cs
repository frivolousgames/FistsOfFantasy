using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySeparate : MonoBehaviour {

    public Rigidbody2D rb;
    public float downForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Body")
        {
            rb.AddForce(Vector2.down * downForce);
        }
    }
}
