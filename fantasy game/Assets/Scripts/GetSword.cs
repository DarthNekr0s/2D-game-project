using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSword : MonoBehaviour {

    private bool hasPlayer;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (hasPlayer == true && Input.GetKeyDown("e"))
        {
            SwordAppear();
        }

    }

    public void SwordAppear()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D col)  //tells us if the player has entered the trigger
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }



}
