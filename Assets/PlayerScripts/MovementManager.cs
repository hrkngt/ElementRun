using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    /// <summary>
    /// プレイヤーオブジェクトの動きを制御するためのスクリプト
    /// </summary>

    public static Transform PlayerTransform { get; set; } //プレイヤーオブジェクトのトランスフォームを操作するために使用
    private Animator animator; //プレイヤーオブジェクトのアニメーションを操作するために使用

    private float moveSpeed = 0.03f; //初期の移動速度
    private float animSpeed = 0.7f;  //初期の体が動く速度(腕を振る等)

    private int rotationStopper = 0; //死亡時横に倒れる際の角度を制御するために使用
    private float previousScore = 0; //速度の上昇を制御するために使用

    private void Awake()
    {
        PlayerTransform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //シーン開始後、スタート画面でのアニメーションを設定
        if (GameStateManager.CurrentState == GameStateManager.GameStates.INITIAL)
        {
            //アニメーターをアイドル状態に設定
            animator.SetInteger("Speed", 0);
        }
        //ゲーム開始後、走っているときのアニメーションを設定
        else if (GameStateManager.CurrentState == GameStateManager.GameStates.RUNNING)
        {
            //プレイヤーを前進させる
            PlayerTransform.position += new Vector3(0, 0, moveSpeed);

            //アニメーションを初期スピードに設定
            animator.speed = animSpeed;

            //アニメーターを走っている状態に設定
            animator.SetInteger("Speed", 2);
        }
        //死亡時のアニメーションを設定
        else if (GameStateManager.CurrentState == GameStateManager.GameStates.GAMEOVER)
        {
            if (rotationStopper < 90)
            {
                //プレイヤーを横に倒す
                PlayerTransform.Rotate(Vector3.back);

                //プレイヤーが地面にめり込まないよう、若干上に移動させる
                PlayerTransform.position += new Vector3(0, 0.007f, 0);

                rotationStopper++;
            }

            //アニメーターのスピードを徐々に遅くし、最終的に止める
            if (animator.speed > 0) 
            {
                //フレーム毎にアニメーションを遅くする
                animator.speed -= 0.01f;
            }
        }
        
        //コンスタントにプレイヤーの移動速度を上げる(難易度に影響)
        if ( 600 * moveSpeed < ScoreManager.Score - previousScore) //時間的にコンスタントにするために現在の速度とスコアを使用
        {
            IncreaseSpeed(0.008f);
            previousScore = ScoreManager.Score;
        }

    }


    /// <summary>
    /// プレイヤーの移動速度とアニメーションを上昇させる
    /// </summary>
    /// <param name="increaseBy"> 速度の上がり幅 </param>
    void IncreaseSpeed(float increaseBy)
    {
        moveSpeed += increaseBy;
        animator.speed += increaseBy;
    }
}
