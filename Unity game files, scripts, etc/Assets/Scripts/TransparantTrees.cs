using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparantTrees : SpritesDepth {
    SpriteRenderer tempRend;
    float timer = 1;
    

    private void Awake()
    {
        tempRend = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime; //counts for timer amount each frame
        if(timer<=0) //if we timed out
        {
            tempRend.color = new Color(1, 1, 1, 1); //resert colour back to normal
            timer = 1; //stops counting down
        }
	}

    public void OnTriggerStay2D(Collider2D other)
    {
        if (IsPlayer==false&&other.GetComponent<SpritesDepth>().IsPlayer ==true) //if we are not a player and other objec is a player (as defined in spritedepth)
        {
            tempRend.color = new Color(1, 1, 1, 0.5f); //then make objects transparant for 1 second
            timer = 1;
        }
    }
}
