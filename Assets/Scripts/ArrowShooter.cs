using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour {

    public float speed;
   
    void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-1f, 1f, 0f) * Random.Range(speed - 2, speed);
    }
	
	
}
