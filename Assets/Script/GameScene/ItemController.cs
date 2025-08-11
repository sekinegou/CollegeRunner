using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private StatusController statusController;

    //�S�[��
    private GameObject goal;

    //�A�C�e��
    [SerializeField] private GameObject[] goodItem;
    [SerializeField] private GameObject[] badItem;

    //�A�C�e���̎��
    private int itemNumber;
    //�X�g���X�l��0����100�ɖ߂�����
    private bool reverse = false;

    void Start()
    {
        statusController = FindObjectOfType<StatusController>();
        goal = GameObject.FindWithTag("Goal");
    }

    void Update()
    {
        //�J������ʂ�߂�����or�S�[���Əd�Ȃ�����j��
        if(transform.position.z < Camera.main.transform.position.z - 3 || transform.position.z > goal.transform.position.z - 2)
        {
            Destroy(gameObject);
        }

        //�X�g���X�l��100�𒴂�����
        if(statusController.stressOver)
        {
            //�����A�C�e������y�A�C�e���ɕς���
            changeItem();
            reverse = false;
        }

        //�X�g���X�l��100����0�ɖ߂�����
        if (statusController.stresszero && !reverse)
        {
            reverse = true;
            //��y�A�C�e���𐬒��A�C�e���ɕς���
            reverseItem();
        }
    }

    //�����A�C�e������y�A�C�e���ɕς���
    void changeItem()
    {
        //�����A�C�e����������
        if (tag == "Intelli" || tag == "Skill" || tag == "Commu")
        {
            //�j�󂵁A��y�A�C�e���������_���œ����ꏊ�ɔz�u����
            Destroy(gameObject);
            itemNumber = Random.Range(0, badItem.Length);
            Instantiate(badItem[itemNumber], transform.position, badItem[itemNumber].transform.rotation);
        }
    }

    //��y�A�C�e���𐬒��A�C�e���ɕς���
    void reverseItem()
    {
        //�A�C�e���̔����������_���Ő����A�C�e���ɕς���
        if(Random.Range(0, 2) == 0)
        {
            Destroy(gameObject);
            itemNumber = Random.Range(0, goodItem.Length);
            Instantiate(goodItem[itemNumber], transform.position, goodItem[itemNumber].transform.rotation);
        }
    }
}
