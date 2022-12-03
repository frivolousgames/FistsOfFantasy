using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider playerHealthBar;

    Text gameTimerText;

    float maxHealth = 20f;

    float currentHealth;
    public GameObject player;


    Vector2 knockdown;

    public float knockUp = 18f;
    public float knockBack = 12f;

    public static bool isFalling;
    public static bool isDead;


    Animator playerAnims;
    AnimatorStateInfo animInfo;
    Rigidbody2D rb;

    GameObject player1;
    GameObject player2;

    Text opponentName;

    CapsuleCollider2D hitCol;
    bool isHit;
    float seconds;

    private void Awake()
    {
        isDead = true;
        isFalling = false;
    }

    private void Start()
    {
        if (transform.parent.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        }
        else
        {
            playerHealthBar = GameObject.FindGameObjectWithTag("OpponentHealthBar").GetComponent<Slider>();
        }

        gameTimerText = GameObject.FindGameObjectWithTag("GameTimerText").GetComponent<Text>();
        
        hitCol = GetComponent<CapsuleCollider2D>();
        playerHealthBar.value = maxHealth;
        currentHealth = playerHealthBar.value;
        playerAnims = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();

        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Opponent");
        opponentName = GameObject.FindGameObjectWithTag("OpponentName").GetComponent<Text>();


        
    }
    void Update()
    {
        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);
        playerAnims.SetBool("IsDead", isDead);
        currentHealth = playerHealthBar.value;
        Kill();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent != this.transform.parent)
        {
            if (other.gameObject.tag == "FootBox")
            {
                playerHealthBar.value -= .6f;
                

            }

            if (other.gameObject.tag == "PunchBox")
            {
                playerHealthBar.value -= .5f;

            }

            if (other.gameObject.tag == "FootBoxLow")
            {
                playerHealthBar.value -= .3f;

            }

            if (other.gameObject.tag == "PunchBoxLow")
            {
                playerHealthBar.value -= .2f;

            }

            if (other.gameObject.tag == "Shot")
            {
                playerHealthBar.value -= 3.2f;
                Knockdown();
            }
            if (other.gameObject.tag == "Energy")
            {
                playerHealthBar.value -= 3.2f;
                Knockdown();

            }

            if (other.gameObject.tag == "Whip")
            {
                playerHealthBar.value -= 3.2f;
                
                Knockdown();

            }

            if (other.gameObject.tag == "Keyboard")
            {
                playerHealthBar.value -= currentHealth;
                //playerAnims.SetBool("isAttacking", false);
                OpponentController.isOppFinisher = false;
                Knockdown();
            }

            if (other.gameObject.tag == "Finisher")
            {
                playerHealthBar.value -= currentHealth;

            }


        }
        isHit = true;
        hitCol.enabled = false;
        StartCoroutine(EnableColliders());

    }

    void Knockdown()
    {
        if(player.transform.localScale.x == -1)
        {
            knockdown = new Vector2(1 * knockBack, 1 * knockUp);
        }
        else
        {
            knockdown = new Vector2(-1 * knockBack, 1 * knockUp);
        }
        playerAnims.ResetTrigger("HiHit");
        playerAnims.ResetTrigger("LoHit");
        playerAnims.ResetTrigger("JumpHit");


        playerAnims.SetTrigger("Knockdown");
        rb.velocity = new Vector2(0, 0/*rb.velocity.y*/);
        rb.AddForce(knockdown, ForceMode2D.Impulse);

    }


    public void IsDead()
    {
        
        if(isDead == false)
        {
            playerAnims.ResetTrigger("Knockdown");
            isDead = true;
            playerAnims.speed = .5f;
            //Time.timeScale = .4f;
            if(animInfo.tagHash != Animator.StringToHash("Knockdown"))
            {
                Knockdown();
            }
            
        }
        
    }

    void Kill()
    {
        if (currentHealth == 0 && isDead == false)
        {
            //playerHealthBar.GetComponent<Slider>().enabled = false;
            //playerHealthBar.value = .001f;
            isFalling = true;
            //currentHealth = 1f;
            IsDead();
            if(transform.parent.tag == "Player")
            {
                gameTimerText.text = opponentName.text + " Wins!";
            }
            else
            {
                gameTimerText.text = player1.name + " Wins!";

            }

            Debug.Log("dead");
        }
    }
    void SetWinner()
    {
        
    }

    IEnumerator EnableColliders()
    {
        if (hitCol.enabled == false)
        {
            yield return new WaitForSeconds(seconds);
            hitCol.enabled = true;
            isHit = false;
            seconds = .1f;
        }
    }
}
