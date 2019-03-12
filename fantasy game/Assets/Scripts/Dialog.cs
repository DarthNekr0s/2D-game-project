using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour {

    public TextMeshProUGUI textDisplay;
    [TextArea(3,10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool talkZone;

    private bool allowedtoInteract = true;

    public GameObject continueButton;
    public GameObject textWindow;
    public GameObject player;
    public GameObject follower;

    void Start()
    {
        talkZone = false;  
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            talkZone = true;
            Debug.Log("were trying to fucking talk");
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            talkZone = false;
            Debug.Log("we cant talk anymore");
        }
    }

    void FixedUpdate()
    {
        if (allowedtoInteract)
        {
            if (talkZone == true && Input.GetKeyDown("r"))
            {
                Debug.Log("now can we start fucking talking please");
                textWindow.SetActive(true);
                player.GetComponent<PlayerMovement>().isAllowedToMove = false;
                follower.GetComponent<FollowPlayer>().isAllowedToMove = false;
                StartCoroutine(Type());
                allowedtoInteract = false;
            }
 
        }
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])        //while still typing, hide continue button
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);       //hides continue button after clicking once, when starting next sentence
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            textWindow.SetActive(false);
            continueButton.SetActive(false);  //hides when dialogue has ended
            player.GetComponent<PlayerMovement>().isAllowedToMove = true;
            follower.GetComponent<FollowPlayer>().isAllowedToMove = true;
            allowedtoInteract = false;

        }
    }
}
