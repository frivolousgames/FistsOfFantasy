using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour {

    public GameObject arrow;
    public Transform arrowSpawn;
    bool isArrow;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("DragonEdge"))
        {
            isArrow = true;
            StartCoroutine(ArrowShoot());
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("DragonEdge"))
        {
            isArrow = false;
        }

    }

    private void Update()
    {
       
    }

    IEnumerator ArrowShoot()
    {
        while (isArrow == true)
        {
            Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation, null);
            yield return new WaitForSeconds(Random.Range(.8f, 1f));
        }
        
    }
}
