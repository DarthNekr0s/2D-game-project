using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : PlayerMovement
{
    public GameObject target;
    public List<Vector3> positions;
    public int distance_permitted;
    private Vector3 lastLeaderPosition;
    private Animator anim;

    // Use this for initialization
    private void Start()
    {

        isAllowedToMove = true;
        positions.Add(target.transform.position); //records target place into list 'positions'

        anim = GetComponent<Animator>(); //gets animator controller for follower
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        GetInput();
        Move();

        if (lastLeaderPosition != positions[positions.Count - 1])  //adds targets steps to position list
        {
            positions.Add(target.transform.position);

        }

        if (positions.Count >= distance_permitted)  //if steps we have record is more than or the same as how far away we're allowed
        {
            if (gameObject.transform.position != positions[0])  //if we are not in the first step recorded
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[0], Time.deltaTime * speed);  //then go to first step        
            }
            else
            {
                positions.Remove(positions[0]); //remove old steps from path
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.position = Vector3.MoveTowards(transform.position, positions[0], Time.deltaTime * speed);
            }        
        }//update with targets last position
        lastLeaderPosition = target.transform.position;
       
    }

    private void Move()
    {

        if (direction.x != 0 || direction.y != 0)  //if we are moving either in x or y then animate the movement to walking
        {
            AnimateMovement(direction);
        }
        else
        {
            anim.SetLayerWeight(1, 0);  //if not moving then change movement to idle
        }

    }

    private void AnimateMovement(Vector2 direction)
    {
        anim.SetLayerWeight(1, 1); //changes animator layer to walking

        anim.SetFloat("x", direction.x); //sets values of animator parameters to what direction is being faced
        anim.SetFloat("y", direction.y);
    }

}



