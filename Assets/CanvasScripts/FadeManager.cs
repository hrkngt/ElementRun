using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    public Image faderImage; //フェードイメージ

    bool isInTransition;   　//透明度の変更を開始/終了する際に使用
    float transition;     　 //透明度の設定に使用
    bool isShowing;        　//フェードイン・アウトの切り替えに使用
    float duration;      　  //フェードイン・アウトにかかる時間を設定するのに使用

    bool fadingRed = false;  //死亡時に画面を半透明の赤にする際に使用
    bool hasCalled = false;  //関数が一度だけ呼ばれるようにするために使用


    private void Start()
    {
        //ゲーム開始時、画面をフェードインさせる
        Fade(false, 1);
    }

    /// <summary>
    /// 画面をフェードイン/アウトさせる
    /// </summary>
    /// <param name="showing">　イン・アウトの選択　</param>
    /// <param name="duration">　フェードイン・アウトにかかる時間を指定　</param>
    public void Fade(bool showing, float duration)
    {
        isInTransition = true;　           //フェードを開始
        isShowing = showing;　　　         //イン・アウトの選択を格納
        this.duration = duration;　        //フェードにかかる時間を格納
        transition = (isShowing) ? 0 : 1;　//イン・アウトの選択に応じて画面の初期透明度を確定
    }


    /// <summary>
    ///　画面を半透明の赤にする
    /// </summary>
    /// <param name="duration">　フェードイン・アウトにかかる時間を指定　</param>
    public void FadeRed(float duration)
    {
        isInTransition = true;　　　//フェードを開始
        isShowing = false;　　　　　//フェードアウト
        this.duration = duration;　 //フェードにかかる時間を格納
        transition = 0;　　　　　　 //初期透明度を確定

        fadingRed = true;　　　　　 //画面を赤くする
    }


    void Update()
    {

        //プレイヤー死亡時にFadeRed関数を一度だけ呼ぶ
        if (PlayerManager.Health <= 0 && !hasCalled)
        {
            FadeRed(2.0f);

            //関数が呼ばれたことを記憶
            hasCalled = true;
        }

        //ゲームポーズ時に画面をフェードアウト
        if(GameStateManager.CurrentState == GameStateManager.GameStates.PAUSED)
        {
            Fade(true, 0.01f);
        }

        //関数が呼ばれていないときは何もしない
        if (!isInTransition)
            return;

        //関数が呼ばれた際
        if (!fadingRed)　//通常のフェードイン・アウト
        {
            //イン・アウトの選択に応じて画像の透明度を変更
            transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);

            //画像の状態を更新
            faderImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        }
        else　//赤くフェードアウト
        {
            //透明度の変更
            transition += Time.deltaTime * (1 / duration);

            //画像を更新
            faderImage.color = Color.Lerp(new Color(1, 0, 0, 0), new Color(1, 0, 0, 0.5f), transition);
        }

        //フェードが完了したら終了
        if (transition > 1 || transition < 0)
        {
            //何もしない状態に戻る
            isInTransition = false;
        }

    }

}
