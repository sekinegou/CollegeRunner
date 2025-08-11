using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public bool isPush = false;

    public void Go_boss()
    {
        isPush = true;

        //進級失敗orボスステージの場合
        if (!OverSceneStatus.isPromotion || OverSceneStatus.isBoss)
        {
            OverSceneStatus.returnTitle = true;
            //ステータスをリセット
            OverSceneStatus.ResetStatus();
            SceneManager.LoadScene("Title");
            
        }
        else
        {
            //4年の場合
            if (OverSceneStatus.year == 4)
            {
                OverSceneStatus.isBoss = true;
                SceneManager.LoadScene("BossSelect");
            }
            else
            {
                SceneManager.LoadScene("GameScene");
            }
            
        }
        

    }
}
