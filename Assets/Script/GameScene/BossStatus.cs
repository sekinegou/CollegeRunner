using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    //ボス
    public GameObject[] boss;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip defeat;

    //ステータス
    public struct Status
    {
        public int hp;
        //知能ステータスに対応するアイテムの出現率
        public int intelli;
        //技術ステータスに対応するアイテムの出現率
        public int skill;
        //public int commu;
    }

    //各ボスのステータス
    public Status[] statuses =
    {
        new Status()
        {
            hp = 2000,
            intelli = 40,
            skill = 20,
        },
        new Status()
        {
            hp = 2000,
            intelli = 80,
            skill = 20,
        },
        new Status()
        {
            hp = 2000,
            intelli = 80,
            skill = 60,
        }
    };

    //ボスの種類
    public int bossType;
    //倒されたか
    public bool isdefeat = false;

    //1回だけ鳴らすためのbool
    private bool isDefeatClip = true;

    void Awake()
    {
        bossType = OverSceneStatus.bossType;
    }

    void Update()
    {
        //HPが0になったら
        if(statuses[bossType].hp <= 0)
        {
            if (isDefeatClip)
            {
                audioSource.volume = 0.2f;
                audioSource.clip = defeat;
                audioSource.Play();
                isDefeatClip = false;
            }
            isdefeat = true;
            statuses[bossType].hp = 0;
        }
    }
}
