using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("an object collided");

        ScreenFade sf = GameObject.FindGameObjectWithTag("fader").GetComponent<ScreenFade>();  //so on a collision, find the gameobject that is tagged fader
                                                                                               //we access the screenfade script
        yield return StartCoroutine(sf.FadeToBlack());                                         //then starts the function of fading the screen in and out

        col.gameObject.transform.position = warpTarget.position;        //fades to black and moves to new zone
        GameObject.FindGameObjectWithTag("Crypt").gameObject.transform.position = warpTarget.position;  //teleports crypt as well

        yield return StartCoroutine(sf.FadeToClear());      //fades back in to normal
    }

}
