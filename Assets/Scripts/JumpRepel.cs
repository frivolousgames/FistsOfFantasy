using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRepel : MonoBehaviour {

    Rigidbody2D rb;
    public float force;
    Vector2 direction;
    GameObject[] cols;
    bool isTouching = false;
    float t = 0;

    private void Awake()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        cols = GameObject.FindGameObjectsWithTag("JumpRepel");
    }
    private void Update()
    {
        
        if(isTouching == true)
        {
            Vector2 direction = new Vector2(transform.parent.localScale.x, 0);
            
            t += .001f;
            Vector2 amount = Vector2.Lerp(Vector2.zero, direction * force, t);
            rb.AddForce(amount);
            Debug.Log("Touching " + amount);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        foreach(GameObject col in cols)
        {
            if(other.gameObject == col)
            {
                if (col.transform.parent != this.transform.parent)
                {
                    if(this.transform.parent.localPosition.y > 0f)
                    {
                        isTouching = true;
                    }

                }
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (GameObject col in cols)
        {
            if (other.gameObject == col)
            {
                if (col.transform.parent != this.transform.parent)
                {
                    isTouching = false;
                    t = 0f;
                }
            }

        }
    }
}
