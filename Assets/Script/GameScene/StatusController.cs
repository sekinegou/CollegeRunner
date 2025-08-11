using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField] private BossStatus bossStatus;
    [SerializeField] private PromotionController promotionController;
    [SerializeField] private TextController textController;
    [SerializeField] private PlayerController playerController;

    //�e�X�e�[�^�X
    public int stress = 0;
    public int intelli = 0;
    public int skill = 0;
    public int commu = 0;

    //�X�g���X�����������������邽��
    private float stressTimer = 0;

    //��ʍ���̃X�e�[�^�X�����̕\���̐��l
    public int stressChange = 0;
    public int intelliChange = 0;
    public int skillChange = 0;
    public int commuChange = 0;
    public int hpChange = 0;

    //��ʍ���̃X�e�[�^�X�����̕\������
    public float stresstime = 0;
    public float intellitime = 0;
    public float skilltime = 0;
    public float commutime = 0;
    public float hptime = 0;

    //�e�X�e�[�^�X�̃o�[
    [SerializeField] private Slider stressSlider;
    public Slider intelliSlider;
    public Slider skillSlider;
    public Slider commuSlider;
    [SerializeField] private Slider hpSlider;

    //�e�X�e�[�^�X�̐��l�\��
    [SerializeField] private TextMeshProUGUI stressValue;
    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;
    [SerializeField] private TextMeshProUGUI hpValue;

    //��ʍ���̃X�e�[�^�X�����̕\��
    [SerializeField] private TextMeshProUGUI stressPoint;
    [SerializeField] private TextMeshProUGUI intelliPoint;
    [SerializeField] private TextMeshProUGUI skillPoint;
    [SerializeField] private TextMeshProUGUI commuPoint;
    [SerializeField] private TextMeshProUGUI hpPoint;

    //�X�g���X��HP�̕\����؂�ւ���
    [SerializeField] private TextMeshProUGUI stressOrHpText;

    //�X�g���X��100�𒴂�����
    public bool stressOver = false;
    //�X�g���X��0��
    public bool stresszero;
    //�X�g���X�̃o�[�̉摜
    private Image stressImage;

    //�X�g���X�̃o�[�̒ʏ�̐F��100�𒴂�����̐F
    private Color normalColor = new Color32(255, 150, 70, 255);
    private Color overColor = new Color32(255, 70, 70, 255);

    //�w�N
    public int year;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackClip;

    void Start()
    {
        //�{�X�X�e�[�W�̏ꍇ
        if (OverSceneStatus.isBoss)
        {
            //�X�g���X���\��
            stressSlider.gameObject.SetActive(false);
            stressValue.enabled = false;

            //�e�L�X�g�ύX
            stressOrHpText.text = "���HP";

            //���܂ł̑����X�e�[�^�X
            intelli = OverSceneStatus.intelliTotal;
            skill = OverSceneStatus.skillTotal;
            commu = OverSceneStatus.commuTotal;

            //�X�e�[�^�X�̃o�[�̍ő�l��ύX
            hpSlider.maxValue = bossStatus.statuses[bossStatus.bossType].hp;
            intelliSlider.maxValue = 300;
            skillSlider.maxValue = 300;
            commuSlider.maxValue = 300;
        }
        //�{�X�X�e�[�W�ł͂Ȃ��ꍇ
        else
        {
            //HP���\��
            hpSlider.gameObject.SetActive(false);
            hpValue.enabled = false;
            hpPoint.enabled = false;
        }

        //��ʍ���̃X�e�[�^�X�������\��
        stressPoint.enabled = false;
        intelliPoint.enabled = false;
        skillPoint.enabled = false;
        commuPoint.enabled = false;
        hpPoint.enabled = false;

        stressImage = stressSlider.fillRect.GetComponent<Image>();

        year = OverSceneStatus.year;
    }

    void Update()
    {
        //�{�X�X�e�[�W�̏ꍇ
        if (OverSceneStatus.isBoss)
        {
            //�e�{�X��HP
            hpSlider.value = bossStatus.statuses[bossStatus.bossType].hp;
            hpValue.text = bossStatus.statuses[bossStatus.bossType].hp.ToString();
        }

        //�e�X�e�[�^�X��0��菬�����Ȃ�Ȃ��悤�ɂ���
        if(stress < 0)
        {
            stress = 0;
        }
        if(intelli < 0)
        {
            intelli = 0;
        }
        if(skill < 0)
        {
            skill = 0;
        }
        if(commu < 0)
        {
            commu = 0;
        }

        ////��ʍ���̃X�e�[�^�X�����̏���

        //��莞�Ԃ��߂������\��
        if (stresstime < 0)
        {
            stressPoint.enabled = false;
            stressChange = 0;
        }
        //�X�e�[�^�X������������
        else
        {
            //�\��
            if (stressChange > 0)
            {
                stressPoint.text = "+" + stressChange.ToString();
            }
            else
            {
                stressPoint.text = stressChange.ToString();
            }
            stressPoint.enabled = true;
        }

        if (intellitime < 0)
        {
            intelliPoint.enabled = false;
            intelliChange = 0;
        }
        else
        {
            if (intelliChange > 0)
            {
                intelliPoint.text = "+" + intelliChange.ToString();
            }
            else
            {
                intelliPoint.text = intelliChange.ToString();
            }
            intelliPoint.enabled = true;
        }

        if (skilltime < 0)
        {
            skillPoint.enabled = false;
            skillChange = 0;
        }
        else
        {
            if (skillChange > 0)
            {
                skillPoint.text = "+" + skillChange.ToString();
            }
            else
            {
                skillPoint.text = skillChange.ToString();
            }
            skillPoint.enabled = true;
        }

        if (commutime < 0)
        {
            commuPoint.enabled = false;
            commuChange = 0;
        }
        else
        {
            if (commuChange > 0)
            {
                commuPoint.text = "+" + commuChange.ToString();
            }
            else
            {
                commuPoint.text = commuChange.ToString();
            }
            commuPoint.enabled = true;
        }

        if(hptime < 0)
        {
            hpPoint.enabled = false;
            hpChange = 0;
        }
        else
        {
            hpPoint.text = hpChange.ToString();

            hpPoint.enabled = true;
        }

        //HP���������特��炷
        if (hptime == 0.5f)
        {
            audioSource.clip = attackClip;
            audioSource.Play();
        }

        if (stresszero)
        {
            stresszero = false;
        }

        //�X�g���X��100����0�ɖ߂�����
        if (stress <= 0 && stressOver)
        {
            stresszero = true;
            stressImage.color = normalColor;
            stressOver = false;
        }

        //�X�g���X��100�𒴂�����
        if (stress >= 100)
        {
            stressOver = true;
            stressImage.color = overColor;
        }

        //�J�E���g�_�E�����I��������v���C���[���S�[�����Ă��Ȃ��ꍇ
        if (textController.isCountFinish && !playerController.isGoal)
        {
            stressTimer += Time.deltaTime;
            if(stressTimer >= 0.6)
            {
                //�X�g���X��100�𒴂����ꍇ�A���������炷
                if (stressOver)
                {
                    stress -= 10;
                }
                //�����Ă��Ȃ��ꍇ�A���������炷
                else
                {
                    stress++;
                }
                stressTimer = 0;
            }
        }

        //�X�e�[�^�X�̃o�[���X�V
        stressSlider.value = stress;
        intelliSlider.value = intelli;
        skillSlider.value = skill;
        commuSlider.value = commu;

        //�e�L�X�g���X�V
        stressValue.text = stress.ToString();
        intelliValue.text = intelli.ToString() + "/" + promotionController.intelliPromo.ToString();
        skillValue.text = skill.ToString() + "/" + promotionController.skillPromo.ToString();
        commuValue.text = commu.ToString() + "/" + promotionController.commuPromo.ToString();

        stresstime -= Time.deltaTime;
        intellitime -= Time.deltaTime;
        skilltime -= Time.deltaTime;
        commutime -= Time.deltaTime;

        hptime -= Time.deltaTime;
    }
}
