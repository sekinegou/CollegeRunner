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
        //まだクリアしていない場合、ベストタイムを非表示
        if(OverSceneStatus.bestTime == 0)
        {
            text.enabled = false;
            bestTime.enabled = false;
        }
        //クリアしている場合、ベストタイムを表示
        else
        {
            min = OverSceneStatus.bestTime / 60;
            bestTime.text = min + ":" + (OverSceneStatus.bestTime % 60).ToString("00");
        }
    }
}
