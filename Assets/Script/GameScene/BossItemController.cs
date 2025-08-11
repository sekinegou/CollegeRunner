using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemController : MonoBehaviour
{
    //�{�X
    private GameObject boss;
    //�A�C�e���擾��A�{�X�Ɍ������Ă����Ƃ��̑���
    private float speed = 50;
    //�{�X�̈ʒu
    private Vector3 bosPos;

    //�A�C�e�����l��������
    private bool isObtain = false;

    private BossStatus bossStatus;
    private StatusController statusController;

    //�{�X�ɓ����������̉�
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
        //�J������ʂ�߂�����or�{�X���|���ꂽ��j��
        if (transform.position.z < Camera.main.transform.position.z - 3 || bossStatus.isdefeat)
        {
            Destroy(gameObject);
        }
        
        //�v���C���[���l��������{�X�Ɍ������Ă���
        if (isObtain)
        {
            transform.position = Vector3.MoveTowards(transform.position, bosPos, speed * Time.deltaTime);
        }

        //�{�X�̈ʒu���X�V
        bosPos = new Vector3(boss.transform.position.x, boss.transform.position.y + 3, boss.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�ɓ�������
        if (other.gameObject.tag == "Player")
        {
            isObtain = true;
        }

        //�{�X�Ɍ������Ă����A�{�X�ɓ���������
        if(isObtain && other.gameObject.tag == "Boss")
        {
            audioSource.Play();

            //�e�A�C�e�����Ƃɏ���
            if (tag == "IAttack")
            {
                //�{�X��HP���e�X�e�[�^�X�����炷
                bossStatus.statuses[bossStatus.bossType].hp -= statusController.intelli;
                //��ʍ���ɕ\������HP�����̕\��
                statusController.hpChange -= statusController.intelli;

                //�\������
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
