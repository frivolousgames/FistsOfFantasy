using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTestMoves : MonoBehaviour {

    //Public Variables

    public Vector2 forward;

    public Collider2D col;

    public LayerMask groundLayer;

    public float kickPower;
    public float knockUp;
    public float knockBack;


    //Private Variables

    Animator playerAnims;

    AnimatorStateInfo animInfo;

    Rigidbody2D rb;

    Vector2 rbV;
    Vector2 knockdown;

    bool isGrounded = true;
    bool isWalking = false;
    bool isHighBlocking = false;
    bool isCrouching = false;
    bool isIdle = true;
    bool isDead = false;
    bool isKnockdown = false;


    float power = 21;
    float speed = 50f;
    float maxSpeed = 12f;
    float standingPosition;
    float movement;

    //Vector2 jumpKick;





    private void Start()
    {
        playerAnims = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        isWalking = false;
        isHighBlocking = false;
        forward = new Vector2(.01f, 0f);



        //jumpKick = new Vector2(2f, 0f);

    }

    private void Update()
    {
        IsIdle();
        IsWalking();
        //HighBlock();
        //LowKick();
        //HighKick();
        //HighPunch();
        //LowPunch();
        //Crouch();
        Freeze();
        Knockdown();
        IsKnockdown();

        rbV = rb.velocity;

        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);

        playerAnims.SetBool("jumping", !isGrounded);
        playerAnims.SetBool("isWalking", isWalking);
        playerAnims.SetBool("isHighBlocking", isHighBlocking);
        playerAnims.SetBool("isCrouching", isCrouching);
        playerAnims.SetBool("IsDead", isDead);



    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(col, groundLayer);
        VelocityClamp();
        //RbMove();
        //Jump();

    }

    void RbMove()
    {
        movement = Input.GetAxis("Horizontal");
        playerAnims.SetFloat("movement", movement);

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector2.right * speed);
        }
    }

    void IsWalking()
    {

        if (animInfo.tagHash == Animator.StringToHash("Walking"))
        {
            isWalking = true;

        }
        else
        {
            isWalking = false;

        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        }
    }
    void LowKick()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnims.SetTrigger("Low Kick");

        }
    }

    void HighKick()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerAnims.SetTrigger("High Kick");
            /*if(isGrounded != true)
            {
                rb.AddForce(jumpKick * kickPower, ForceMode2D.Impulse);
            }*/

        }

    }

    void LowPunch()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerAnims.SetTrigger("Low Punch");

        }
    }

    void HighPunch()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerAnims.SetTrigger("High Punch");

        }
    }


    void HighBlock()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            isHighBlocking = true;

        }
        else
        {
            isHighBlocking = false;

        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.S))
        {
            isCrouching = true;

        }
        else
        {
            isCrouching = false;
        }
    }


    void Freeze()
    {
        if (isGrounded == true && isWalking != true && isIdle != true)
        {
            speed = 0f;
            rbV.x = 0;
            rb.drag = 5;
        }
        if (isKnockdown == true)
        {
            speed = 0f;
        }
        else
        {
            speed = 50f;
            rb.drag = .5f;
        }
    }


    void IsIdle()
    {

        if (animInfo.tagHash == Animator.StringToHash("Idle"))
        {
            isIdle = true;

        }
        else
        {
            isIdle = false;

        }

    }


    void VelocityClamp()
    {
        rbV = new Vector2(Mathf.Clamp(rbV.x, -maxSpeed, maxSpeed), rbV.y);
        rb.velocity = rbV;
    }

    void Knockdown()
    {
        knockdown = new Vector2(-1 * knockBack, 1 * knockUp);
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerAnims.SetTrigger("Knockdown");
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.AddForce(knockdown, ForceMode2D.Impulse);

        }
    }
    void IsKnockdown()
    {
        if (animInfo.tagHash == Animator.StringToHash("Knockdown"))
        {
            isKnockdown = true;

        }
        else
        {
            isKnockdown = false;

        }
    }
}
