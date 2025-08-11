using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemController : MonoBehaviour
{
    //ボス
    private GameObject boss;
    //アイテム取得後、ボスに向かっていくときの速さ
    private float speed = 50;
    //ボスの位置
    private Vector3 bosPos;

    //アイテムを獲得したか
    private bool isObtain = false;

    private BossStatus bossStatus;
    private StatusController statusController;

    //ボスに当たった時の音
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        boss = GameObject.FindWithTag("Boss");

        bossStatus = FindObjectOfType<BossStatus>();
        statusController = FindObjectOfType<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        //カメラを通り過ぎたらorボスが倒されたら破壊
        if (transform.position.z < Camera.main.transform.position.z - 3 || bossStatus.isdefeat)
        {
            Destroy(gameObject);
        }
        
        //プレイヤーが獲得したらボスに向かっていく
        if (isObtain)
        {
            transform.position = Vector3.MoveTowards(transform.position, bosPos, speed * Time.deltaTime);
        }

        //ボスの位置を更新
        bosPos = new Vector3(boss.transform.position.x, boss.transform.position.y + 3, boss.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーに当たった
        if (other.gameObject.tag == "Player")
        {
            isObtain = true;
        }

        //ボスに向かっていき、ボスに当たったら
        if(isObtain && other.gameObject.tag == "Boss")
        {
            audioSource.Play();

            //各アイテムごとに処理
            if (tag == "IAttack")
            {
                //ボスのHPを各ステータス分減らす
                bossStatus.statuses[bossStatus.bossType].hp -= statusController.intelli;
                //画面左上に表示するHP増減の表示
                statusController.hpChange -= statusController.intelli;

                //表示時間
                statusController.hptime = 0.5f;
            }
            if (tag == "SAttack")
            {
                bossStatus.statuses[bossStatus.bossType].hp -= statusController.skill;
                statusController.hpChange -= statusController.skill;

                statusController.hptime = 0.5f;
            }
            if (tag == "CAttack")
            {
                bossStatus.statuses[bossStatus.bossType].hp -= statusController.commu;
                statusController.hpChange -= statusController.commu;

                statusController.hptime = 0.5f;
            }
            Destroy(gameObject);
        }
    }
}
