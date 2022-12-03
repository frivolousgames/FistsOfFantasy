using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JordanController : PlayerController
{

    public GameObject lasers;
    public Transform laserSpawn;

    public GameObject laserShot;
    public Transform laserShotSpawn;
    float shotRandom;

    public GameObject hitBurst;
    public Transform hitBurstSpawn;

    public GameObject missiles;
    public Transform missileSpawn;

    Transform jordan;

    public bool isCyborg;

    private void Awake()
    {
        finisherPosition = new Vector2(-4.72f, -1.825f);
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
        jordan = this.transform;
        opponent = GameObject.FindGameObjectWithTag("Opponent");
        oppA = opponent.GetComponent<Animator>();
        rayCast = GameObject.FindGameObjectWithTag("Raycast");

        shadowX = shadow.transform.localScale;
        shadowY = new Vector3(shadowX.x + .5f, shadowX.y, 0);


    }

    private void Update()
    {

        //inherteted
        if(PlayerHealth.isDead != true)
        {
            HighBlock();
            LowKick();
            HighKick();
            HighPunch();
            LowPunch();
            Crouch();
            Jump();

            LaserFace();
            KeyMissile();
            Cyborg();
        }
        IsIdle();
        IsWalking();
        


        FlipSprite();
        IsKnockdown();
        IsCyborg();

        FinisherCheck();
        SetFinisherPosition(finisherPosition);

        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);

        playerAnims.SetBool("jumping", !isGrounded);
        playerAnims.SetBool("isWalking", isWalking);
        playerAnims.SetBool("isHighBlocking", isHighBlocking);
        playerAnims.SetBool("isCrouching", isCrouching);

        isPast = FlipX.isPast;

        //Debug.Log("Finisher " + finisher);

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(col, groundLayer);
        if(PlayerHealth.isDead != true)
        {
            RbMove();
        }
        rbV = rb.velocity;
        VelocityClamp();
        
        Freeze();
    }

    void LaserFace()
    {
        if (Input.GetKeyDown(KeyCode.G) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("LaserFace"))
            {
                playerAnims.SetTrigger("LaserFace");
            }


        }
    }

    void Lasers()
    {
        Instantiate(lasers, laserSpawn.position, laserSpawn.rotation, jordan);
    }

    void LaserShot()
    {
        if(jordan.localScale.x > 0f)
        {
            shotRandom = Random.Range(-12f, -5.5f);
        }
        else
        {
            shotRandom = Random.Range(12f, 5.5f);
        }
        
        laserShotSpawn.eulerAngles = new Vector3(laserShotSpawn.rotation.x, laserShotSpawn.rotation.y, shotRandom);
        Instantiate(laserShot, laserShotSpawn.position, laserShotSpawn.rotation, jordan);
    }
    void HitBurstInstantiate()
    {
        Instantiate(hitBurst, hitBurstSpawn.position, hitBurstSpawn.rotation);

    }

    void KeyMissile()
    {
        if (Input.GetKeyDown(KeyCode.H) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("KeyMissile"))
            {
                playerAnims.SetTrigger("KeyMissile");
            }


        }
    }

    void MissileSpawn()
    {
        Instantiate(missiles, missileSpawn.position, missileSpawn.rotation, jordan);

    }

    void IsCyborg()
    {
        if (animInfo.tagHash == Animator.StringToHash("Cyborg"))
        {
            isCyborg = true;
        }
        else
        {
            isCyborg = false;
        }
    }

    void Cyborg()
    {
        //if (Input.GetKeyDown(KeyCode.Y) && isGrounded == true && isCrouching == false && isCyborg != true)
        if (finisher == true)
        {
            CyborgSpot();
        }
    }

    void CyborgSpot()
    {
        Instantiate(blackoutScreen, new Vector3(0f, 3.45f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        if (jordan.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        }
        if (jordan.localScale.x < 0)
        {
            Instantiate(spotlightScreen1, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        }
        StartCoroutine(CyborgController());

    }
    IEnumerator CyborgController()
    {
        yield return new WaitForSeconds(1.0f);
        playerAnims.SetTrigger("Cyborg");
    }

    
}


