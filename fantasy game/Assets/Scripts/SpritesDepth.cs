using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpritesDepth : Character {

    public bool IsPlayer;

    float layer;

    SpriteRenderer rend;

    Vector3 centerBottom;

    // Use this for initialization
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        centerBottom = transform.TransformPoint(rend.sprite.bounds.min); //gets position of the bottom of a sprite

        layer = centerBottom.y; 

        rend.sortingOrder = -(int)(layer * 100); //takes the sprite with the lower y point and brings it higher in sorting order

    }
}
