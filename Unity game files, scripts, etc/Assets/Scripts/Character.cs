using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    protected float speed;  //change movement speed here
    protected Vector2 direction;  //direction of movement. protected makes it unchangeable but still able to be accessed
    protected Animator animator;



    // Use this for initialization
    protected virtual void Start()
    {
        animator = GetComponent<Animator>(); //when the game starts, get reference to animate controller

    }

    // Update is called once per frame
    protected virtual void Update() //marks function to be able to be overriden with virtual
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)  //if we are moving either in x or y then animate the movement to walking
        {
            AnimateMovement(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);  //if not moving then change movement to idle
        }

    }

    private void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1); //changes animator layer to walking

        animator.SetFloat("x", direction.x); //sets values of animator parameters to what direction is being faced
        animator.SetFloat("y", direction.y);
    }

}






