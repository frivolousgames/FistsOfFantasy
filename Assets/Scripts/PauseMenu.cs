using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseScreen;
    //public GameObject pauseMenu;

   // Animator anim;

    bool isPause = false;

    private void Start()
    {
        //anim = pauseMenu.GetComponent<Animator>();
    }

    private void Update()
    {
        Pause();
        //anim.SetBool("isPause", isPause);
    }
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause != true)
            {
                isPause = true;
                pauseScreen.SetActive(true);
                //anim.SetTrigger("Pause");
                
            }
            else
            {
                isPause = false;
                pauseScreen.SetActive(false);
                //anim.ResetTrigger("Pause");
            }
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
