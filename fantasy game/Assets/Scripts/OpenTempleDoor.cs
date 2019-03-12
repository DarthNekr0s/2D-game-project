using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTempleDoor : MonoBehaviour {

    private Animator anim;
    private bool hasPlayer;
    private BoxCollider2D bTrig;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        bTrig = GetComponentInChildren<BoxCollider2D>();
    }

    //Update is called once per frame

    void Update()
    {

        if (hasPlayer && Input.GetKeyDown("e"))    //checks each frame to see if player is there and e key is being pressed
        {
            anim.Play("buttonPress");  //if these conditions are met, plays animation
            bTrig.enabled = false;
            
        }
        else if (!hasPlayer)
        {
            anim.Play("buttonIdle");
        }
    }

    public void OnTriggerEnter2D(Collider2D col)  //tells us if the player has entered the trigger
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hasPlayer = true;
        }
    }

}
