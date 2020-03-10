using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour  {


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) //if we are a playing entering this trigger
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}