using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour {

    public GameObject powerUp;
    public GameObject finisher;
    public float height;
    public static bool spawn;

    public Slider playerHealth;
    public Slider oppHealth;
    bool playerFinish;
    bool oppFinish;
    bool finishSpawn;

    GameObject powerActive;

    GameObject playerCollider;
    GameObject oppCollider;
    GameObject[] colliders;

    private void Awake()
    {
        playerFinish = true;
        oppFinish = true;
        spawn = true;
        
    }
    private void Start()
    {
        colliders = GameObject.FindGameObjectsWithTag("FinisherCollider");
        StartCoroutine(SpawnPowerUps());
        foreach(GameObject collider in colliders)
        {
            if(collider.transform.parent.tag == "Player")
            {
                playerCollider = collider;
            }
            else
            {
                oppCollider = collider;
            }
        }
    }

    private void Update()
    {
        if(OpponentController.isOppFinisher == true)
        {
            spawn = false;
        }
        PlayerHealthValue();
        OppHealthValue();
        SpawnFinisher();
        //Debug.Log("FinishSpawn = " + finishSpawn);
        //Debug.Log("Icon " + finisher.activeInHierarchy);
    }

    IEnumerator SpawnPowerUps()
    {
        while(spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(25f, 30f));
            Instantiate(powerUp, new Vector2(MultipleCameraMove.centerPoint, height), powerUp.transform.rotation);
        }
    }

    void SpawnFinisher()
    {
        if(PlayerHealth.isDead != true)
        {
            if (finishSpawn == true)
            {
                Instantiate(finisher, new Vector2(MultipleCameraMove.centerPoint, height), powerUp.transform.rotation);
                //finishSpawn = false;
                StartCoroutine(FinishSpawnDelay());
            }
        }
        
    }

    void PlayerHealthValue()
    {
        if(playerFinish == true)
        {
            if (playerHealth.value < 30)
            {
                finishSpawn = true;
                playerFinish = false;
                spawn = false;
                oppCollider.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
    void OppHealthValue()
    {
        if (oppFinish == true)
        {
            if (oppHealth.value < 90)
            {
                finishSpawn = true;
                oppFinish = false;
                spawn = false;
                playerCollider.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
    IEnumerator PowerUpDelay()
    {
        yield return new WaitForSeconds(8f);
        spawn = true;
    }
    IEnumerator FinishSpawnDelay()
    {
        yield return new WaitForEndOfFrame();
        finishSpawn = false;
    }
}
