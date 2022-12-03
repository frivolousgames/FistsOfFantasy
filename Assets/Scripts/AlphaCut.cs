using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaCut : MonoBehaviour {

    public float fadeWait = 5f;
    public float fadeTime = 1f;


    private void Start()
    {
        StartCoroutine(AlphaWait(GetComponent<SpriteRenderer>()));
    }

    IEnumerator AlphaWait(SpriteRenderer sp)
    {
        yield return new WaitForSeconds(fadeWait);
        Color tmpColor = sp.color;

        while(tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeTime;
            sp.color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0f;
            yield return null;
        }
        sp.color = tmpColor;
    }
}
