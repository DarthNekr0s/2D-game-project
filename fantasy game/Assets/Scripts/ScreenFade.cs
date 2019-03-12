using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour {

    Animator anim;
    bool isFading = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");  //fade from black to clear

        while (isFading)
            yield return null;  //the function will not return until isfading is set back to false
    }

    public IEnumerator FadeToBlack()
    
        {
            isFading = true;
            anim.SetTrigger("FadeOut");  //fade from clear to black

            while (isFading)
                yield return null;
        }

    void AnimationComplete()
    {
        isFading = false;
    }
}
