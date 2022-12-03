using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhilOpponentController : OpponentController
{
    public GameObject gShot;
    public Transform gShotSpawn;

    public GameObject eWave;
    public Transform eWaveSpawn;

    public GameObject keys;
    public Transform keySpawn;

    public GameObject blackoutScreen;
    public GameObject spotlightScreen;
    public Transform slt;

    Vector3 keyMovePosition;
    Vector3 spotPosition;

    List<NearMoves> nearMoves;
    List<FarMoves> farMoves;

    bool nearDelay;


    Transform phil;

    public delegate void NearMoves();
    public delegate void FarMoves();

    private void Awake()
    {
        finishedPosition = new Vector2(2.5f, -1.41f);
        isOppFinisher = false;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        keyMovePosition = new Vector3(4.72f, -1.41f, 0f);
        spotPosition = new Vector3(-.4f, -2.03f, 0f);

        nearMoves = new List<NearMoves>();
        NearMovesList();

        farMoves = new List<FarMoves>();
        FarMovesList();

        //inherited
        playerAnims = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        isWalking = false;
        isHighBlocking = false;
        forward = new Vector2(.01f, 0f);
        self = transform;
        phil = this.transform;

        opponent = GameObject.FindGameObjectWithTag("Player");
        oppA = opponent.GetComponent<Animator>();

        shadowX = shadow.transform.localScale;
        shadowY = new Vector3(shadowX.x + .5f, shadowX.y, 0);

        //Blocking

       
    }

    private void Update()
    {
        isFar = RaycastDistance.isFar;
        isNear = RaycastDistance.isNear;
        isRange = RaycastDistance.isRange;
        isBehind = RaycastDistance.isBehind;
        if(PlayerHealth.isDead != true)
        {
            DistanceCheck();

        }

        slt = spotlightScreen.transform;

        IsWalking();
        
        FlipSprite();
        IsKnockdown();

        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);
        oppAnimInfo = oppA.GetCurrentAnimatorStateInfo(0);

        playerAnims.SetBool("jumping", !isGrounded);
        playerAnims.SetBool("isWalking", isWalking);
        playerAnims.SetBool("isHighBlocking", isHighBlocking);
        playerAnims.SetBool("isCrouching", isCrouching);
        playerAnims.SetBool("isOppFinisher", isOppFinisher);

        isPast = FlipXOpponent.isPast;

        //Finisher
       
        OppFinisher();
        if (PlayerController.finisher == true)
        {
            isOppFinisher = true;
        }
        SetFinishedPosition(finishedPosition);

        //Blocking

        IsHighAttack();
        IsLowAttack();
        HighBlocking();
        LowBlocking();

        //HiHitCount();

        shots = GameObject.FindGameObjectsWithTag("Shot");
        IsShot();

        energies = GameObject.FindGameObjectsWithTag("Energy");
        IsEnergy();

        ShotBlock();
        EnergyBlock();


    }

    private void FixedUpdate()
    {
        rbV = rb.velocity;
        isGrounded = Physics2D.IsTouchingLayers(col, groundLayer);
        Freeze();
        VelocityClamp();
        WalkForward();
        
    }

    public override void RangeAttack()
    {
        StartCoroutine("RangeRoutine");
    }


    IEnumerator RangeRoutine()
    {
        while (isRange == true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            GuitarShot();
            rangeDelay ++;
            
            if(rangeDelay > 4 && isIdle && isGrounded == true)
            {
                walkingForward = true;
            }
            
            if(isRange == false)
            {
                rangeAlreadyRunning = false;
                StopCoroutine("RangeRoutine");
                ResetTriggers();
                rangeDelay = 0;
            }
        }
    }

    public override void FarAttack()
    {
        StartCoroutine("FarRoutine");
        
    }

    IEnumerator FarRoutine()
    {
        while (isFar == true)
        {
            yield return new WaitForSeconds(Random.Range(.1f, .7f));
            walkingForward = true;

            if (isFar == false || animInfo.tagHash == Animator.StringToHash("Waiting"))
            {
                walkingForward = false;
                farAlreadyRunning = false;
                playerAnims.SetFloat("movement", 0f);
                StopCoroutine("FarRoutine");
                ResetTriggers();
            }
        }
    }

    public override void NearAttack()
    {
        if(isHighBlocking != true)
        {
            StartCoroutine("NearRoutine");
        }
        
    }

    IEnumerator NearRoutine()
    {
        
        while (isNear == true)
        {
            yield return new WaitForSeconds(Random.Range(.1f, .3f));
            NearAttackMoves();
           
            

            if (isNear == false)
            {
                nearAlreadyRunning = false;
                StopCoroutine("NearRoutine");
                ResetTriggers();

            }
        }
    }

    //Special Moves

    public override void SpecialA()
    {
        GuitarShot();
    }

    public override void SpecialB()
    {
        EnergyWave();
    }

    void GuitarShot()
    {
        if (animInfo.tagHash != Animator.StringToHash("GuitarShot"))
        {
            playerAnims.SetTrigger("GuitarShot");
        }
    }


    void ShotInstantiate()
    {
        Instantiate(gShot, gShotSpawn.position, gShotSpawn.rotation, phil);
    }

    IEnumerator ShotWait()
    {
        yield return new WaitForSeconds(.8f);
        Instantiate(gShot, gShotSpawn.position, gShotSpawn.rotation, phil);

    }

    void Energy()
    {
        playerAnims.SetTrigger("Energy");

    }  
    void Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.Y) && isGrounded == true && isCrouching == false)
        {

            KeyboardSpot();
        }
    }

    void EnergyWave()
    {
        Instantiate(eWave, eWaveSpawn.position, gShotSpawn.rotation, this.transform);

        //rb.AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
    }
    void KeyToss()
    {
        Instantiate(keys, keySpawn.position, gShotSpawn.rotation, phil);
    }

    void KeyboardSpot()
    {
        //bos.a = 255f;
        //sls.a = 167f;
        Instantiate(blackoutScreen, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
        if (phil.localScale.x > 0)
        {
            Instantiate(spotlightScreen, new Vector3(-.4f, -2.03f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            transform.position = new Vector3(-4.72f, -1.41f, 0f);
        }
        else
        {
            Instantiate(spotlightScreen, new Vector3(.4f, -2.03f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            slt.localScale = new Vector3(-slt.localScale.x, slt.localScale.y, slt.localScale.z);
            transform.position = new Vector3(4.72f, -1.41f, 0f);
        }
        StartCoroutine(KeyController());

    }
    IEnumerator KeyController()
    {
        yield return new WaitForSeconds(1.2f);
        playerAnims.SetTrigger("Keyboard");
    }

    void NearMovesList()
    {
        nearMoves.Add(HighKick);
        nearMoves.Add(LowKick);
        nearMoves.Add(HighPunch);
        nearMoves.Add(LowPunch);
        nearMoves.Add(JumpHighKick);
        nearMoves.Add(JumpLowKick);
        nearMoves.Add(JumpHighPunch);
        nearMoves.Add(JumpLowPunch);
        nearMoves.Add(GuitarShot);
        nearMoves.Add(Energy);
        nearMoves.Add(Crouch); 
    }

    //Attack Zones:

    //Near

    private void NearAttackMoves()
    {
        if(nearMoves == null)
        {
            Debug.Log("null");
            return;
        }

        else
        {

            StartCoroutine("NearMoveDelay");
        }
        
    }

    IEnumerator NearMoveDelay()
    {
        if(nearDelay == false)
        {
            nearMoves[Random.Range(0, nearMoves.Count)]();
            nearDelay = true;
            if (nearDelay == true)
            {
                yield return new WaitForSeconds(.5f);
                nearDelay = false;
            }
        }

    }

    void FarMovesList()
    {
        farMoves.Add(MoveL);
    }

    /*private void FarAttackMoves()
    {
        if (farMoves == null)
        {
            Debug.Log("null");
            return;
        }

        else
        {
            farMoves[Random.Range(0, farMoves.Count - 1)]();
            //nearMoves[0]();
            Debug.Log("Far moves : " + farMoves.Count);
        }

    }*/
    void FarAttackMoves()
    {
        walkingForward = true;
        WalkForward();
    }

    public override void ResetTriggers()
    {
        playerAnims.ResetTrigger("Low Punch");
        playerAnims.ResetTrigger("Low Kick");
        playerAnims.ResetTrigger("High Punch");
        playerAnims.ResetTrigger("High Kick");
        playerAnims.ResetTrigger("Energy");
        playerAnims.ResetTrigger("GuitarShot");
        playerAnims.ResetTrigger("Keyboard");
        playerAnims.ResetTrigger("JumpHit");
        playerAnims.ResetTrigger("LoHit");
        playerAnims.ResetTrigger("HiHit");
        playerAnims.SetBool("jumping", false);
        playerAnims.SetFloat("movement", 0.0f);
    }






}



