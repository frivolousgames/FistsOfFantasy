using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextScene : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(StartWait());
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main");
    }
}
