using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    //Next�̃{�^��
    [SerializeField] private NextButton nextButton;

    //�e�X�e�[�^�X�̃o�[
    [SerializeField] private Slider intelliSlider;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private Slider commuSlider;

    //�e�X�e�[�^�X
    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;


    [SerializeField] private TextMeshProUGUI sinkyuu;

    //�w�N
    public int year;

    //�e�X�e�[�^�X
    private int intelli;
    private int skill;
    private int commu;

    //�e�X�e�[�^�X�̍��v
    private int intelliTotal;
    private int skillTotal;
    private int commuTotal;

    //���v�X�e�[�^�X���オ�鉉�o���I�������
    private bool isStatusDirection = false;

    private float time = 0;

    void Start()
    {
        //�e�ϐ���ÓI�N���X����X�V
        intelli = OverSceneStatus.intelliStatus;
        skill = OverSceneStatus.skillStatus;
        commu = OverSceneStatus.commuStatus;

        intelliTotal = OverSceneStatus.intelliTotal;
        skillTotal = OverSceneStatus.skillTotal;
        commuTotal = OverSceneStatus.commuTotal;

        OverSceneStatus.intelliTotal += OverSceneStatus.intelliStatus;
        OverSceneStatus.skillTotal += OverSceneStatus.skillStatus;
        OverSceneStatus.commuTotal += OverSceneStatus.commuStatus;

        year = OverSceneStatus.year;
        OverSceneStatus.year++;

        //�{�X�X�e�[�W�̏ꍇ
        if (OverSceneStatus.isBoss)
        {
            //�A�E�ۂɂ���ăe�L�X�g���X�V
            if (OverSceneStatus.isEmployment)
            {
                sinkyuu.text = "�A�E����";
            }
            else
            {
                sinkyuu.text = "�A�E���s";
            }

            intelliValue.text = intelliTotal.ToString();
            skillValue.text = skillTotal.ToString();
            commuValue.text = commuTotal.ToString();
        }
        //�{�X�X�e�[�W�ł͂Ȃ��ꍇ
        else
        {
            //�i���ۂɂ���ăe�L�X�g���X�V
            if (OverSceneStatus.isPromotion)
            {
                sinkyuu.text = "�i��!!";

            }
            else
            {
                sinkyuu.text = "���N";
            }

            intelliValue.text = intelliTotal.ToString() + " �� " + intelli.ToString();
            skillValue.text = skillTotal.ToString() + " �� " + skill.ToString();
            commuValue.text = commuTotal.ToString() + " �� " + commu.ToString();
        }
        

        intelliSlider.value = intelliTotal;
        skillSlider.value = skillTotal;
        commuSlider.value = commuTotal;
    }

    void Update()
    {
        //�{�X�X�e�[�Wor�^�C�g���ɖ߂�ꍇ
        if(OverSceneStatus.isBoss || OverSceneStatus.returnTitle) return;

        //Next�{�^���������ꂽ�ꍇ
        if (nextButton.isPush)
        {
            intelliTotal = OverSceneStatus.intelliTotal;
            skillTotal = OverSceneStatus.skillTotal;
            commuTotal = OverSceneStatus.commuTotal;

            intelliSlider.value = intelliTotal;
            skillSlider.value = skillTotal;
            commuSlider.value = commuTotal;

            //���v�X�e�[�^�X�݂̂�\������
            StatusDisEnable();

            return;
        }

        //���v�X�e�[�^�X���オ�鉉�o
        Invoke("StatusDirection", 0.5f);

        //�S�Ẳ��o���I�������
        if (isStatusDirection)
        {
            
            time += Time.deltaTime;

            if(time > 0.03f)
            {
                //���v�X�e�[�^�X�݂̂�\������
                Invoke("StatusDisEnable", 0.5f);
                return;
            }
        }
        
        //�e�e�L�X�g�̍X�V
        intelliSlider.value = intelliTotal;
        skillSlider.value = skillTotal;
        commuSlider.value = commuTotal;

        intelliValue.text = intelliTotal.ToString() + " �� " + intelli.ToString();
        skillValue.text = skillTotal.ToString() + " �� " + skill.ToString();
        commuValue.text = commuTotal.ToString() + " �� " + commu.ToString();
    }

    //���v�X�e�[�^�X���オ�鉉�o
    private void StatusDirection()
    {

        //���v�X�e�[�^�X���グ��
        if (intelli > 0)
        {
            intelli--;
            intelliTotal++;
        }
        if (skill > 0)
        {
            skill--;
            skillTotal++;
        }
        if (commu > 0)
        {
            commu--;
            commuTotal++;
        }

        //�S�Ẳ��o���I�������
        if (intelli == 0 && skill == 0 && commu == 0) isStatusDirection = true;
    }

    //���v�X�e�[�^�X�݂̂�\������
    private void StatusDisEnable()
    {
        intelliValue.text = intelliTotal.ToString();
        skillValue.text = skillTotal.ToString();
        commuValue.text = commuTotal.ToString();
    }
}
