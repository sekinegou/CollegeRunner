using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    //�{�X
    public GameObject[] boss;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip defeat;

    //�X�e�[�^�X
    public struct Status
    {
        public int hp;
        //�m�\�X�e�[�^�X�ɑΉ�����A�C�e���̏o����
        public int intelli;
        //�Z�p�X�e�[�^�X�ɑΉ�����A�C�e���̏o����
        public int skill;
        //public int commu;
    }

    //�e�{�X�̃X�e�[�^�X
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

    //�{�X�̎��
    public int bossType;
    //�|���ꂽ��
    public bool isdefeat = false;

    //1�񂾂��炷���߂�bool
    private bool isDefeatClip = true;

    void Awake()
    {
        bossType = OverSceneStatus.bossType;
    }

    void Update()
    {
        //HP��0�ɂȂ�����
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
