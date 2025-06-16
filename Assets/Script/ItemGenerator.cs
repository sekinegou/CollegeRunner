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
    [SerializeField] private GameObject[] item;

    [SerializeField] private GameObject player;
    private int playerz;

    [SerializeField] private GameObject goal;

    private float[] posx = { -1.2f, 0, 1.2f };
    private float[] posy = { 0, 2 };
    private float[] posz = { 5, 10, 15, 20 };
    private int itemNumber;

    private int generatePos = 20;

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
    }

    // Update is called once per frame
    void Update()
    {
        playerz = (int)player.transform.position.z;
        if (playerz >= 20 && playerz >= generatePos && playerz <= goal.transform.position.z - 60)
        {
            ItemCreate((int)playerz + 40);
            generatePos += 20;
            Debug.Log(playerz);
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
