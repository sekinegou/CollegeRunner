using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private StatusController statusController;

    //ゴール
    private GameObject goal;

    //アイテム
    [SerializeField] private GameObject[] goodItem;
    [SerializeField] private GameObject[] badItem;

    //アイテムの種類
    private int itemNumber;
    //ストレス値が0から100に戻ったか
    private bool reverse = false;

    void Start()
    {
        statusController = FindObjectOfType<StatusController>();
        goal = GameObject.FindWithTag("Goal");
    }

    void Update()
    {
        //カメラを通り過ぎたらorゴールと重なったら破壊
        if(transform.position.z < Camera.main.transform.position.z - 3 || transform.position.z > goal.transform.position.z - 2)
        {
            Destroy(gameObject);
        }

        //ストレス値が100を超えたら
        if(statusController.stressOver)
        {
            //成長アイテムを娯楽アイテムに変える
            changeItem();
            reverse = false;
        }

        //ストレス値が100から0に戻ったら
        if (statusController.stresszero && !reverse)
        {
            reverse = true;
            //娯楽アイテムを成長アイテムに変える
            reverseItem();
        }
    }

    //成長アイテムを娯楽アイテムに変える
    void changeItem()
    {
        //成長アイテムだったら
        if (tag == "Intelli" || tag == "Skill" || tag == "Commu")
        {
            //破壊し、娯楽アイテムをランダムで同じ場所に配置する
            Destroy(gameObject);
            itemNumber = Random.Range(0, badItem.Length);
            Instantiate(badItem[itemNumber], transform.position, badItem[itemNumber].transform.rotation);
        }
    }

    //娯楽アイテムを成長アイテムに変える
    void reverseItem()
    {
        //アイテムの半分をランダムで成長アイテムに変える
        if(Random.Range(0, 2) == 0)
        {
            Destroy(gameObject);
            itemNumber = Random.Range(0, goodItem.Length);
            Instantiate(goodItem[itemNumber], transform.position, goodItem[itemNumber].transform.rotation);
        }
    }
}
