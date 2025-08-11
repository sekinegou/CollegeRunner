using System.Collections.Generic;
using UnityEngine;

//�ł��邾�����삪�y���Ȃ�悤�ɁA�I�u�W�F�N�g���ŏ��ɑS�Ĕz�u����̂ł͂Ȃ��A
//�J�����̕`�拗���̏����O�ɏ����������Ă���
public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private BossStatus bossStatus;

    //�A�C�e��
    [SerializeField] private GameObject[] item;
    [SerializeField] private GameObject[] bossItem;
    //��
    [SerializeField] private GameObject[] house;
    

    //�v���C���[
    [SerializeField] private GameObject player;
    //�v���C���[��z���W
    private int playerz;
    //�A�C�e���̎��
    private int itemNumber;

    //�S�[��
    [SerializeField] private GameObject goal;
    //���m
    [SerializeField] private GameObject road;
    //��
    [SerializeField] private GameObject wall;
    //�X��
    [SerializeField] private GameObject gaitou;

    //�A�C�e���̔z�u�ꏊ
    private float[] posx = { -1.2f, 0, 1.2f };
    private float[] posy = { 0, 2 };
    private float[] posz = { 5, 10, 15, 20 };

    //�w�N���Ƃ́A���͈͓��̃A�C�e���̐�
    private int[] itemCount = { 4, 5, 6, 6 };

    //�e�I�u�W�F�N�g�̔z�u�Ԋu
    private int itemPos = 20;
    private int roadPos = 20;
    private int wallPos = 40;
    private int gaitouPos = 20;

    //�z�u�����Ƃ̉����ɍ��킹�āA���ɔz�u����ׂ��Ƃ�z���W���X�V����
    private float leftInterval = -2;
    private float rightInterval = -2;

    //�e�Ƃ̉����̔���
    private float[] houseWidth = { 2.75f, 2.3f, 1.75f };
    //�e�Ƃ̔z�u���鍂��
    private float[] housePosy = { 2.3f, 2.33f, 2.33f };
    //�Ƃ̎��
    private int houseNumber;

    void Start()
    {
        //�{�X�X�e�[�W�̏ꍇ�A�I�������{�X��z�u
        if (OverSceneStatus.isBoss)
        {
            Instantiate(bossStatus.boss[OverSceneStatus.bossType], new Vector3(0, 0.2f, 40), bossStatus.boss[OverSceneStatus.bossType].transform.rotation);
        }

        //�A�C�e����z���W20�Ԋu�Ŕz�u
        for (int i = 0; i < 80; i += 20)
        {
            ItemCreate(i);
        }

        //����10�Ԋu�Ŕz�u
        for(int i = 10; i < 80; i += 10)
        {
            Instantiate(road, new Vector3(0, -0.9f, i), Quaternion.identity);
        }

        //�ǂ�25�Ԋu�Ŕz�u
        for (int i = 20; i < 100; i += 25)
        {
            Instantiate(wall, new Vector3(0, -1.5f, i), Quaternion.identity);
        }

        //�X����10�Ԋu�Ŕz�u
        for (int i = 0; i < 80; i += 10)
        {
            Instantiate(gaitou, new Vector3(-4, 0.7f, i), Quaternion.identity);
            Instantiate(gaitou, new Vector3(4, 0.7f, i), Quaternion.identity);
        }

        //�Ƃ�z���W100�܂ō��E�ɔz�u
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

        //�e�I�u�W�F�N�g���A�J�����̕`�拗���O���S�[���̎�O�ɔz�u���Ă���

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

    //�A�C�e�������͈͂Ƀ����_���ɔz�u����
    void ItemCreate(int n)
    {
        //���X�g�ɃA�C�e����z�u������W��ǉ�����
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

            //�{�X�X�e�[�W�ł͂Ȃ��ꍇ�A�A�C�e���������_���ɔz�u����
            if (!OverSceneStatus.isBoss)
            {
                itemNumber = Random.Range(0, item.Length);
                Instantiate(item[itemNumber], posxyz[xyz], item[itemNumber].transform.rotation);
            }
            //�{�X�X�e�[�W�̏ꍇ
            else
            {
                //�e�{�X�ɐݒ肳�ꂽ�A�C�e���̏o���m�������ɃA�C�e����z�u����
                int probability = Random.Range(0, 100);

                if (probability >= bossStatus.statuses[bossStatus.bossType].intelli) itemNumber = 0;
                else if (probability >= bossStatus.statuses[bossStatus.bossType].skill) itemNumber = 1;
                else itemNumber = 2;
                Debug.Log(itemNumber);

                Instantiate(bossItem[itemNumber], posxyz[xyz], bossItem[itemNumber].transform.rotation);
            }

            //�A�C�e����z�u�����ꏊ�̍��W���폜����
            posxyz.RemoveAt(xyz);
        }
    }

    //�Ƃ����E�ɔz�u����
    void LeftHouseCreate(int n)
    {
        houseNumber = Random.Range(0, house.Length);
        //�z�u����Ƃ̉����̔�����z���W�ɔz�u����
        leftInterval += houseWidth[houseNumber];
        Instantiate(house[houseNumber], new Vector3(-5, housePosy[houseNumber], leftInterval + n), house[houseNumber].transform.rotation);
        //�z�u�����Ƃ̉����̔���+1.5f�ɍX�V
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
