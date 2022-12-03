using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoundSettings : MonoBehaviour {
    GameObject player;
    GameObject opponent;
    Animator playerAnim;
    Animator oppAnim;
    Rigidbody2D pRB;
    Rigidbody2D oRB;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        opponent = GameObject.FindGameObjectWithTag("Opponent");
        playerAnim = player.GetComponent<Animator>();
        oppAnim = opponent.GetComponent<Animator>();
        pRB = player.GetComponent<Rigidbody2D>();
        oRB = opponent.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(PlayerHealth.isDead == true)
        {
            playerAnim.speed = .4f;
            pRB.gravityScale = 1.8f;
            pRB.mass = 2f;
            pRB.angularDrag = 6.8f;

            oppAnim.speed = .4f;
            oRB.gravityScale = 1.8f;
            oRB.mass = 2f;
            oRB.angularDrag = 6.8f;

        }
        else
        {
            playerAnim.speed = 1f;
            pRB.gravityScale = 5.2f;
            pRB.mass = 1f;
            pRB.angularDrag = .05f;

            oppAnim.speed = 1f;
            oRB.gravityScale = 5.2f;
            oRB.mass = 1f;
            oRB.angularDrag = .05f;
        }
    }
}
