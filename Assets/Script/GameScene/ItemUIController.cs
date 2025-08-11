using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    //各アイテムの説明
    [SerializeField] private TextMeshProUGUI intelliDescription;
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI commuDescription;

    [SerializeField] private TextMeshProUGUI[] badDiscription;

    //アイテムの画像
    [SerializeField] private Image[] item;
    [SerializeField] private Image[] bossItem;

    void Start()
    {
        //ボスステージの場合
        if (OverSceneStatus.isBoss)
        {
            //テキストを変更
            intelliDescription.text = "知能\nAttack";
            skillDescription.text = "技術\nAttack";
            commuDescription.text = "コミュ力\nAttack";

            //娯楽アイテムの説明を非表示
            for(int i=0;i < badDiscription.Length;i++)
            {
                badDiscription[i].enabled = false;
            }

            //通常ステージのアイテムの画像を非表示
            for(int i=0;i < item.Length;i++)
            {
                item[i].enabled = false;
            }
            //ボスステージのアイテムの画像を表示
            for(int i=0;i < bossItem.Length;i++)
            {
                bossItem[i].enabled = true;
            }
        }
        //ボスステージではない場合
        else
        {
            //ボスステージのアイテムの画像を非表示
            for (int i=0;i < bossItem.Length; i++)
            {
                bossItem[i].enabled = false;
            }
        }
    }
}
