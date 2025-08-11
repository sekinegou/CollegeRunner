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
        //�e�X�e�[�^�X��\��
        intelli.text = "�m�\\n" + OverSceneStatus.intelliTotal.ToString();
        skill.text = "�Z�p\n" + OverSceneStatus.skillTotal.ToString();
        commu.text = "�R�~����\n" + OverSceneStatus.commuTotal.ToString();
    }
}
