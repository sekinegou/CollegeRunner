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

        //�i�����sor�{�X�X�e�[�W�̏ꍇ
        if (!OverSceneStatus.isPromotion || OverSceneStatus.isBoss)
        {
            OverSceneStatus.returnTitle = true;
            //�X�e�[�^�X�����Z�b�g
            OverSceneStatus.ResetStatus();
            SceneManager.LoadScene("Title");
            
        }
        else
        {
            //4�N�̏ꍇ
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
