using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilController : PlayerController {

    public GameObject gShot;
    public Transform gShotSpawn;

    public GameObject eWave;
    public Transform eWaveSpawn;

    public GameObject keys;
    public Transform keySpawn;

   
    Transform phil;
    
    public bool isKeyboard;

    private void Awake()
    {
        finisherPosition = new Vector2(-4.72f, -1.391f);
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
        phil = this.transform;
        opponent = GameObject.FindGameObjectWithTag("Opponent");
        oppA = opponent.GetComponent<Animator>();
        rayCast = GameObject.FindGameObjectWithTag("Raycast");

        shadowX = shadow.transform.localScale;
        shadowY = new Vector3(shadowX.x + .5f, shadowX.y, 0);

    }

    private void Update()
    {
        if (PlayerHealth.isDead != true)
        {
            HighBlock();
            LowKick();
            HighKick();
            HighPunch();
            LowPunch();
            Crouch();
            Jump();

            GuitarShot();
            Energy();
            Keyboard();
        }

        

        //bos = blackoutScreen.GetComponent<SpriteRenderer>().color;
        //sls = spotlightScreen.GetComponent<SpriteRenderer>().color;


        //inherteted
        IsIdle();
        IsWalking();
        

        Freeze();
        FlipSprite();
        IsKnockdown();
        IsKeyboard();

        FinisherCheck();
        SetFinisherPosition(finisherPosition);
        //FreezeOpponent();

        rbV = rb.velocity;

        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);
        //oppAnimInfo = playerAnims.GetCurrentAnimatorStateInfo(0);

        playerAnims.SetBool("jumping", !isGrounded);
        playerAnims.SetBool("isWalking", isWalking);
        playerAnims.SetBool("isHighBlocking", isHighBlocking);
        playerAnims.SetBool("isCrouching", isCrouching);
        playerAnims.SetBool("isKeyboard", isKeyboard);

        
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


    void GuitarShot()
    {
        if (Input.GetKeyDown(KeyCode.G) && isGrounded == true && isCrouching == false)
        {

            if (animInfo.tagHash != Animator.StringToHash("GuitarShot"))
            {
                playerAnims.SetTrigger("GuitarShot");
            }
            

        }
    }

    void ShotInstantiate()
    {
        Instantiate(gShot, gShotSpawn.position, gShotSpawn.rotation, phil);
    }

    /*IEnumerator ShotWait()
    {
        if (animInfo.tagHash != Animator.StringToHash("GuitarShot"))
        {
            yield return new WaitForSeconds(.8f);
            Instantiate(gShot, gShotSpawn.position, gShotSpawn.rotation, phil);
        }

    }*/

    void Energy()
    {
        if (Input.GetKeyDown(KeyCode.H) && isGrounded == true && isCrouching == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("Energy"))
            {
                playerAnims.SetTrigger("Energy");
            }

        }
    }
    void Keyboard()
    {
        //if (Input.GetKeyDown(KeyCode.Y) && isGrounded == true && isCrouching == false && isKeyboard != true)
        if(finisher == true)
        {
            KeyboardSpot();
            StartCoroutine(FinisherBoolDelay());
        }
    }

    IEnumerator FinisherBoolDelay()
    {
        yield return new WaitForEndOfFrame();
        finisher = false;
    }

    void EnergyWave()
    {
        Instantiate(eWave, eWaveSpawn.position, gShotSpawn.rotation, phil);

        //rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
    }

    void IsKeyboard()
    {
        if (animInfo.tagHash == Animator.StringToHash("Keyboard"))
        {
            isKeyboard = true;
        }
        else
        {
            isKeyboard = false;
        }
    }
    void KeyToss()
    {
        Instantiate(keys, keySpawn.position, gShotSpawn.rotation, phil);
    }

    void KeyboardSpot()
    {
        Instantiate(blackoutScreen, new Vector3(0f, 3.45f, 0f), new Quaternion(0f, 0f, 0f, 0f));
        
        if (phil.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
           
        }
        if (phil.localScale.x < 0)
        {
            Instantiate(spotlightScreen1, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
           
        }
        StartCoroutine(KeyController());

    }
    IEnumerator KeyController()
    {
        yield return new WaitForSeconds(1.0f);
        playerAnims.SetTrigger("Keyboard");
    }

    void EndOppFinisher()
    {
        OpponentController.isOppFinisher = false;
    }
}
