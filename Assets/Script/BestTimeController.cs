using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestTimeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI bestTime;

    private int min;

    void Start()
    {
        //�܂��N���A���Ă��Ȃ��ꍇ�A�x�X�g�^�C�����\��
        if(OverSceneStatus.bestTime == 0)
        {
            text.enabled = false;
            bestTime.enabled = false;
        }
        //�N���A���Ă���ꍇ�A�x�X�g�^�C����\��
        else
        {
            min = OverSceneStatus.bestTime / 60;
            bestTime.text = min + ":" + (OverSceneStatus.bestTime % 60).ToString("00");
        }
    }
}
