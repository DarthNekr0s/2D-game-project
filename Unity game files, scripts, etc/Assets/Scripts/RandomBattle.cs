using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBattle : BaseMonsters
{
    private GameManager gm;
 
    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame


    void Update()
    {
        
    }

   

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player")) //if we are a playing entering this trigger
        {
            float spider = 7 / 190f; //rarity values of certain monsters
            float rat = 6 / 190f;
            float bat = 4 / 190f;
            float wolf = 2 / 190f;

            float m = Random.Range(0.0f, 100.0f); //generates number for monster to fight

            if (m < wolf*100)  //when monsters are decided, if we happen to get rare monsters they show up over the common ones
            {
                if (gm != null)
                    gm.EnterCombat(Mtype.wolf);
            }
            else if(m < bat*100)
            {
                if (gm != null)
                    gm.EnterCombat(Mtype.bat);
            }
            else if (m < rat * 100)
            {
                if (gm != null)
                    gm.EnterCombat(Mtype.rat);
            }
            else if (m < spider * 100)
            {
                if (gm != null)
                    gm.EnterCombat(Mtype.spider);
            }
        }
    }

}