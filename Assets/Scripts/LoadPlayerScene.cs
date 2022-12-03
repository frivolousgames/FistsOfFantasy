using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayerScene : MonoBehaviour {

    private void Awake()
    {
        SceneManager.LoadScene(GameManager.player, LoadSceneMode.Additive);
        SceneManager.LoadScene(GameManager.background, LoadSceneMode.Additive);
        SceneManager.LoadScene(GameManager.opponent, LoadSceneMode.Additive);
        //SceneManager.LoadScene("Jordan", LoadSceneMode.Additive);
        //SceneManager.LoadScene("ArtsFest", LoadSceneMode.Additive);
        //SceneManager.LoadScene("PhilOpp", LoadSceneMode.Additive);

    }
}
