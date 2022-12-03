using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Color carColor;
    Rigidbody2D rb;
    public float speed;

    void Start()
    {
        //carColor = new Vector4();
        rb = GetComponent<Rigidbody2D>();

        //GetComponent<SpriteRenderer>().color = carColor;

        
    }
    void Update()
    {
        if (OpponentController.isOppFinisher == true)
        {
            Destroy(gameObject);
        }

        if(PlayerHealth.isDead == true)
        {
            speed = speed / 2;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(-transform.parent.localScale.x * speed, 0f, 0f);
    }
}
