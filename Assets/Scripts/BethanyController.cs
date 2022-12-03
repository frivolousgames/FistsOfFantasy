using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BethanyController : PlayerController {

    public GameObject mShot;
    public Transform mShotSpawn;

    public GameObject hitBurst;
    public Transform hitBurstSpawn;

    Transform bethany;


    public bool isTambourine;

    private void Awake()
    {
        finisherPosition = new Vector2(-4.72f, -2.102f);
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
        bethany = this.transform;
        opponent = GameObject.FindGameObjectWithTag("Opponent");
        oppA = opponent.GetComponent<Animator>();
        rayCast = GameObject.FindGameObjectWithTag("Raycast");

        shadowX = shadow.transform.localScale;
        shadowY = new Vector3(shadowX.x + 0.5f, shadowX.y, 0);
    }

    private void Update()
    {

        //inherteted
        if (PlayerHealth.isDead != true)
        {
            HighBlock();
            LowKick();
            HighKick();
            HighPunch();
            LowPunch();
            Crouch();
            Jump();

            MicShot();
            Whip();

            Tambourine();
        }
        IsIdle();
        IsWalking();
        HighBlock();
        LowKick();
        HighKick();
        HighPunch();
        LowPunch();
        Crouch();
        Jump();

        MicShot();
        Whip();

        Freeze();
        FlipSprite();
        IsKnockdown();
        IsTambo();
        

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

    void MicShot()
    {
        if (Input.GetKeyDown(KeyCode.G) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("MicShot"))
            {
                playerAnims.SetTrigger("MicShot");
            }
            

        }
    }

    void ShotInstantiate()
    {
        Instantiate(mShot, mShotSpawn.position, mShotSpawn.rotation, bethany);
    }

    void Whip()
    {
        if (Input.GetKeyDown(KeyCode.H) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("Whip"))
            {
                playerAnims.SetTrigger("Whip");
            }
            

        }
    }
    void HitBurstInstantiate()
    {
        Instantiate(hitBurst, hitBurstSpawn.position, hitBurstSpawn.rotation);

    }

    void IsTambo()
    {
        if (animInfo.tagHash == Animator.StringToHash("Tambourine"))
        {
            isTambourine = true;
        }
        else
        {
            isTambourine = false;
        }
    }

    void Tambourine()
    {
        if (finisher == true)
        {

            TamboSpot();
        }
    }

    void TamboSpot()
    {
        Instantiate(blackoutScreen, new Vector3(0f, 3.45f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        if (bethany.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(0f, -0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
           
        }
        if (bethany.localScale.x < 0)
        {
            Instantiate(spotlightScreen1, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            
        }
        StartCoroutine(KeyController());

    }
    IEnumerator KeyController()
    {
        yield return new WaitForSeconds(1.2f);
        playerAnims.SetTrigger("Tambourine");
    }


}
