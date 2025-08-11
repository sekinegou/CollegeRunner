using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossSelectStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI intelli;
    [SerializeField] private TextMeshProUGUI skill;
    [SerializeField] private TextMeshProUGUI commu;

    void Start()
    {
        //各ステータスを表示
        intelli.text = "知能\n" + OverSceneStatus.intelliTotal.ToString();
        skill.text = "技術\n" + OverSceneStatus.skillTotal.ToString();
        commu.text = "コミュ力\n" + OverSceneStatus.commuTotal.ToString();
    }
}
