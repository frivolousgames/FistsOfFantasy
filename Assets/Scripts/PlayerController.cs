using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Public Variables
    
    public Vector2 forward;

    public Collider2D col;

    public LayerMask groundLayer;

    public float kickPower;

    public GameObject shadow;

    


    //float knockUp = 14f;
    //float knockBack = 9f;


    //Private Variables

    protected Animator playerAnims;

    protected AnimatorStateInfo animInfo;

    protected Rigidbody2D rb;

    protected Vector2 rbV;

    protected bool isGrounded = true;
    protected bool isWalking = false;
    protected bool isHighBlocking = false;
    protected bool isCrouching = false;
    protected bool isIdle = true;
    protected bool isDead = false;
    protected bool isKnockdown = false;
    protected bool isPast;
    public static bool finisher = false;
    protected Vector2 finisherPosition;
  
    protected float power = 30;
    protected float speed = 50f;
    protected float maxSpeed = 12f;
    protected float standingPosition;
    protected float movement;
    protected Transform self;
    protected Color bos;
    protected Color sls;

    protected Vector3 shadowX;
    protected Vector3 shadowY;

    //Vector2 jumpKick;

    public GameObject blackoutScreen;
    public GameObject spotlightScreen;
    public GameObject spotlightScreen1;

    public GameObject opponent;
    public Transform oppT;
    public Rigidbody2D oppRb;
    public Animator oppA;
    public AnimatorStateInfo oppAnimInfo;

    public GameObject rayCast;


    protected void RbMove()
    {
        if (animInfo.tagHash != Animator.StringToHash("Knockdown") && animInfo.tagHash != Animator.StringToHash("Waiting"))
        {
            if(transform.localScale.x > 0)
            {
                movement = Input.GetAxis("Horizontal");
            }
            else
            {
                movement = -Input.GetAxis("Horizontal");
            }
           
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
    }

    protected void IsWalking()
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

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)  && isGrounded) //&& animInfo.tagHash != Animator.StringToHash("Knockdown") && animInfo.tagHash != Animator.StringToHash("Waiting"))
        {
            rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
        }
    }
    protected void LowKick()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnims.SetTrigger("Low Kick");

        }
    }

    protected void HighKick()
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

    protected void LowPunch()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerAnims.SetTrigger("Low Punch");
           
        }
    }

    protected void HighPunch()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerAnims.SetTrigger("High Punch");
           
        }
    }


    protected void HighBlock()
    {
        if (Input.GetKey(KeyCode.Backslash))
        {
            isHighBlocking = true;
        }
        else
        {
            isHighBlocking = false;
        }
    }

    protected void Crouch()
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




    protected void Freeze()
    {
       if(isGrounded == true && isWalking != true && isIdle != true)
        {
            speed = 0f;
            rbV.x = 0;
            rb.drag = 20;
        }
       
        else
        {
            //Debug.Log("unfroze");
            speed = 50f;
            rb.drag = .5f;
        }
    }


    protected void IsIdle()
    {
       
        if(animInfo.tagHash == Animator.StringToHash("Idle"))
        {
            isIdle = true;
            
        }
        else
        {
            isIdle = false;
           
        }

    }


    protected void VelocityClamp()
    {
        rbV = new Vector2(Mathf.Clamp(rbV.x, -maxSpeed, maxSpeed), rbV.y);
        rb.velocity = rbV;
    }


    protected void IsKnockdown()
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


    protected void FlipSprite()
    {
        if (isPast == true)
        {
            if (isGrounded == true && isCrouching == false /*&& animInfo.tagHash == Animator.StringToHash("Walking")*/)
            {
                self.localScale = new Vector3(-transform.localScale.x, 1, 1);
                isPast = false;
                FlipX.isPast = false;
            }
        }
    }

    

    protected void ShadowGrow()
    {
        float t = 0.0f;
        while(t<= 1.0f)
        {
            t += 0.05f * Time.deltaTime;
            if(this.transform.localScale.x > 0)
            {
                shadow.transform.localScale = Vector3.Lerp(shadowX, shadowY, t);
            }
            else
            {
                shadow.transform.localScale = Vector3.Lerp(new Vector3(-shadowX.x, shadowX.y, 0), shadowY, t);
            }
            
        }
       
    }

    protected void ShadowShrink()
    {
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += 0.05f * Time.deltaTime;
            if (this.transform.localScale.x > 0)
            {
                shadow.transform.localScale = Vector3.Lerp(shadowY, shadowX, t);
            }
            else
            {
                shadow.transform.localScale = Vector3.Lerp(new Vector3(-shadowY.x, shadowY.y, 0), shadowX, t);
            }
        }
      
    }

    protected void FinisherCheck()
    {
        if(Finisher.fAcceptor == "Player")
        {
            finisher = true;
            StartCoroutine(FinisherReset());
        }
    }

    IEnumerator FinisherReset()
    {
        yield return null;
        Finisher.fAcceptor = null;
        finisher = false;
    }

    protected void SetFinisherPosition(Vector2 finisherPosition)
    {
        if (OpponentController.isOppFinisher == true)
        {
            if (transform.localScale.x > 0)
            {
                transform.position = finisherPosition;
            }
            else
            {
                transform.position = new Vector3(-finisherPosition.x, finisherPosition.y);
            }
        }

    }
}
