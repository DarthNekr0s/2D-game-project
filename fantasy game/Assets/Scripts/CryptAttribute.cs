using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptAttribute : MonoBehaviour {

    [SerializeField]
    private Stat health;

    private float initHealth = 100;

    // Use this for initialization
    void Start ()
    {
        health.Initialize(initHealth, initHealth);
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }
}
