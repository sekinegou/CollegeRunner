using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    //�J�E���g�_�E���̃e�L�X�g
    [SerializeField] private TextMeshProUGUI countDown;
    //�S�[��
    [SerializeField] private GameObject goal;
    //�E��̃e�L�X�g
    [SerializeField] private TextMeshProUGUI cornerText;

    //�S�[���܂ł̋���
    private int distance;

    //�J�E���g�_�E��
    private float countDownTime = 0;

    //�J�E���g�_�E�����I�������
    public bool isCountFinish = false;

    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected StatusController statusController;
    [SerializeField] private BossStatus bossStatus;

    //�{�X�X�e�[�W�̎��Ԑ���
    [SerializeField] private float bossTime = 60;

    private float time;
    //�N���A�^�C��
    private int clearTime;
    //��
    private int min;

    //���Ԑ������߂�����
    public bool isTimeFinish = false;

    void Start()
    {
        time = bossTime;
        countDown.text = "3";

        //�{�X�X�e�[�W�̏ꍇ
        if (OverSceneStatus.isBoss)
        {
            //�������Ԃ�\��
            min = (int)(time / 60);
            cornerText.text = statusController.year + "�N�I���܂�\n" + min + ":" + (time % 60).ToString("00");
        }
    }

    void Update()
    {
        //�J�E���g�_�E��
        if (3 - countDownTime > 0)
        {
            countDown.text = (3 - (int)countDownTime).ToString();
        }
        else
        {
            isCountFinish = true;
            countDown.text = "GO";
            if (3 - countDownTime < -0.5)
            {
                countDown.enabled = false;
            }
        }

        //�{�X�X�e�[�W�ł͂Ȃ��ꍇ
        if (!OverSceneStatus.isBoss)
        {
            //�v���C���[���S�[�������ꍇ
            if (playerController.isGoal == true)
            {
                countDown.text = "Goal";
                countDown.enabled = true;
                cornerText.text = statusController.year + "�N�I���܂�\n0m";
            }
            else
            {
                //�S�[���܂ł̋�����\��
                distance = (int)(goal.transform.position.z - playerController.transform.position.z);
                cornerText.text = statusController.year + "�N�I���܂�\n" + distance.ToString() + "m";
            }
        }
        //�{�X�X�e�[�W�̏ꍇ
        else
        {
            //�J�E���g�_�E�����I��������{�X���|����Ă��Ȃ��ꍇ
            if (isCountFinish && !bossStatus.isdefeat)
            {
                //�������Ԃ�\��
                if(time >= 0)
                {
                    time -= Time.deltaTime;
                }
                
                min = (int)(time / 60);
                cornerText.text = statusController.year + "�N�I���܂�\n" + min + ":" + (time % 60).ToString("00");
            }

            //�������Ԃ��߂�����
            if (time <= 0)
            {
                isTimeFinish = true;
                //�e�L�X�g���X�V
                countDown.text = "����l�����s";
                countDown.enabled = true;
            }
            //�{�X���|���ꂽ�ꍇ
            if (bossStatus.isdefeat)
            {
                //�e�L�X�g���X�V
                countDown.text = "����l��";
                countDown.enabled = true;

                //�N���A�^�C��
                clearTime = (int)(bossTime - time);

                //�N���A�^�C�����x�X�g�^�C�����Z��or�x�X�g�^�C����0�̏ꍇ
                if(clearTime < OverSceneStatus.bestTime || OverSceneStatus.bestTime == 0)
                {
                    //�x�X�g�^�C�����X�V
                    OverSceneStatus.bestTime = clearTime;
                }
            }
        }

        countDownTime += Time.deltaTime;
    }
}
