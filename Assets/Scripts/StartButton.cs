using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    Button startButton;
    Animator anim;

    public GameObject vs;

    private void Awake()
    {
        startButton = this.gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        startButton.interactable = false;
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(PreviewPlayer.isClickedPlayer && LevelSelect.isClickedLevel)
        {
            startButton.interactable = true;
        }
    }

    public void Clicked()
    {
        anim.SetTrigger("Grow");
    }

    void ActivateVS()
    {
        vs.SetActive(true);
    }

    
}
