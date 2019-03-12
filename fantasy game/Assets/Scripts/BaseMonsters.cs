using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseMonsters : MonoBehaviour {

    public string pName;
    public Mtype mtype;
    public Sprite image;
    public Animation mAnim;




    public enum Mtype
    {
        spider,
        rat,
        bat,
        wolf
    }
}
