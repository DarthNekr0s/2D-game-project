using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Stat : MonoBehaviour {

    private Image content;
    [SerializeField]
    private TMP_Text statValue;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    public Stat health;

    [SerializeField]
    private float maxHealth;

    private GameManager gm;

    private float currentFill; //how much the heath bar image is filled
    public float MyMaxValue { get; set; } //this is for max health
    private float currentValue; //how much hp we have atm

    public float MyCurrentValue //accesses current hp from other scripts. everytime hp is calculated it uses this
    {
        get
        {
            return currentValue; //checks hp
        }

        set
        {
            if (value > MyMaxValue) //makes sure that current value will not go over max value, by setting current to max
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0) //if overkill happens then sets hp to zero so we cannot get negative value
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / MyMaxValue; //sets fill for hp based on cur/max

            statValue.text = currentValue + " / " + MyMaxValue;
        }
    }

    // Use this for initialization
    void Start() {
        content = GetComponent<Image>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        health.Initialize(maxHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount) //if current hp is different then fill amount, then change it
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed); //lerp hp from old hp to new hp (dont rly know what lerp means but this makes it go smoothly)
        }
    }

    public void Initialize(float currentValue, float maxValue) //sets health at start of game
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }

    public virtual void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;

        if (health.MyCurrentValue <= 0 && (gm != null))
        {
            gm.ExitCombat();
            health.Initialize(maxHealth, maxHealth);
            currentFill = maxHealth;
            content.fillAmount = maxHealth;
        }
    }

    public void IfRun()  //resets health for next battle if you run away
    {
        if (gm != null)
           {
            gm.ExitCombat();
            health.Initialize(maxHealth, maxHealth);
            currentFill = maxHealth;
            content.fillAmount = maxHealth;
           }
    }
}

