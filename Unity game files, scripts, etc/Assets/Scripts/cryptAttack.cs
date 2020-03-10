using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cryptAttack : MonoBehaviour {

    public Transform spellAttack;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
		
	}

    public void CastSpell()
        {
            Instantiate(spellAttack, new Vector2(3.1F, 25.4f), spellAttack.rotation);
        }
}


