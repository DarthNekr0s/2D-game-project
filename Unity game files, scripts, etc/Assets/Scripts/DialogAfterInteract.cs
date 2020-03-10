using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogAfterInteract : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool talkZone;
    public bool allowedToInteract = true;


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
        }
    }

    void FixedUpdate()
    {
        if (allowedToInteract)
            {
            if (talkZone == true && Input.GetKeyDown("e"))
            {
                textWindow.SetActive(true);
                player.GetComponent<PlayerMovement>().isAllowedToMove = false;
                follower.GetComponent<FollowPlayer>().isAllowedToMove = false;
                allowedToInteract = false;
                StartCoroutine(Type());
            }
        }
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])        //while still typing, hide continue button
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
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
            GetComponent<CircleCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
