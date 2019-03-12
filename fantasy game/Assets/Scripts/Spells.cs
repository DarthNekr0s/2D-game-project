using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public Transform spellTarget;
    private float speed = 4f;
    Animator spellAnim;


    IEnumerator SpellFire() //using coroutine function, we can leave the spell charging for a few seconds before firing
    {
        yield return new WaitForSeconds(2);
        //SPELL WILL CAST TOWARDS ENEMY
        Vector2 direction = spellTarget.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed; 
        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject, 1.8f);

    } 

    // Use this for initialization
    void Start()
    {
        spellTarget = GameObject.FindGameObjectWithTag("enemy").transform; //finds where enemy is 
        spellAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
    StartCoroutine(SpellFire());

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("enemy")) //if we collide with enemy then play exploding animation
            Debug.Log("Hit");
            spellAnim.SetTrigger("Impact"); //currently not working . everything has been set up afaik so maybe its just that particles cant be animated
        
    }

}
