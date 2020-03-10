using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterAttack : MonoBehaviour {

    GameObject[] fightChars;   //creating an array to store sin and crypt in

    public GameObject statScript;  //lets you drag object into inspector that has stat script attached
    private GameManager gm;  //access game manager for blood bursts
    private Button turn;

    //[SerializeField]
    private int damage;


    // Use this for initialization
    void Start () {

        fightChars = GameObject.FindGameObjectsWithTag("fighter");      //objects to store in array
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();    //access gm script
        turn = GetComponent<Button>();
        damage = Random.Range(5, 8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (turn.interactable == false)               //if the attacking buttons are disabled then signal monster's turn
        {
            StartCoroutine(MonsterHit());                 
        }
    }

    IEnumerator MonsterHit()
    {

        fightChars[(Random.Range(0, fightChars.Length))].GetComponent<Stat>();  //picks random character to attack, gets stat script here hp stored
        yield return new WaitForSeconds(1);
        gm.nextTurn.SetActive(true);                     //actives monster turn box 1 second after we attack monster
        gm.turnWindow.SetActive(true);
        gm.turnWindow.GetComponent<CanvasRenderer>().SetAlpha(255);                 //brings button back if alpha has been turned to 0
        gm.nextTurn.GetComponent<TextMeshProUGUI>().alpha = 255;
    }


    public virtual void TakeMotherfuckingDamage()                //then this happens when we click
    {
        StopCoroutine(MonsterHit());
        statScript.GetComponent<Stat>().TakeDamage(damage);  //char takes random damage between 5 - 8
        Debug.Log("we took damage");
        gm.sinDmg.SetActive(true);
        gm.cryptDmg.SetActive(true);                 //enables the inactive blood animation on avatars
        StartCoroutine(DamageAnim());                         //starts playing that next coroute
    }

    IEnumerator DamageAnim()
    {
        gm.turnWindow.GetComponent<CanvasRenderer>().SetAlpha(0);
        gm.nextTurn.GetComponent<TextMeshProUGUI>().alpha = 0;    //disbales monster turn box (takes two clicks to work, why?
        yield return new WaitForSeconds(2);
        gm.sinDmg.SetActive(false);
        gm.cryptDmg.SetActive(false);                            //now disabled anim after 2 seconds of play
        //maybe dialogue here saying "you took x damage"
        turn.interactable = true;                                 //turns attack window back on
    }





}
