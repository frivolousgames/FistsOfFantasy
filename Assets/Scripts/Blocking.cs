using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blocking : MonoBehaviour {

    Rigidbody2D otherCollider;
    Rigidbody2D rb;
    GameObject enemy;

    public float force = 5;
    public float upForce = 100;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();

        if(transform.parent.tag == "Player")
        {
            enemy = GameObject.FindGameObjectWithTag("Opponent");
        }
        else
        {
            enemy = GameObject.FindGameObjectWithTag("Player");
        }

        otherCollider = enemy.GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform.parent != this.transform.parent)
        {
            if (other.gameObject != GameObject.FindGameObjectWithTag("FlipCollider") ||
            other.gameObject != GameObject.FindGameObjectWithTag("Body") ||
            other.gameObject != GameObject.FindGameObjectWithTag("InAir"))
            {
                rb.AddForce(Vector2.up * upForce);
                if (enemy.transform.localScale.x > 0)
                {
                    otherCollider.AddForce(Vector2.left * force);

                }
                else
                {
                    otherCollider.AddForce(Vector2.right * force);
                }

            }
        }
        
    }
}
