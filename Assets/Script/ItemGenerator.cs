using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    /*[SerializeField] private GameObject intelliPrefab;
    [SerializeField] private GameObject skillPrefab;
    [SerializeField] private GameObject commuPrefab;
    [SerializeField] private GameObject beerPrefab;
    [SerializeField] private GameObject switchPrefab;
    [SerializeField] private GameObject phonePrefab;*/

    //[SerializeField] StatusController statusController;
    [SerializeField] private BossStatus bossStatus;

    [SerializeField] private GameObject[] item;
    [SerializeField] private GameObject[] bossItem;
    [SerializeField] private GameObject[] house;
    

    [SerializeField] private GameObject player;
    private int playerz;
    private int itemNumber;

    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject road;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject gaitou;

    private float[] posx = { -1.2f, 0, 1.2f };
    private float[] posy = { 0, 2 };
    private float[] posz = { 5, 10, 15, 20 };
    //private int[] rot = {}
    private int[] itemCount = { 4, 5, 6, 6 };

    private int generatePos = 20;
    private int roadPos = 20;
    private int wallPos = 40;
    private int gaitouPos = 20;
    private float leftInterval = -2;
    private float rightInterval = -2;

    private float[] houseWidth = { 2.75f, 2.3f, 1.75f };
    private float[] housePosy = { 2.3f, 2.33f, 2.33f };
    private int houseNumber;

    /*private struct ItemPos
    {
        public float x;
        public float y;
        public float z;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(bossStatus.bossType);
        if (OverSceneStatus.isBoss)
        {
            Instantiate(bossStatus.boss[OverSceneStatus.bossType], new Vector3(0, 0.2f, 40), bossStatus.boss[OverSceneStatus.bossType].transform.rotation);
        }

        for (int i = 0; i < 80; i += 20)
        {
            ItemCreate(i);
        }

        for(int i = 10; i < 80; i += 10)
        {
            Instantiate(road, new Vector3(0, -0.9f, i), Quaternion.identity);
        }

        for (int i = 20; i < 100; i += 25)
        {
            Instantiate(wall, new Vector3(0, -1.5f, i), Quaternion.identity);
        }

        for (int i = 0; i < 80; i += 10)
        {
            Instantiate(gaitou, new Vector3(-4, 0.7f, i), Quaternion.identity);
            Instantiate(gaitou, new Vector3(4, 0.7f, i), Quaternion.identity);
        }

        while (leftInterval < 100)
        {
            LeftHouseCreate(0);
        }
        while (rightInterval < 100)
        {
            RightHouseCreate(0);
        }

        leftInterval -= 80;
        rightInterval -= 80;
    }

    // Update is called once per frame
    void Update()
    {
        playerz = (int)player.transform.position.z;
        if (playerz >= 20 && playerz >= generatePos && playerz <= goal.transform.position.z - 80)
        {
            /*if (statusController.stresszero)
            {
                statusController.stresszero = false;
            }*/
            ItemCreate((int)playerz + 60);
            generatePos += 20;
            //Debug.Log(playerz);
        }

        if (playerz >= 20 && playerz >= roadPos && playerz <= goal.transform.position.z - 70)
        {
            Instantiate(road, new Vector3(0, -0.9f, playerz + 60), Quaternion.identity);
            roadPos += 10;
            //Debug.Log(playerz);
        }

        if (playerz >= 20 && playerz >= wallPos && playerz <= goal.transform.position.z - 60)
        {
            Instantiate(wall, new Vector3(0, -1.5f, playerz + 80), Quaternion.identity);
            wallPos += 25;
            //Debug.Log(playerz);
        }

        if (playerz >= 20 && playerz >= gaitouPos && playerz <= goal.transform.position.z - 60)
        {
            Instantiate(gaitou, new Vector3(-4, 0.7f, playerz + 60), Quaternion.identity);
            Instantiate(gaitou, new Vector3(4, 0.7f, playerz + 60), Quaternion.identity);
            gaitouPos += 6;
            //Debug.Log(playerz);
        }

        if (playerz >= 20 && playerz >= leftInterval && playerz <= goal.transform.position.z - 80)
        {
            LeftHouseCreate(80);
            //Debug.Log(playerz);
        }
        if (playerz >= 20 && playerz >= rightInterval && playerz <= goal.transform.position.z - 80)
        {
            RightHouseCreate(80);
            //Debug.Log(playerz);
        }
    }

    void ItemCreate(int n)
    {
        var posxyz = new List<Vector3>();
        for (int i = 0; i < posx.Length; i++)
        {
            for (int j = 0; j < posy.Length; j++)
            {
                for(int k = 0;k < posz.Length; k++)
                {
                    posxyz.Add(new Vector3(posx[i], posy[j], posz[k] + n));
                    /*posxyz.Add(new ItemPos()
                    {
                        x = posx[i],
                        y = posy[j],
                        z = posz[k]
                    });*/
                }
            
            }
        }

        for (int i = 0; i < itemCount[OverSceneStatus.year - 1]; i++)
        {
            int xyz = Random.Range(0, posxyz.Count);
            //int x = Random.Range(0, posx.Length);
            //int z = Random.Range(0, posz.Length);

            if (!OverSceneStatus.isBoss)
            {
                itemNumber = Random.Range(0, item.Length);
                Instantiate(item[itemNumber], posxyz[xyz], item[itemNumber].transform.rotation);
            }
            else
            {
                int probability = Random.Range(0, 100);
                //Debug.Log(probability);

                if (probability >= bossStatus.statuses[bossStatus.bossType].intelli) itemNumber = 0;
                else if (probability >= bossStatus.statuses[bossStatus.bossType].skill) itemNumber = 1;
                else itemNumber = 2;
                Debug.Log(itemNumber);

                Instantiate(bossItem[itemNumber], posxyz[xyz], bossItem[itemNumber].transform.rotation);
            }

            posxyz.RemoveAt(xyz);
        }
    }

    void LeftHouseCreate(int n)
    {
        houseNumber = Random.Range(0, house.Length);
        leftInterval += houseWidth[houseNumber];
        Instantiate(house[houseNumber], new Vector3(-5, housePosy[houseNumber], leftInterval + n), house[houseNumber].transform.rotation);
        leftInterval += houseWidth[houseNumber] + 1.5f;
    }

    void RightHouseCreate(int n)
    {
        houseNumber = Random.Range(0, house.Length);
        rightInterval += houseWidth[houseNumber];
        Instantiate(house[houseNumber], new Vector3(5, housePosy[houseNumber], rightInterval + n), house[houseNumber].transform.rotation * Quaternion.Euler(0, 180, 0));
        rightInterval += houseWidth[houseNumber] + 1.5f;
    }
}
