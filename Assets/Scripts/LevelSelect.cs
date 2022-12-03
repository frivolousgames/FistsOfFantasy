using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isClickedLevel;

    Animator buttonAnim;

    public bool levelHighlighted;
    bool thisButtonClicked;

    public GameObject blinkScreen;
    Animator blinkAnim;

    private void Awake()
    {
        isClickedLevel = false;
    }

    private void Start()
    {
        buttonAnim = this.gameObject.GetComponent<Animator>();
        blinkAnim = blinkScreen.GetComponent<Animator>();
    }

    private void Update()
    {
        buttonAnim.SetBool("Highlighted", levelHighlighted);
        if(thisButtonClicked != true)
        {
            if(isClickedLevel == true)
            {
                buttonAnim.SetTrigger("Deactivated");
            }
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (isClickedLevel == true)
        {
            levelHighlighted = false;
        }

        else
        {
            levelHighlighted = true;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isClickedLevel == true)
        {
            levelHighlighted = false;
        }

        else
        {
            levelHighlighted = false;
        }

    }

    public void IsLevelClicked()
    {
        if(isClickedLevel != true)
        {
            blinkAnim.SetTrigger("Blink");
            levelHighlighted = false;
            buttonAnim.SetTrigger("LevelSelected");
            isClickedLevel = true;
            thisButtonClicked = true;
        }
    }

}
