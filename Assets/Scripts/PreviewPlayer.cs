using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PreviewPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject playerPreview;

    Button playerButton;
    Image playerSR;
    Color clear;

    public GameObject playerName;
    Text playerNameText;
    Animator playerAnim;
    public bool setPreview;
    public static bool isClickedPlayer;

    public GameObject blinkScreen;
    Animator blinkAnim;

    public bool playerSelected;

    private void Start()
    {
        playerNameText = playerName.GetComponent<Text>();
        playerAnim = playerPreview.GetComponent<Animator>();
        blinkAnim = blinkScreen.GetComponent<Animator>();
        playerButton = this.GetComponent<Button>();
        playerSR = this.GetComponent<Image>();
        clear = Color.clear;
    }

    private void Update()
    {
        playerAnim.SetBool(this.gameObject.name.ToString(), setPreview);
        playerAnim.SetBool(this.gameObject.name.ToString() + "Selected", playerSelected);

        if (isClickedPlayer == true)
        {
            playerButton.interactable = false;


            if (playerSelected == true)
            {
                playerSR.color = clear;
            }
           
        }
  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //isClicked = false;
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(isClickedPlayer == true)
        {

        }

        else
        {
            //playerPreview.SetActive(true);
            playerName.SetActive(true);
            playerNameText.text = this.name.ToString();
            setPreview = true;

        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(isClickedPlayer == true)
        {

        }

        else
        {
            //playerPreview.SetActive(false);
            playerName.SetActive(false);
            setPreview = false;
        }
        
    }

    public void IsPlayerClicked()
    {
        if(isClickedPlayer == false)
        {
            blinkAnim.SetTrigger("Blink");
            setPreview = false;
            playerSelected = true;
            isClickedPlayer = true;
        }
        
    }

}
