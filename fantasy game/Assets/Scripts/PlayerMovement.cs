using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character {

    public bool isAllowedToMove = true;

    // Use this for initialization
    protected override void Start () {

        base.Start();
        isAllowedToMove = true;
    }
	
	// Update is called once per frame
	protected override void Update () {

        GetInput();

        base.Update(); //accesses class it inherits from and executes its update function
	}


    protected virtual void GetInput()  //can use either wasd or arrows to move
    {
        direction = Vector2.zero;


        if (isAllowedToMove) //if we're not in combat these keys are for movement
        {
            if (Input.GetKey(KeyCode.W))
            { 
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction += Vector2.left;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction += Vector2.down;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector2.right;
            }
        }
    }
}
