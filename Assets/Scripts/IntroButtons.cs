using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtons : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("Characterselect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
