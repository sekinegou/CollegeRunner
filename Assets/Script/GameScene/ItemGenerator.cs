using System.Collections.Generic;
using UnityEngine;

//できるだけ動作が軽くなるように、オブジェクトを最初に全て配置するのではなく、
//カメラの描画距離の少し外に順次生成している
public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private BossStatus bossStatus;

    //アイテム
    [SerializeField] private GameObject[] item;
    [SerializeField] private GameObject[] bossItem;
    //家
    [SerializeField] private GameObject[] house;
    

    //プレイヤー
    [SerializeField] private GameObject player;
    //プレイヤーのz座標
    private int playerz;
    //アイテムの種類
    private int itemNumber;

    //ゴール
    [SerializeField] private GameObject goal;
    //未知
    [SerializeField] private GameObject road;
    //壁
    [SerializeField] private GameObject wall;
    //街灯
    [SerializeField] private GameObject gaitou;

    //アイテムの配置場所
    private float[] posx = { -1.2f, 0, 1.2f };
    private float[] posy = { 0, 2 };
    private float[] posz = { 5, 10, 15, 20 };

    //学年ごとの、一定範囲内のアイテムの数
    private int[] itemCount = { 4, 5, 6, 6 };

    //各オブジェクトの配置間隔
    private int itemPos = 20;
    private int roadPos = 20;
    private int wallPos = 40;
    private int gaitouPos = 20;

    //配置した家の横幅に合わせて、次に配置するべき家のz座標を更新する
    private float leftInterval = -2;
    private float rightInterval = -2;

    //各家の横幅の半分
    private float[] houseWidth = { 2.75f, 2.3f, 1.75f };
    //各家の配置する高さ
    private float[] housePosy = { 2.3f, 2.33f, 2.33f };
    //家の種類
    private int houseNumber;

    void Start()
    {
        //ボスステージの場合、選択したボスを配置
        if (OverSceneStatus.isBoss)
        {
            Instantiate(bossStatus.boss[OverSceneStatus.bossType], new Vector3(0, 0.2f, 40), bossStatus.boss[OverSceneStatus.bossType].transform.rotation);
        }

        //アイテムをz座標20間隔で配置
        for (int i = 0; i < 80; i += 20)
        {
            ItemCreate(i);
        }

        //道を10間隔で配置
        for(int i = 10; i < 80; i += 10)
        {
            Instantiate(road, new Vector3(0, -0.9f, i), Quaternion.identity);
        }

        //壁を25間隔で配置
        for (int i = 20; i < 100; i += 25)
        {
            Instantiate(wall, new Vector3(0, -1.5f, i), Quaternion.identity);
        }

        //街灯を10間隔で配置
        for (int i = 0; i < 80; i += 10)
        {
            Instantiate(gaitou, new Vector3(-4, 0.7f, i), Quaternion.identity);
            Instantiate(gaitou, new Vector3(4, 0.7f, i), Quaternion.identity);
        }

        //家をz座標100まで左右に配置
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

    void Update()
    {
        playerz = (int)player.transform.position.z;

        //各オブジェクトを、カメラの描画距離外かつゴールの手前に配置している

        if (playerz >= 20 && playerz >= itemPos && playerz <= goal.transform.position.z - 80)
        {
            ItemCreate((int)playerz + 60);
            itemPos += 20;
        }

        if (playerz >= 20 && playerz >= roadPos && playerz <= goal.transform.position.z - 70)
        {
            Instantiate(road, new Vector3(0, -0.9f, playerz + 60), Quaternion.identity);
            roadPos += 10;
        }

        if (playerz >= 20 && playerz >= wallPos && playerz <= goal.transform.position.z - 60)
        {
            Instantiate(wall, new Vector3(0, -1.5f, playerz + 80), Quaternion.identity);
            wallPos += 25;
        }

        if (playerz >= 20 && playerz >= gaitouPos && playerz <= goal.transform.position.z - 60)
        {
            Instantiate(gaitou, new Vector3(-4, 0.7f, playerz + 60), Quaternion.identity);
            Instantiate(gaitou, new Vector3(4, 0.7f, playerz + 60), Quaternion.identity);
            gaitouPos += 6;
        }

        if (playerz >= 20 && playerz >= leftInterval && playerz <= goal.transform.position.z - 80)
        {
            LeftHouseCreate(80);
        }
        if (playerz >= 20 && playerz >= rightInterval && playerz <= goal.transform.position.z - 80)
        {
            RightHouseCreate(80);
        }
    }

    //アイテムを一定範囲にランダムに配置する
    void ItemCreate(int n)
    {
        //リストにアイテムを配置する座標を追加する
        var posxyz = new List<Vector3>();
        for (int i = 0; i < posx.Length; i++)
        {
            for (int j = 0; j < posy.Length; j++)
            {
                for(int k = 0;k < posz.Length; k++)
                {
                    posxyz.Add(new Vector3(posx[i], posy[j], posz[k] + n));
                }
            
            }
        }

        for (int i = 0; i < itemCount[OverSceneStatus.year - 1]; i++)
        {
            int xyz = Random.Range(0, posxyz.Count);

            //ボスステージではない場合、アイテムをランダムに配置する
            if (!OverSceneStatus.isBoss)
            {
                itemNumber = Random.Range(0, item.Length);
                Instantiate(item[itemNumber], posxyz[xyz], item[itemNumber].transform.rotation);
            }
            //ボスステージの場合
            else
            {
                //各ボスに設定されたアイテムの出現確率を元にアイテムを配置する
                int probability = Random.Range(0, 100);

                if (probability >= bossStatus.statuses[bossStatus.bossType].intelli) itemNumber = 0;
                else if (probability >= bossStatus.statuses[bossStatus.bossType].skill) itemNumber = 1;
                else itemNumber = 2;
                Debug.Log(itemNumber);

                Instantiate(bossItem[itemNumber], posxyz[xyz], bossItem[itemNumber].transform.rotation);
            }

            //アイテムを配置した場所の座標を削除する
            posxyz.RemoveAt(xyz);
        }
    }

    //家を左右に配置する
    void LeftHouseCreate(int n)
    {
        houseNumber = Random.Range(0, house.Length);
        //配置する家の横幅の半分のz座標に配置する
        leftInterval += houseWidth[houseNumber];
        Instantiate(house[houseNumber], new Vector3(-5, housePosy[houseNumber], leftInterval + n), house[houseNumber].transform.rotation);
        //配置した家の横幅の半分+1.5fに更新
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
