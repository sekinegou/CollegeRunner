using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    //public int bossCount = 3;
    public GameObject[] boss;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip defeatClip;

    public struct Status
    {
        public int hp;
        public int intelli;
        public int skill;
        //public int commu;
    }

    /*public Status bossA = new Status()
    {
        hp = 100,
        intelli = 50,
        skill = 25,
    };
    public Status bossB = new Status()
    {
        hp = 120,
        intelli = 75,
        skill = 25,
    };
    public Status bossC = new Status()
    {
        hp = 150,
        intelli = 75,
        skill = 50,
    };*/

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

    public int bossType;
    public bool isdefeat = false;

    private bool isDefeatClip = true;

    // Start is called before the first frame update
    /*void Awake()
    {
        statuses = new Status[boss.Length];

        statuses[0] = bossA;
        statuses[1] = bossB;
        statuses[2] = bossC;
    }*/
    void Awake()
    {
        bossType = OverSceneStatus.bossType;
        //boss = new GameObject[bossCount];
        //Debug.Log(bossType);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(statuses[bossType].hp <= 0)
        {
            if (isDefeatClip)
            {
                audioSource.clip = defeatClip;
                audioSource.volume = 0.2f;
                audioSource.Play();
                isDefeatClip = false;
            }
            isdefeat = true;
            statuses[bossType].hp = 0;
        }
    }
}
