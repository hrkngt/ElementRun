using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    public GameObject player;

    public static Transform PlayerTransform { get; set; }
    private Animator animator;

    private float moveSpeed = 0.03f;
    private float animSpeed = 0.7f; //Initial animation speed

    private int rotationStopper = 0;
    private float previousScore = 0;

    private void Awake()
    {
        PlayerTransform = player.GetComponent<Transform>();
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {

        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            //set idle animation
            animator.SetInteger("Speed", 0);
        }
        else if (GameStateManager.CurrentState == GameStateManager.GameStates.RUNNING)
        {
            //move the player object forward
            PlayerTransform.position += new Vector3(0, 0, moveSpeed);

            //set running animation
            animator.SetInteger("Speed", 2);

            //
            animator.speed = animSpeed;
        }
        else if (GameStateManager.CurrentState == GameStateManager.GameStates.GAMEOVER)
        {
            if (rotationStopper < 90)
            {
                //knocks player down
                PlayerTransform.Rotate(Vector3.back);

                //slightly jump up the player to ensure player does not go under the floor
                PlayerTransform.position += new Vector3(0, 0.007f, 0);

                //rotatation stopper
                rotationStopper++;
            }

            if (animator.speed > 0) //Stop animation
            {
                //decrease animation speed
                animator.speed -= 0.01f;
            }
        }
        
        //constantly increase player speed
        if ( 600 * moveSpeed < ScoreManager.Score - previousScore)
        {
            IncreaseSpeed(0.008f);
            previousScore = ScoreManager.Score;
        }

    }

    void IncreaseSpeed(float increaseBy)
    {
        moveSpeed += increaseBy;
        animSpeed += increaseBy;
    }
}
