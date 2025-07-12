using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    //public int bossCount = 3;
    public GameObject[] boss;

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
            hp = 1000,
            intelli = 30,
            skill = 15,
        },
        new Status()
        {
            hp = 1200,
            intelli = 85,
            skill = 15,
        },
        new Status()
        {
            hp = 1500,
            intelli = 85,
            skill = 70,
        }
    };

    public int bossType;
    public bool isdefeat = false;

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
        Debug.Log(bossType);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(statuses[bossType].hp <= 0)
        {
            isdefeat = true;
            statuses[bossType].hp = 0;
        }
    }
}
