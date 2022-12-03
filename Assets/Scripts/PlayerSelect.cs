using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour {

    public GameManager gameManager;

    

    //Player Select

    public void WoodClick()
    {
        if(PreviewPlayer.isClickedPlayer == false)
        {
           gameManager.PlayerSelected("Wood");
            gameManager.SetPlayerScene("Jordan");
        }

    }

    public void ChrisClick()
    {
        if (PreviewPlayer.isClickedPlayer == false)
        {
            gameManager.PlayerSelected("Chris");
            gameManager.SetPlayerScene("Chris");

        }
    }

    public void PhilClick()
    {
        if (PreviewPlayer.isClickedPlayer == false)
        {
            gameManager.PlayerSelected("Phil");
            gameManager.SetPlayerScene("Phil");

        }
    }

    public void BethanyClick()
    {
        if (PreviewPlayer.isClickedPlayer == false)
        {
            gameManager.PlayerSelected("Bethany");
            gameManager.SetPlayerScene("Bethany");

        }
    }

    public void BradClick()
    {
        if (PreviewPlayer.isClickedPlayer == false)
        {
            gameManager.PlayerSelected("Brad");
            gameManager.SetPlayerScene("Brad");

        }
    }

   //Background Select

    public void ClubCafe()
    {
        gameManager.BgSelected("ClubCafe");
        gameManager.SetBackgroundScene("ClubCafe");
    }

    public void ArtsFest()
    {
        gameManager.BgSelected("ArtsFest");
        gameManager.SetBackgroundScene("ArtsFest");
    }

    //Start

    //Opponent Select


}
