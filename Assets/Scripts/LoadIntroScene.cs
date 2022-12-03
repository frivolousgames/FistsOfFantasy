using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntroScene : MonoBehaviour {

    public void LoadStartScene()
    {
        StartCoroutine(LoadSceneWait());
    }

    IEnumerator LoadSceneWait()
    {
        yield return new WaitForSeconds(1.3f);
        RematchSettings.isClicked = false;
        GameManager.totalWins = 0;
        SceneManager.LoadScene("StartScreen");
    }
}
