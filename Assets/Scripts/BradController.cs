using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradController : PlayerController {

    public GameObject smoke;
    public Transform smokeSpawn;

    public GameObject hitBurst;
    public Transform hitBurstSpawn;

    Transform brad;

    bool isBassGroove;

    private void Awake()
    {
        finisherPosition = new Vector2(-4.72f, -1.942f);
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
        brad = this.transform;
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
            BassGroove();
            if (isGrounded == true && isCrouching != true)
            {
                VapeAttack();
                BassSmash();
            }
        }
        IsIdle();
        IsWalking();
        


        Freeze();
        FlipSprite();
        IsKnockdown();
        IsBassGroove();

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

    void VapeAttack()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (animInfo.tagHash != Animator.StringToHash("Vape"))
            {
                playerAnims.SetTrigger("Vape");

            }
        }
    }

    void Smoke()
    {
        Instantiate(smoke, smokeSpawn.position, smoke.transform.rotation, smokeSpawn);
    }

    void BassSmash()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (animInfo.tagHash != Animator.StringToHash("BassSmash"))
            {
                playerAnims.SetTrigger("BassSmash");

            }
        }
    }

    void HitBurstInstantiate()
    {
        Instantiate(hitBurst, hitBurstSpawn.position, hitBurstSpawn.rotation);

    }

    void IsBassGroove()
    {
        if (animInfo.tagHash == Animator.StringToHash("BassGroove"))
        {
            isBassGroove = true;
        }
        else
        {
            isBassGroove = false;
        }
    }

    void BassGroove()
    {
        //if (Input.GetKeyDown(KeyCode.Y) && isGrounded == true && isCrouching == false && isBassGroove != true)
        if (finisher == true)
        {

            BassSpot();
        }
    }

    void BassSpot()
    {
        Instantiate(blackoutScreen, new Vector3(0f, 3.45f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        if (brad.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
           
        }
        if (brad.localScale.x < 0)
        {
            Instantiate(spotlightScreen1, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            
        }
        StartCoroutine(BassGrooveController());

    }
    IEnumerator BassGrooveController()
    {
        yield return new WaitForSeconds(1.0f);
        playerAnims.SetTrigger("BassGroove");
    }


}
