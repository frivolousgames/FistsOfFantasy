using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Rounds : MonoBehaviour {

    bool roundEnded;

    bool round1;
    bool round2;
    bool finalRound;

    bool someoneWon;
    bool matchEnd;
    bool setMark;

    public GameObject fightText;
    public Text timerText;

    int playerWin;
    int oppWin;
    int matchWins;

    GameObject player;
    GameObject opponent;

    public GameObject winMark1;
    public GameObject winMark2;
    public GameObject winMark3;
    public GameObject winMark4;

    Animator winMark1A;
    Animator winMark2A;
    Animator winMark3A;
    Animator winMark4A;

    Animator fightTextAnim;

    public Slider playerHealthBar;
    public Slider oppHealthBar;

    

void Awake()
    {
        fightTextAnim = fightText.GetComponent<Animator>();
        winMark1A = winMark1.GetComponent<Animator>();
        winMark2A = winMark2.GetComponent<Animator>();
        winMark3A = winMark3.GetComponent<Animator>();
        winMark4A = winMark4.GetComponent<Animator>();
        roundEnded = false;
        setMark = true;
        matchEnd = false;
    }


    void Start()
    {
        SetRound();
        player = GameObject.FindGameObjectWithTag("Player");
        opponent = GameObject.FindGameObjectWithTag("Opponent");
        WinMarks();

    }


    void Update()
    {
        RoundOver();
        SomeoneWon();
        WinMarkAnim();
        Debug.Log("Someone won " + someoneWon);


    }



    void RoundOver()
    {
        if (PlayerHealth.isDead == true ||
            GameTimer.timeInt < 1) 
        {
            RoundWinner();
        }
            
    }
     
          
    void RoundWinner()
    {
        if (playerHealthBar.value == 0 ||
         oppHealthBar.value >
         playerHealthBar.value)
        {
            if(roundEnded == false)
            {
                roundEnded = true;
                oppWin = 1;
                GameManager.oppWins += oppWin;
                StartCoroutine("RoundEndWait");
            }
        }
           
        if (oppHealthBar.value == 0 ||
             playerHealthBar.value >
             oppHealthBar.value)
        {
            if(roundEnded == false)
            {
                roundEnded = true;
                playerWin = 1;
                GameManager.playerWins += playerWin;
                StartCoroutine("RoundEndWait");
            }
        }
    }

    IEnumerator RoundEndWait()
    {
        yield return new WaitForSeconds(4f);
        NextRound();
    }
     

    void NextRound()
    {
        if (someoneWon == true)
        {
            if(matchEnd == false)
            {
                GameManager.round1 = true;
                GameManager.round2 = false;
                GameManager.finalRound = false;
                GameManager.playerWins = 0;
                GameManager.oppWins = 0;
                matchEnd = true;
                if (playerWin > 0)
                {
                    GameManager.totalWins++;
                    StartCoroutine(MatchWait());
                }
                else
                {
                    GameManager.LoadRematchScene();
                }
                
                
            }
        }

        if (round1 == true)
        {
            GameManager.round1 = false;
            GameManager.round2 = true;
            SceneManager.LoadScene("Main");
        }
            
     /*if (round2 == true &&
         someoneWon == false)
        {
            GameManager.round2 = false;
            GameManager.round3 = true;
            SceneManager.LoadScene("Main");
        }*/
            
     if (round2 == true &&
         someoneWon == false)
        {
            GameManager.round2 = false;
            GameManager.finalRound = true;
            SceneManager.LoadScene("Main");
        }
            


    }
    IEnumerator MatchWait()
    {
        yield return new WaitForSeconds(.1f);
        GameManager.NextMatch();

    }

    void NextMatch()
    {
        if (round1 == true)
        {

        }
    }
     
             

    void SetRound()
    {
        if (GameManager.round1 == true)
        {
            fightTextAnim.SetTrigger("Round 1");
            round1 = true;

        }

        if (GameManager.round2 == true)
        {
            fightTextAnim.SetTrigger("Round 2");
            round2 = true;
        }

        /*if (GameManager.round3 == true)
        {
            fightTextAnim.SetTrigger("Round 3");
            round3 = true;
        }*/

        if (GameManager.finalRound == true)
        {
            fightTextAnim.SetTrigger("Final Round");
            finalRound = true;
        }
        StartCoroutine(RoundStartDelay());
    }
    IEnumerator RoundStartDelay()
    {
        yield return new WaitForSeconds(2.6f);
        PlayerHealth.isDead = false;
    }

    void SetTimescale()
    {
        Time.timeScale = 1f;
    }
     

    void SomeoneWon()
    {
        if (GameManager.playerWins == 2 || GameManager.oppWins == 2)
            someoneWon = true;
        else
            someoneWon = false;
    }
      

    void WinMarks()
    {
        if (GameManager.playerWins == 1)
            winMark1.SetActive(true);
    
        if (GameManager.oppWins == 1)
            winMark3.SetActive(true);
        

    }

    void WinMarkAnim()
    {
        if(setMark == true)
        {
            if (GameManager.playerWins == 1)
                if (winMark1.activeInHierarchy == false)
                {
                    setMark = false;
                    winMark1.SetActive(true);
                    winMark1A.SetTrigger("Win");
                }

            if (GameManager.playerWins == 2)
            {
                if (winMark2.activeInHierarchy == false)
                {
                    setMark = false;
                    winMark1.SetActive(false);
                    winMark2.SetActive(true);
                    winMark2A.SetTrigger("Win");
                }
            }

            if (GameManager.oppWins == 1)
            {
                if (winMark3.activeInHierarchy == false)
                {
                    setMark = false;
                    winMark3.SetActive(true);
                    winMark3A.SetTrigger("Win");
                }
            }

            if (GameManager.oppWins == 2)
            {
                if (winMark4.activeInHierarchy == false)
                {
                    setMark = false;
                    winMark3.SetActive(false);
                    winMark4.SetActive(true);
                    winMark4A.SetTrigger("Win");
                }
            }
        }
    }
     
}
