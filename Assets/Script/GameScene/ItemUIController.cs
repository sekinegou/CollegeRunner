using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    //�e�A�C�e���̐���
    [SerializeField] private TextMeshProUGUI intelliDescription;
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI commuDescription;

    [SerializeField] private TextMeshProUGUI[] badDiscription;

    //�A�C�e���̉摜
    [SerializeField] private Image[] item;
    [SerializeField] private Image[] bossItem;

    void Start()
    {
        //�{�X�X�e�[�W�̏ꍇ
        if (OverSceneStatus.isBoss)
        {
            //�e�L�X�g��ύX
            intelliDescription.text = "�m�\\nAttack";
            skillDescription.text = "�Z�p\nAttack";
            commuDescription.text = "�R�~����\nAttack";

            //��y�A�C�e���̐������\��
            for(int i=0;i < badDiscription.Length;i++)
            {
                badDiscription[i].enabled = false;
            }

            //�ʏ�X�e�[�W�̃A�C�e���̉摜���\��
            for(int i=0;i < item.Length;i++)
            {
                item[i].enabled = false;
            }
            //�{�X�X�e�[�W�̃A�C�e���̉摜��\��
            for(int i=0;i < bossItem.Length;i++)
            {
                bossItem[i].enabled = true;
            }
        }
        //�{�X�X�e�[�W�ł͂Ȃ��ꍇ
        else
        {
            //�{�X�X�e�[�W�̃A�C�e���̉摜���\��
            for (int i=0;i < bossItem.Length; i++)
            {
                bossItem[i].enabled = false;
            }
        }
    }
}
