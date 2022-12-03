using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRematch : MonoBehaviour
{
    public void ReloadFight()
    {
        StartCoroutine(LoadSceneWait());
    }

    IEnumerator LoadSceneWait()
    {
        yield return new WaitForSeconds(1.3f);
        RematchSettings.isClicked = false;
        SceneManager.LoadScene("Main");
    }

}

	
