using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinAttribute : MonoBehaviour {

    [SerializeField]
    private Stat health;

    private float initHealth = 100;

    // Use this for initialization
    void Start ()
    {
        health.Initialize(initHealth, initHealth);
    }

    // Update is called once per frame
    void Update()
    {

        //checking to see if hp changes
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10; //subtracts 10 hp 
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10; //adds 10 hp
        }

    }
    
}

