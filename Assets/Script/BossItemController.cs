using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemController : MonoBehaviour
{
    private GameObject boss;
    private float speed = 50;
    private Vector3 bosPos;

    private bool isMove = false;

    private BossStatus bossStatus;
    private StatusController statusController;

    // Start is called before the first frame update
    void Start()
    {
        //camera = GameObject.FindWithTag("MainCamera");
        boss = GameObject.FindWithTag("Boss");

        bossStatus = FindObjectOfType<BossStatus>();
        statusController = FindObjectOfType<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z - 3 || bossStatus.isdefeat)
        {
            Destroy(gameObject);
        }
        

        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, bosPos, speed * Time.deltaTime);
        }

        bosPos = new Vector3(boss.transform.position.x, boss.transform.position.y + 3, boss.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("t");
        if (other.gameObject.tag == "Player")
        {
            
            //Debug.Log("p");
            isMove = true;
            //Vector3 current = transform.position;
            //transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, speed * Time.deltaTime);
        }

        if(isMove && other.gameObject.tag == "Boss")
        {
            //Debug.Log("b");

            if (tag == "IAttack")
            {
                bossStatus.statuses[bossStatus.bossType].hp -= statusController.intelli;
                statusController.hpChange -= statusController.intelli;

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
