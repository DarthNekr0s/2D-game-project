using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogGameStart : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject textWindow;
    public GameObject player;
    public GameObject follower;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            textWindow.SetActive(true);
            continueButton.SetActive(true);
            player.GetComponent<PlayerMovement>().isAllowedToMove = false;
            follower.GetComponent<FollowPlayer>().isAllowedToMove = false;
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
        continueButton.SetActive(false);
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
            continueButton.SetActive(false);
            player.GetComponent<PlayerMovement>().isAllowedToMove = true;
            follower.GetComponent<FollowPlayer>().isAllowedToMove = true;
        }
    }
}
