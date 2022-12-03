using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    Scene activeScene;

    bool main;
    bool startScreen;
    bool characterselect;

    //players

    public static bool wood;
    public static bool chris;
    public static bool phil;
    public static bool bethany;
    public static bool brad;

    //opponents

    public static string opponent;
    
    List<string> opps;
    public static string philOpp;
    public static string bethanyOpp;
    public static string chrisOpp;
    public static string bradOpp;
    public static string jordanOpp;
    public static string lioncornOpp;

    //backgrounds

    public static bool clubCafe;
    public static bool artsFest;

    //Rounds

    public static int playerWins;
    public static int oppWins;
    public static int totalWins;

    public static bool round1;
    public static bool round2;
    public static bool finalRound;

    public static string player;
    public static string background;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        opps = new List<string>();
        opps.Add(philOpp);
        opps.Add(jordanOpp);
        opps.Add(chrisOpp);
        opps.Add(bradOpp);
        opps.Add(bethanyOpp);
        opponent = null;
        //player = "Jordan";
    }

    void Start()
    {
        round1 = true;
        playerWins = 0;
        oppWins = 0;
        totalWins = 0;
        SetOpponentScene();
        
    }
	
	void Update ()
    {
        activeScene = SceneManager.GetActiveScene();
        //Debug.Log("O Wins " + oppWins);
        //Debug.Log("P Wins " + playerWins);
        Debug.Log("Opponent " + opponent);
        Debug.Log("Total Wins " + totalWins);
        Debug.Log("GM Player " + player);

        SetOpponentScene();
    }

    /*public void PlayerSelected(string player)
    {
        
        
        
    }*/

    void PlayerSwitch(string player)


    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main"))
        {

        }
        
    }
    public void PlayerSelected(string player)
    {
        

        switch (player)
        {
            case "Wood":

                wood = true;
                break;

            case "Chris":

                chris = true;
                break;

            case "Phil":

                phil = true;
                break;

            case "Bethany":

                bethany = true;
                break;

            case "Brad":

                brad = true;

                break;
        }
    }

    public void BgSelected(string bg)
    {
        switch (bg)
        {
            case "ClubCafe":

                clubCafe = true;
                break;

            case "ArtsFest":

                artsFest = true;
                break;
        }
    }

    public bool Main()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main"))
        {
            return main = true;
        }
        else
        {
            return false;
        }

    }

    // ROUND MANAGEMENT

    public static void NextMatch()
    {
        SceneManager.LoadScene(opponent + "Intro");
    }

    

    public void SetPlayerScene(string playerName)
    {
        player = playerName;
    }

    public void SetBackgroundScene(string backgroundName)
    {
        background = backgroundName;
    }

    void SetOpponentScene()
    {
        if(totalWins < 1)
        {
            opponent = "BethanyOpp";
        }
        if (totalWins == 1)
        {
            opponent = "BradOpp";
        }
        if (totalWins == 2)
        {
            opponent = "JordanOpp";
        }
        if (totalWins == 3)
        {
            opponent = "PhilOpp";
        }
        if (totalWins == 4)
        {
            opponent = "ChrisOpp";
        }
        if (totalWins == 5)
        {
            opponent = "LioncornOpp";
        }
        if (totalWins > 5)
        {
            totalWins = 0;
            //beat the game achievements
        }
    }

    public static void LoadRematchScene()
    {
        SceneManager.LoadScene("Rematch");
    }

    // SceneManager.LoadScene("Main");

    /*if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StartScreen"))
        {
            return startScreen = true;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Characterselect"))
        {
            return characterselect = true;
        }

        return false;
        */
}
