﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazierLight : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.Play("brazierFire");
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.Play("unlitFire");
        }
    }

}
