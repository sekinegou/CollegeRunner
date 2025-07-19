using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossSelectStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI intelli;
    [SerializeField] private TextMeshProUGUI skill;
    [SerializeField] private TextMeshProUGUI commu;

    // Start is called before the first frame update
    void Start()
    {
        intelli.text = "�m�\\n" + OverSceneStatus.intelliTotal.ToString();
        skill.text = "�Z�p\n" + OverSceneStatus.skillTotal.ToString();
        commu.text = "�R�~����\n" + OverSceneStatus.commuTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
