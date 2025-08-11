using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//�i������
public class PromotionController : MonoBehaviour
{
    [SerializeField] private StatusController statusController;
    [SerializeField] private PlayerController playerController;

    //�e�X�e�[�^�X�̐i��������\��
    [SerializeField] private TextMeshProUGUI intelliStar;
    [SerializeField] private TextMeshProUGUI skillStar;
    [SerializeField] private TextMeshProUGUI commuStar;

    //�w�N���Ƃ̊e�X�e�[�^�X�̐i�������̍��v�l
    private int[] yearPromo = { 3, 5, 6 };
    //�e�X�e�[�^�X�̐i������
    public int intelliPromo;
    public int skillPromo;
    public int commuPromo;

    //�i��������\���L���̈ʒu
    private int[] starPos = { 96, 136, 177, 218, 258, 298, 337, 377, 417, 457, 497 };

    //�e�X�e�[�^�X�Ƀ����_���ɐݒ肳���i������
    private int promoNumber;

    //�e�X�e�[�^�X���i�������𖞂�������
    private bool isIntelliPromo = false;
    private bool isSkillPromo = false;
    private bool isCommuPromo = false;

    //�e�X�e�[�^�X�̃o�[�̉摜
    private Image intelliImage;
    private Image skillImage;
    private Image commuImage;

    //�e�X�e�[�^�X�̃o�[�̒ʏ�̐F�Ɛi�������𖞂����Ă���ꍇ�̐F
    private Color normalColor = new Color32(15, 90, 15, 255);
    private Color promoColor = new Color32(105, 255, 100, 255);

    //�e�X�e�[�^�X�̐i��������\���L���̒ʏ�̐F�Ɛi�������𖞂����Ă���ꍇ�̐F
    private Color normalStarColor = new Color32(0, 0, 0, 255);
    private Color promoStarColor = new Color32(255, 255, 0, 255);

    void Start()
    {
        intelliImage = statusController.intelliSlider.fillRect.GetComponent<Image>();
        skillImage = statusController.skillSlider.fillRect.GetComponent<Image>();
        commuImage = statusController.commuSlider.fillRect.GetComponent<Image>();

        //�{�X�X�e�[�W�̏ꍇ�A�L�����\��
        if (OverSceneStatus.isBoss)
        {
            intelliStar.enabled = false;
            skillStar.enabled = false;
            commuStar.enabled = false;

            intelliImage.color = promoColor;
            skillImage.color = promoColor;
            commuImage.color = promoColor;
        }
        //�{�X�X�e�[�W�ł͂Ȃ��ꍇ
        else
        {
            //�e�X�e�[�^�X�̐i��������ݒ肷��
            promoNumber = Random.Range(0, yearPromo[OverSceneStatus.year - 1] + 1);
            intelliPromo = promoNumber * 10;
            intelliStar.rectTransform.anchoredPosition = new Vector2(starPos[promoNumber], intelliStar.rectTransform.anchoredPosition.y);

            yearPromo[OverSceneStatus.year - 1] -= promoNumber;
            promoNumber = Random.Range(0, yearPromo[OverSceneStatus.year - 1] + 1);
            Debug.Log(promoNumber);
            skillPromo = promoNumber * 10;
            skillStar.rectTransform.anchoredPosition = new Vector2(starPos[promoNumber], skillStar.rectTransform.anchoredPosition.y);

            promoNumber = yearPromo[OverSceneStatus.year - 1] - promoNumber;
            commuPromo = promoNumber * 10;
            commuStar.rectTransform.anchoredPosition = new Vector2(starPos[promoNumber], commuStar.rectTransform.anchoredPosition.y);
        }
    }

    void Update()
    {
        //�v���C���[���S�[�������ꍇ
        if (playerController.isGoal)
        {
            //�S�X�e�[�^�X���i�������𖞂����Ă���ꍇ
            if(isIntelliPromo && isSkillPromo && isCommuPromo)
            {
                //�i������
                OverSceneStatus.isPromotion = true;
            }
            else
            {
                //�i�����s
                OverSceneStatus.isPromotion = false;
            }
        }

        //�{�X�X�e�[�W�ł͂Ȃ��ꍇ
        if (!OverSceneStatus.isBoss)
        {
            //�e�X�e�[�^�X���i�������𖞂������ꍇ�A�e�摜�̐F��ς���
            if (statusController.intelli >= intelliPromo)
            {
                intelliImage.color = promoColor;
                intelliStar.color = promoStarColor;
                isIntelliPromo = true;
            }
            //�������Ă��Ȃ��ꍇ�A�F��߂�
            else
            {
                intelliImage.color = normalColor;
                intelliStar.color = normalStarColor;
                isIntelliPromo = false;
            }
            if (statusController.skill >= skillPromo)
            {
                skillImage.color = promoColor;
                skillStar.color = promoStarColor;
                isSkillPromo = true;
            }
            else
            {
                skillImage.color = normalColor;
                skillStar.color = normalStarColor;
                isSkillPromo = false;
            }
            if (statusController.commu >= commuPromo)
            {
                commuImage.color = promoColor;
                commuStar.color = promoStarColor;
                isCommuPromo = true;
            }
            else
            {
                commuImage.color = normalColor;
                commuStar.color = normalStarColor;
                isCommuPromo = false;
            }
        }
    }
}
