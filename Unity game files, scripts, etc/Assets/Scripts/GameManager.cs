using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : RandomBattle {

    public GameObject cameraMain;
    public GameObject cameraBattle;
    public bool isInCombat;

    public GameObject player;
    public GameObject follower;
    public GameObject attackWindow;
    public GameObject sinBattleBar;
    public GameObject cryptBattleBar;
    public GameObject wolfBBar;
    public GameObject spiderBBar;
    public GameObject ratBBar;
    public GameObject batBBar;
    public GameObject hudFader;
    public GameObject sinDmg;
    public GameObject cryptDmg;
    public GameObject nextTurn;
    public GameObject turnWindow;
    public GameObject forestMusTrig;
    public GameObject templeMusTrig;


    public List<BaseMonsters> allMonsters = new List<BaseMonsters>();
    public Transform monsterSpawnPoint;
    public GameObject emptyMon;


    // Use this for initialization
    void Start ()
    {
        cameraBattle.SetActive(false);
        attackWindow.SetActive(false);
        cryptBattleBar.SetActive(false);
        sinBattleBar.SetActive(false);
        wolfBBar.SetActive(false);
        spiderBBar.SetActive(false);
        ratBBar.SetActive(false);
        batBBar.SetActive(false);
        sinDmg.SetActive(false);
        cryptDmg.SetActive(false);
        nextTurn.SetActive(false);
        turnWindow.SetActive(false);

    }

    public List<BaseMonsters> GetMonsterByType(Mtype mtype)
    {
        List<BaseMonsters> returnMonster = new List<BaseMonsters>();
        foreach (BaseMonsters Monster in allMonsters)
        {
            if (Monster.mtype == mtype)
                returnMonster.Add(Monster);
        }
        return returnMonster;
    }

    public BaseMonsters GetRandomMonsterFromList(List<BaseMonsters> monsterList)
    {
        BaseMonsters mon = new BaseMonsters();
        int monIndex = Random.Range(0, monsterList.Count - 1);
        mon = monsterList[monIndex];
        return mon;
    }

    public void EnterCombat(Mtype mtype)
    {
        cameraMain.SetActive(false);
        cameraBattle.SetActive(true);
        player.GetComponent<PlayerMovement>().isAllowedToMove = false;
        follower.GetComponent<FollowPlayer>().isAllowedToMove = false;
        attackWindow.SetActive(true);
        cryptBattleBar.SetActive(true);
        sinBattleBar.SetActive(true);
        hudFader.SetActive(false);
        templeMusTrig.SetActive(false);
        forestMusTrig.SetActive(false);



        BaseMonsters battleMonsters = GetRandomMonsterFromList(GetMonsterByType(mtype)); //gets random monster, random type

        Debug.Log("You have entered a battle with a " + battleMonsters.pName);
      
            GameObject enemy = Instantiate(emptyMon, monsterSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        
        enemy.transform.parent = monsterSpawnPoint;

        BaseMonsters tempMon = enemy.AddComponent<BaseMonsters>() as BaseMonsters;
        tempMon = battleMonsters;

        enemy.GetComponent<SpriteRenderer>().sprite = battleMonsters.image;

        if (battleMonsters.mtype == Mtype.wolf)
        {
            wolfBBar.SetActive(true);
        }
        else if (battleMonsters.mtype == Mtype.spider)
        {
            spiderBBar.SetActive(true);
        }
        else if (battleMonsters.mtype == Mtype.rat)
        {
            ratBBar.SetActive(true);
        }
        else if (battleMonsters.mtype == Mtype.bat)
        {
            batBBar.SetActive(true);
        }


        //enemy.GetComponent<Animator>().Play(battleMonsters.mAnim.name);
        //
        // im confused about this because this should be the command to access idle animation variable that was
        // created in basemonsters script, which has been added in inspector for each monster. but since the way this is coded,
        // uses equation in randombattle  to decide what monster to battle with and all the lists here pull it out and dump it in
        // "empty monster" prefab, it doesnt play the animation with it, despite being defined. only gives us sprite image.
        // spent weeks trying to find a way to fix this but cant
        //
        //
        //
        // a better system would be to get rid of emptymonster and just shit out random prefabs instead but i dont
        // know how to do that using the same method of entering a random battle. cant find tutorials specific enough.
        // code is messy from taping random pieces of different tutes together
    }

    public void ExitCombat()
    {
        cameraMain.SetActive(true);
        cameraBattle.SetActive(false);
        player.GetComponent<PlayerMovement>().isAllowedToMove = true;
        follower.GetComponent<FollowPlayer>().isAllowedToMove = true;
        attackWindow.SetActive(false);
        cryptBattleBar.SetActive(false);
        sinBattleBar.SetActive(false);
        wolfBBar.SetActive(false);
        spiderBBar.SetActive(false);
        ratBBar.SetActive(false);
        batBBar.SetActive(false);
        hudFader.SetActive(true);
        nextTurn.SetActive(false);
        turnWindow.SetActive(false);
        templeMusTrig.SetActive(true);
        forestMusTrig.SetActive(true);


        Destroy(GameObject.FindGameObjectWithTag("enemy"));
        Debug.Log("Left Combat");

    }

}
