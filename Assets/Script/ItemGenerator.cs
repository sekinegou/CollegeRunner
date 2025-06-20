using System.Collections;
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

    [SerializeField] private GameObject[] item;

    [SerializeField] private GameObject player;
    private int playerz;

    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject road;

    private float[] posx = { -1.2f, 0, 1.2f };
    private float[] posy = { 0, 2 };
    private float[] posz = { 5, 10, 15, 20 };
    //private int[] rot = {}
    private int itemNumber;

    private int generatePos = 20;
    private int roadPos = 10;

    /*private struct ItemPos
    {
        public float x;
        public float y;
        public float z;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        ItemCreate(0);
        ItemCreate(20);
        ItemCreate(40);
        ItemCreate(60);

        Instantiate(road, new Vector3(0, -0.9f, 10), Quaternion.identity);
        Instantiate(road, new Vector3(0, -0.9f, 20), Quaternion.identity);
        Instantiate(road, new Vector3(0, -0.9f, 30), Quaternion.identity);
        Instantiate(road, new Vector3(0, -0.9f, 40), Quaternion.identity);
        Instantiate(road, new Vector3(0, -0.9f, 50), Quaternion.identity);
        Instantiate(road, new Vector3(0, -0.9f, 60), Quaternion.identity);
        Instantiate(road, new Vector3(0, -0.9f, 70), Quaternion.identity);
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

        if (playerz >= 20 && playerz >= roadPos && playerz <= goal.transform.position.z - 60)
        {
            Instantiate(road, new Vector3(0, -0.9f, playerz + 60), Quaternion.identity);
            roadPos += 10;
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

        for (int i = 0; i < 5; i++)
        {
            int xyz = Random.Range(0, posxyz.Count);
            //int x = Random.Range(0, posx.Length);
            //int z = Random.Range(0, posz.Length);

            itemNumber = Random.Range(0, item.Length);

            Instantiate(item[itemNumber], posxyz[xyz]/*new Vector3(posxyz[xyz].x, posxyz[xyz].y, posxyz[xyz].z + n)*/, Quaternion.identity);
            posxyz.RemoveAt(xyz);
        }
    }
}
