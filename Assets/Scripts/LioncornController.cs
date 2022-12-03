using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LioncornController : PlayerController {

    

    public GameObject hitBurst;
    public Transform hitBurstSpawn;

    public GameObject horseLeg;
    Transform horseLegSpawn;

    public GameObject spikes;
    public Transform spikeSpawn;
    public Vector3 mirageOffset;

    public GameObject mirage;
    Transform mirageSpawn;
    public Vector3 legOffset;

    

    Vector2 kickBack;

    Transform lion;

    bool isBassGroove;

    public int spearSpeed = 5;
    bool flying = false;

    private void Awake()
    {
        finisherPosition = new Vector2(-4.72f, -1.162f);
        finisher = false;
    }

    private void Start()
    {
        horseLegSpawn = GameObject.FindGameObjectWithTag("HorseLegSpawn").transform;
        mirageSpawn = GameObject.FindGameObjectWithTag("MirageSpawn").transform;
        //inherited
        playerAnims = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        isWalking = false;
        isHighBlocking = false;
        forward = new Vector2(.01f, 0f);
        self = transform;
        lion = this.transform;
        opponent = GameObject.FindGameObjectWithTag("Opponent");

        shadowX = shadow.transform.localScale;
        shadowY = new Vector3(shadowX.x + .7f, shadowX.y, 0);
        
        
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

            if (isGrounded == true && isCrouching != true)
            {
                MirageCall();
                SkyHorse();
                Spear();
                IsSpearFly();
                SpearFly();
                GroundPound();
            }
        }

            IsIdle();
        IsWalking();
        
        
        //BassGroove();

        
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
        Freeze();
    }

    void SkyHorse()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (animInfo.tagHash != Animator.StringToHash("SkyHorse"))
            {
                playerAnims.SetTrigger("SkyHorse");
            }
        }
    }

    public void HorseLegSpawn()
    {
        if(lion.localScale.x > 0)
        {
            legOffset = new Vector3(opponent.transform.position.x + 6, horseLegSpawn.position.y, 0f);

        }
        else
        {
            legOffset = new Vector3(opponent.transform.position.x - 6, horseLegSpawn.position.y, 0f);

        }
        Instantiate(horseLeg, legOffset, horseLegSpawn.rotation, lion);
    }
        

    void MirageCall()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (animInfo.tagHash != Animator.StringToHash("MirageCall"))
            {
                if(GameObject.FindGameObjectWithTag("Mirage") == null)
                {
                    playerAnims.SetTrigger("MirageCall");
                }
               
            }
        }
    }

    public void MirageSpawn()
    {
        if(lion.transform.position.x > 0)
        {
            mirageOffset = new Vector3(opponent.transform.position.x - 3, mirageSpawn.position.y, 0f);
        }
        else
        {
            mirageOffset = new Vector3(opponent.transform.position.x + 3, mirageSpawn.position.y, 0f);
        }
        Instantiate(mirage, mirageOffset, mirageSpawn.rotation, lion);
    }

    

    void Spear()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (animInfo.tagHash != Animator.StringToHash("Spear"))
            {
                playerAnims.SetTrigger("Spear");

            }
        }
    }

    public void IsSpearFly()
    {
        if(animInfo.tagHash == Animator.StringToHash("Spear"))
        {
            flying = true;
        }

        else
        {
            flying = false;
        }
    }
    void SpearFly()
    {
        if (flying == true)
        {
            StartCoroutine("FlyWait");
        }
    }
    IEnumerator FlyWait()
    {
        yield return new WaitForSeconds(.2f);
        if (transform.localScale.x > 0)
        {
            rb.AddForce(Vector2.right * spearSpeed);
        }
        else
        {
            rb.AddForce(-Vector2.right * spearSpeed);
        }
    }

    void GroundPound()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (animInfo.tagHash != Animator.StringToHash("GroundPound"))
            {
                playerAnims.SetTrigger("GroundPound");

            }
        }
    }

    public void SpikeSpawn()
    {
        Instantiate(spikes, spikeSpawn.position, spikeSpawn.rotation, lion);
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
        if (Input.GetKeyDown(KeyCode.Y) && isGrounded == true && isCrouching == false && isBassGroove != true)
        {

            BassSpot();
        }
    }

    void BassSpot()
    {
        Instantiate(blackoutScreen, new Vector3(0f, 3.45f, 0f), new Quaternion(0f, 0f, 0f, 0f));

        if (lion.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            
        }
        if (lion.localScale.x < 0)
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
