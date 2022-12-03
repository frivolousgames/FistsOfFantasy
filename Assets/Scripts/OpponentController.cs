using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    //Public Variables

    public Vector2 forward;

    public Collider2D col;

    public LayerMask groundLayer;

    public float kickPower;

    public GameObject shadow;

    public static bool isOppFinisher = false;
    protected bool oppFinished;
    protected Vector2 finishedPosition;

    //float knockUp = 14f;
    //float knockBack = 9f;


    //Private Variables

    protected GameObject player;

    protected Animator playerAnims;

    protected AnimatorStateInfo animInfo;

    protected Rigidbody2D rb;

    protected Vector2 rbV;

    protected bool isGrounded = true;
    protected bool isWalking = false;
    protected bool isCrouching = false;
    protected bool isIdle = true;
    protected bool isDead = false;
    protected bool isKnockdown = false;
    protected bool isPast;
    protected bool isNear;
    protected bool isFar;
    protected bool isRange;
    protected bool isBehind;
    protected bool rangeAlreadyRunning;
    protected bool farAlreadyRunning;
    protected bool nearAlreadyRunning;
    protected bool walkingForward;
    protected bool jumpTime = true;
    
    protected bool frozen = false;
    protected bool keyAttacking = false;

    protected float power = 21;
    protected float speed = .5f;
    protected float maxSpeed = 2f;
    protected float standingPosition;
    protected float movement;
    protected Vector3 shadowX;
    protected Vector3 shadowY;

    protected int behindTime;
    protected int rangeDelay = 0;
    protected Transform self;
    protected Color bos;
    protected Color sls;

    protected GameObject opponent;
    protected Animator oppA;
    protected AnimatorStateInfo oppAnimInfo;



    //Blocking

    protected bool highAttacking;
    protected bool lowAttacking;
    protected bool isHighBlocking = false;
    protected bool isLowBlocking = false;

    protected int hiHit;
    protected int hiHitTotal;
    protected int loHit;
    protected int loHitTotal;

    protected GameObject[] shots;
    protected List<GameObject> oppShots;
    public float shotOffset = 3;
    protected bool shotBlocking;

    protected GameObject[] energies;
    protected List<GameObject> oppEnergies;
    public float energyOffset = 3;
    protected bool energyBlocking;

    //Jordan

    public Transform explosionSpawn;
    public GameObject explosion;

    //Brad

    public Transform ampSpawn;
    public GameObject amp;

    public GameObject finisherCollider;

    //Lioncorn

    public GameObject horseLeg;
    public Transform horseLegSpawn;

    //Vector2 jumpKick;

    private void Start()
    {

    }

    private void Update()
    {


    }

    protected void DistanceCheck()
    {
        if (isFar == true && frozen != true)
        {
            if (farAlreadyRunning == false)
            {
                FarAttack();
                farAlreadyRunning = true;
            }
        }
        if (isNear == true)
        {
            
            if (nearAlreadyRunning == false)
            {
                NearAttack();
                nearAlreadyRunning = true;
            }
        }
        if (isRange == true)
        {
            if (rangeAlreadyRunning == false)
            {
                RangeAttack();
                rangeAlreadyRunning = true;
            }
        }


    }

    public virtual void RangeAttack()
    {
        Debug.Log("There is no shot attack for this character");
    }

    public virtual void FarAttack()
    {
        Debug.Log("There is no far attack for this character");
    }

    public virtual void NearAttack()
    {
        Debug.Log("There is no near attack for this character");
    }



    protected void MoveR()
    {
        playerAnims.SetFloat("movement", movement);
        rb.AddForce(Vector2.right * speed);
    }

    protected void MoveL()
    {
        playerAnims.SetFloat("movement", movement);
        rb.AddForce(-Vector2.right * speed, ForceMode2D.Force);
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
        if(animInfo.tagHash != Animator.StringToHash("HighPunch") ||
           animInfo.tagHash != Animator.StringToHash("LowPunch") ||
           animInfo.tagHash != Animator.StringToHash("HighKick") ||
           animInfo.tagHash != Animator.StringToHash("LowKick") ||
           animInfo.tagHash != Animator.StringToHash("JumpHighPunch") ||
           animInfo.tagHash != Animator.StringToHash("JumpLowPunch") ||
           animInfo.tagHash != Animator.StringToHash("JumpHighKick") ||
           animInfo.tagHash != Animator.StringToHash("JumpLowKick") ||
           animInfo.tagHash != Animator.StringToHash("GuitarShot") ||
           animInfo.tagHash != Animator.StringToHash("Energy"))
        {
            if (isGrounded == true && frozen != true && isKnockdown == false && isCrouching != true)
            {
                rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);

            }
        }
           
    }
    protected void LowKick()
    {


        playerAnims.SetTrigger("Low Kick");


    }

    protected void HighKick()
    {

        playerAnims.SetTrigger("High Kick");


    }

    protected void LowPunch()
    {

        playerAnims.SetTrigger("Low Punch");

    }

    protected void HighPunch()
    {

        playerAnims.SetTrigger("High Punch");

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
        isCrouching = true;
        StartCoroutine(CrouchHoldTime());
    }
    IEnumerator CrouchHoldTime()
    {
        if (isCrouching == true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            isCrouching = false;
        }
    }

    protected void JumpHighKick()
    {
        Jump();
        HighKick();
    }
    protected void JumpLowKick()
    {
        Jump();
        LowKick();
    }
    protected void JumpHighPunch()
    {
        Jump();
        HighPunch();
    }
    protected void JumpLowPunch()
    {
        Jump();
        LowPunch();
    }
    protected void CrouchHighKick()
    {
        Crouch();
        HighKick();
    }
    protected void CrouchLowKick()
    {
        Crouch();
        LowKick();

    }
    protected void CrouchHighPunch()
    {
        Crouch();
        HighPunch();

    }
    protected void CrouchLowPunch()
    {
        Crouch();
        LowPunch();

    }

    protected void WalkForward()
    {
        if (animInfo.tagHash != Animator.StringToHash("GuitarShot") ||
              animInfo.tagHash != Animator.StringToHash("Energy"))
        {
            if(walkingForward == true && frozen != true && isKnockdown == false)
            {
                playerAnims.SetFloat("movement", .2f);
                rb.AddForce((player.transform.position - transform.position) * speed);
                StartCoroutine("FarMoveDelay");
            }
        }

    }

    IEnumerator FarMoveDelay()
    {
        if (jumpTime == true)
        {
            JumpHighKick();
            jumpTime = false;
            if (jumpTime == false)
            {
                yield return new WaitForSeconds(2f);
                jumpTime = true;
            }
        }

    }


    public virtual void SpecialA()
    {
        Debug.Log("There is no special A for this character");
    }

    public virtual void SpecialB()
    {
        Debug.Log("There is no special B for this character");
    }




    protected void Freeze()
    {
        if (isGrounded == true && isWalking != true && isIdle != true)
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

        if (animInfo.tagHash == Animator.StringToHash("Idle"))
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
            behindTime++;
            if (isGrounded == true && isCrouching == false && behindTime > 25)
            {
                //StartCoroutine("FlipX");
                self.localScale = new Vector3(-transform.localScale.x, 1, 1);
                isPast = false;
                FlipXOpponent.isPast = false;
                behindTime = 0;
            }
        }
    }

    protected IEnumerator ShadowGrow()
    {
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += 0.1f * Time.deltaTime;
            if (this.transform.localScale.x > 0)
            {
                shadow.transform.localScale = Vector3.Lerp(shadowX, shadowY, t);
            }
            else
            {
                shadow.transform.localScale = Vector3.Lerp(new Vector3(-shadowX.x, shadowX.y, 0), shadowY, t);
            }

        }
        yield return null;
    }

    protected IEnumerator ShadowShrink()
    {
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += 0.1f * Time.deltaTime;
            if (this.transform.localScale.x > 0)
            {
                shadow.transform.localScale = Vector3.Lerp(shadowY, shadowX, t);
            }
            else
            {
                shadow.transform.localScale = Vector3.Lerp(new Vector3(-shadowY.x, shadowY.y, 0), shadowX, t);
            }
        }
        yield return null;
    }

    IEnumerator FlipX()
    {
        yield return new WaitForSeconds(.5f);
        self.localScale = new Vector3(-transform.localScale.x, 1, 1);
        isPast = false;
        FlipXOpponent.isPast = false;
    }


    //Blocking

    protected void IsHighAttack()
    {
        if(oppAnimInfo.tagHash == Animator.StringToHash("HighPunch")||
            oppAnimInfo.tagHash == Animator.StringToHash("LowPunch")||
            oppAnimInfo.tagHash == Animator.StringToHash("JumpHighPunch")||
            oppAnimInfo.tagHash == Animator.StringToHash("JumpHighKick") ||
            oppAnimInfo.tagHash == Animator.StringToHash("JumpLowPunch") ||
            oppAnimInfo.tagHash == Animator.StringToHash("JumpLowKick"))
        {
            highAttacking = true;

        }
        else
        {
            highAttacking = false;
        }
    }

    protected void IsLowAttack()
    {
        if (oppAnimInfo.tagHash == Animator.StringToHash("HighKick") ||
            oppAnimInfo.tagHash == Animator.StringToHash("LowKick") ||
            oppAnimInfo.tagHash == Animator.StringToHash("CrouchLowKick") ||
            oppAnimInfo.tagHash == Animator.StringToHash("CrouchHighKick") ||
            oppAnimInfo.tagHash == Animator.StringToHash("CrouchLowPunch") ||
            oppAnimInfo.tagHash == Animator.StringToHash("CrouchHihjPunch"))
        {
            lowAttacking = true;
        }
        else
        {
            lowAttacking = false;
        }
    }

    protected void IsShot()
    {
        oppShots = new List<GameObject>();
        if(shots != null)
        {
            foreach (GameObject shot in shots)
            {
                if (this.transform.localScale.x > 0 && shot.transform.localScale.x < 0 ||
                    this.transform.localScale.x < 0 && shot.transform.localScale.x > 0)
                {
                    oppShots.Add(shot);
                }
            }
        }
        if (oppShots != null)
        {
            foreach (GameObject oppShot in oppShots)
            {
                if(this.transform.localScale.x < 0)
                {
                    if (oppShot.transform.position.x > this.transform.position.x - shotOffset)
                    {
                        shotBlocking = true;
                    }
                    if (oppShot.transform.position.x > this.transform.position.x)
                    {
                        shotBlocking = false;
                    }
                }
                else
                {
                    if (oppShot.transform.position.x < this.transform.position.x + shotOffset)
                    {
                        shotBlocking = true;
                    }
                    if (oppShot.transform.position.x < this.transform.position.x)
                    {
                        shotBlocking = false;
                    }
                }
                
            }
        }
        if(oppShots.Count <= 0)
        {
            shotBlocking = false;
            
        }
    }
    protected void IsEnergy()
    {
        oppEnergies = new List<GameObject>();

        if (energies != null)
        {
            foreach (GameObject energy in energies)
            {
                if (energy.transform.parent != this.transform)
                {
                    oppEnergies.Add(energy);
                }
            }
        }
        if (oppEnergies != null)
        {
            foreach (GameObject oppEnergy in oppEnergies)
            {
                if (this.transform.localScale.x < 0)
                {
                    if (oppEnergy.transform.position.x > this.transform.position.x - energyOffset)
                    {
                        energyBlocking = true;
                    }
                    if (oppEnergy.transform.position.x > this.transform.position.x)
                    {
                        energyBlocking = false;
                    }
                }
                else
                {
                    if (oppEnergy.transform.position.x < this.transform.position.x + energyOffset)
                    {
                        energyBlocking = true;
                    }
                    if (oppEnergy.transform.position.x < this.transform.position.x - energyOffset)
                    {
                        energyBlocking = false;
                    }
                }

            }
        }
        if (oppEnergies.Count <= 0)
        {
            energyBlocking = false;
            
        }
    }

    protected void ShotBlock()
    {
        if(shotBlocking == true)
        {
            StopCoroutine("FarRoutine");
            StopCoroutine("RangeRoutine");
            StopCoroutine("NearRoutine");
            ResetTriggers();
            isHighBlocking = true;
            StartCoroutine("BlockHold");
        }
        else
        {

        }
    }

    protected void EnergyBlock()
    {
        if (energyBlocking == true)
        {
            StopCoroutine("FarRoutine");
            StopCoroutine("RangeRoutine");
            StopCoroutine("NearRoutine");
            ResetTriggers();
            isHighBlocking = true;
            StartCoroutine("BlockHold");
        }
        else
        {
            
        }
    }

    protected void HighBlocking()
    {
        if (isNear == true)
        {
            if (highAttacking == true)
            {
                StopCoroutine("NearRoutine");
                ResetTriggers();
                isHighBlocking = true;
                StartCoroutine("BlockHold");
            }
        }
          
    }

    protected void LowBlocking()
    {
        if(isNear == true)
        {
            if (lowAttacking == true)
            {
                StopCoroutine("NearRoutine");
                ResetTriggers();
                isCrouching = true;
                if (isCrouching == true)
                {

                    StartCoroutine("BlockHold");
                }
            }
        }
        
    }

    protected void CrouchBlocking()
    {
        isHighBlocking = true;
    }

    protected void HiHitCount()
    {
        int hitTime = (int)(hiHit + Time.deltaTime);
        int singleHit = 0;
        if(animInfo.tagHash == Animator.StringToHash("HiHit"))
        {
            singleHit = 1;
        }
        else
        {
            singleHit = 0;
        }

        hiHit += singleHit;

        //if()
        if(hitTime != 0 && hiHit != 0)
        {
            Debug.Log("HIHItTime: " + hitTime + ":" + hiHit);

        }
    }

    IEnumerator BlockHold()
    {
        StartCoroutine("BlockWait");
        yield return new WaitForSeconds(.3f);
        isHighBlocking = false;
        isCrouching = false;
        nearAlreadyRunning = false;
        farAlreadyRunning = false;
        rangeAlreadyRunning = false;
    }

    IEnumerator BlockWait()
    {
        yield return new WaitForSeconds(.1f);
        isHighBlocking = true;
    }

    //Special Move Stuff

    void Wait(string player)
    {
        PowerUps.spawn = false;
        

        /*if (opponent.transform.localScale.x > 0f)
        {
            transform.localPosition = new Vector3(2.5f, -1.41f, 0f);
        }
        else
        {
            transform.localPosition = new Vector3(-2.5f, -1.41f, 0f);
        }*/

        ResetTriggers();

        switch (player)
        {
            case "Jordan":
                Glow();
                break;

            case "Chris":
                FreezeGlow();
                break;

            case "Phil":
                KeyAttack();
                break;

            case "Bethany":
                HeadExplode();
                break;

            case "Brad":
                Amp();
                break;

        }
    }

    public virtual void ResetTriggers()
    {

    }

    protected void OppFinisher()
    {
        if (isOppFinisher == true)
        {
            StartCoroutine(FinishedWait());
        }

        else
        {
            isOppFinisher = false;
        }
    }

    IEnumerator FinishedWait()
    {
        yield return new WaitForSeconds(1f);
        Wait(opponent.name);
    }

    protected void SetFinishedPosition(Vector2 finishedPosition)
    {
        if(isOppFinisher == true)
        {
            if (opponent.transform.localScale.x > 0f)
            {
                transform.localPosition = finishedPosition;
            }
            else
            {
                transform.localPosition = new Vector3(-finishedPosition.x, finishedPosition.y);
            }
        }
    }

    //Jordan

    protected void Glow()
    {
        if(oppFinished == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("CyborgGlow"))
            {
                playerAnims.SetTrigger("CyborgGlow");
                oppFinished = true;
            }
        }
    }

    void Explode()
    {
        Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation, null);
    }

    //Brad

    protected void Amp()
    {
        if (oppFinished == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("AmpSmash"))
            {
                frozen = true;
                playerAnims.SetTrigger("AmpSmash");
                oppFinished = true;
            }
        }
            
    }

    void AmpDrop()
    {
        Instantiate(amp, ampSpawn.position, ampSpawn.rotation, null);
    }

    //Bethany

    protected void HeadExplode()
    {
        if (oppFinished == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("HeadExplode"))
            {
                playerAnims.SetTrigger("HeadExplode");
                oppFinished = true;

            }
        }
    }

    void FinisherCollider()
    {
        Instantiate(finisherCollider, explosionSpawn.position, explosionSpawn.rotation, null);
    }

    //Chris

    protected void FreezeGlow()
    {
        if (oppFinished == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("FreezeGlow"))
            {
                playerAnims.SetTrigger("FreezeGlow");
                oppFinished = true;

            }
        }
    }

    //Phil

    protected void KeyAttack()
    {
        if (oppFinished == false)
        {
            if (animInfo.tagHash != Animator.StringToHash("KeyAttack"))
            {
                playerAnims.SetTrigger("KeyAttack");
                oppFinished = true;
            }
        }
    }
    protected void IsKeyAttacking()
    {
        if(oppAnimInfo.tagHash == Animator.StringToHash("Keyboard"))
        {
            keyAttacking = true;
        }
        
    }

    //Lioncorn

    void HorseStomp()
    {
        if(oppAnimInfo.tagHash == Animator.StringToHash("SkyHorse"))
        {
            Instantiate(horseLeg, horseLegSpawn.position, horseLeg.transform.rotation, null);
        }
    }
}
