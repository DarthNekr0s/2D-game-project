using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGERTESTING : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && Input.GetKeyDown("r"))
        {
           // talkZone = true;
            Debug.Log("were trying to fucking talk");
        }
    }
}


