using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    public Transform player;
    float shadowX;
    public float offset = -5;


	void Start () {
		
	}
	
	void Update ()
    {

        shadowX = player.position.x - player.position.x;
        gameObject.transform.position = new Vector2(player.position.x, shadowX + offset);
	}
}
