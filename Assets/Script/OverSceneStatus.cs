using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ÓI�N���X
public static class OverSceneStatus
{
    //1�N���Ƃ̊e�X�e�[�^�X
    public static int stressStatus;
    public static int intelliStatus;
    public static int skillStatus;
    public static int commuStatus;

    //�e�X�e�[�^�X�̍��v
    public static int stressTotal = 0;
    public static int intelliTotal = 0;
    public static int skillTotal = 0;
    public static int commuTotal = 0;

    //�w�N
    public static int year = 1;

    //�{�X�X�e�[�W��
    public static bool isBoss = false;

    //�{�X�̎��
    public static int bossType;

    //�i������������
    public static bool isPromotion;

    //�x�X�g�^�C��
    public static int bestTime = 0;

    //�A�E����������
    public static bool isEmployment;

    //�^�C�g���ɖ߂邩
    public static bool returnTitle = false;

    //�X�e�[�^�X�����Z�b�g
    public static void ResetStatus()
    {
        stressTotal = 0;
        intelliTotal = 0;
        skillTotal = 0;
        commuTotal = 0;

        year = 1;
        isBoss = false;
    }
}
