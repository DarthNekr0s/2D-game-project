using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinAttack : MonoBehaviour {

    public AnimationClip atkAnim;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void MeleeAttack()
    {
        GetComponent<Animator>().Play(atkAnim.name);
    }
}
