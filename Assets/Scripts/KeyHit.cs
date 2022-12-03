using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHit : MonoBehaviour {

    Rigidbody2D rb;

    public float speed = 1;
    public float height = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "HitCollider")
        {
            Debug.Log("hitEm");
            GetComponent<BoxCollider2D>().enabled = false;
            rb.isKinematic = false;
            rb.AddForce(new Vector2(-1f * speed, 1f * height),ForceMode2D.Impulse);
        }
    }
}
