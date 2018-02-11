using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public Image faderImage; //image which fades on Canvas

    bool isInTransition; //used to starts or stops transition
    float transition;    //used for lerping
    bool isShowing;      //used to toggle fade in and out
    float duration;      //used to decide fading duratioin

    bool fadingRed = false; //used to slightly fade out on player death
    bool hasCalled = false; //used to controll so that Fade function gets called only once


    private void Start()
    {
        Fade(false, 1);
    }

    public void Fade(bool showing, float duration)
    {
        //fade in/out to complete black screen

        isInTransition = true;
        isShowing = showing;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;

        //make sure the screen is not fading red
        fadingRed = false;
    }

    public void FadeRed(float duration)
    {
        // fade out the screen to transparent red

        isInTransition = true;
        isShowing = false;
        this.duration = duration;
        transition = 0;

        fadingRed = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Fade screen to transparent red when player dies
        if (PlayerManager.Health <= 0 && !hasCalled)
        {
            FadeRed(2);

            //ensure to call the function above only once
            hasCalled = true;
        }

        if(GameStateManager.CurrentState == GameStateManager.GameStates.PAUSED)
        {
            Fade(true, 0.01f);
        }

        //do nothing when neither of the private function is called
        if (!isInTransition)
            return;


        if (!fadingRed)
        {
            //Fade in/out screen black
            transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
            faderImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        }
        else
        {
            //Fade screen red
            transition += Time.deltaTime * (1 / duration);
            faderImage.color = Color.Lerp(new Color(1, 0, 0, 0), new Color(1, 0, 0, 0.5f), transition);
        }

        //Stop when fading is done
        if (transition > 1 || transition < 0)
        {
            isInTransition = false;
        }

    }

}
