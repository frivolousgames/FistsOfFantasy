using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisController : PlayerController {

    public GameObject mBomb;
    public Transform mBombSpawn;

    public GameObject hitBurst;
    public Transform hitBurstSpawn;

    public GameObject arrow;
    public Transform arrowSpawn;

    public GameObject phantom;
    public Transform phantomSpawn;


    Transform chris;


    public bool isMicFreeze;

    private void Awake()
    {
        finisherPosition = new Vector2(-4.72f, -2.041f);
        finisher = false;
    }

    private void Start()
    {
        //inherited
        playerAnims = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        isWalking = false;
        isHighBlocking = false;
        forward = new Vector2(.01f, 0f);
        self = transform;
        chris = this.transform;
        opponent = GameObject.FindGameObjectWithTag("Opponent");
        oppA = opponent.GetComponent<Animator>();
        rayCast = GameObject.FindGameObjectWithTag("Raycast");
        shadowX = shadow.transform.localScale;
        shadowY = new Vector3(shadowX.x + .5f, shadowX.y, 0);
    }

    private void Update()
    {

        //inherteted
        if (PlayerHealth.isDead != true)
        {
            Jump();
            HighBlock();
            LowKick();
            HighKick();
            HighPunch();
            LowPunch();
            Crouch();

            Bow();
            MicBomb();
            MicFreeze();

        }


        IsIdle();
        
        IsWalking();
        

        Freeze();
        FlipSprite();
        IsKnockdown();
        IsMicFreeze();

        FinisherCheck();
        SetFinisherPosition(finisherPosition);

        rbV = rb.velocity;

        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);

        playerAnims.SetBool("jumping", !isGrounded);
        playerAnims.SetBool("isWalking", isWalking);
        playerAnims.SetBool("isHighBlocking", isHighBlocking);
        playerAnims.SetBool("isCrouching", isCrouching);

        isPast = FlipX.isPast;
    }

    private void FixedUpdate()
    {
        if (PlayerHealth.isDead != true)
        {
            RbMove();
        }

        isGrounded = Physics2D.IsTouchingLayers(col, groundLayer);
        VelocityClamp();

       
    }

    void MicFreeze()
    {
        //if (Input.GetKeyDown(KeyCode.Y) && isGrounded == true && isCrouching == false)
        if (finisher == true)
        {
            if (animInfo.tagHash != Animator.StringToHash("MicFreeze"))
            {
                MicSpot();
            }
            

        }
    }

    void MicBombInstantiate()
    {
        Instantiate(mBomb, mBombSpawn.position, mBombSpawn.rotation, chris);
    }

    void MicBomb()
    {
        if (Input.GetKeyDown(KeyCode.H) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("MicBomb"))
            {
                playerAnims.SetTrigger("MicBomb");
            }
            

        }
    }

    void Bow()
    {
        if (Input.GetKeyDown(KeyCode.G) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("Bow"))
            {
                playerAnims.SetTrigger("Bow");
            }


        }
    }

    void ArrowInstantiate()
    {
        Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation, chris);
    }
    
    void HitBurstInstantiate()
    {
        Instantiate(hitBurst, hitBurstSpawn.position, hitBurstSpawn.rotation);

    }

    void IsMicFreeze()
    {
        if (animInfo.tagHash == Animator.StringToHash("MicFreeze"))
        {
            isMicFreeze = true;
        }
        else
        {
            isMicFreeze = false;
        }
    }

    void MicSpot()
    {
        Instantiate(blackoutScreen, new Vector3(0f, 3.45f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        if (chris.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
           
        }
        if (chris.localScale.x < 0)
        {
            Instantiate(spotlightScreen1, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            
        }
        StartCoroutine(KeyController());

    }
    IEnumerator KeyController()
    {
        yield return new WaitForSeconds(1f);
        playerAnims.SetTrigger("MicFreeze");
    }

    void Phantom()
    {
        Instantiate(phantom, phantomSpawn.position, phantomSpawn.rotation, chris);
    }

}
