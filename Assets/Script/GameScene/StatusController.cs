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

    //各ステータス
    public int stress = 0;
    public int intelli = 0;
    public int skill = 0;
    public int commu = 0;

    //ストレスを少しずつ増減させるため
    private float stressTimer = 0;

    //画面左上のステータス増減の表示の数値
    public int stressChange = 0;
    public int intelliChange = 0;
    public int skillChange = 0;
    public int commuChange = 0;
    public int hpChange = 0;

    //画面左上のステータス増減の表示時間
    public float stresstime = 0;
    public float intellitime = 0;
    public float skilltime = 0;
    public float commutime = 0;
    public float hptime = 0;

    //各ステータスのバー
    [SerializeField] private Slider stressSlider;
    public Slider intelliSlider;
    public Slider skillSlider;
    public Slider commuSlider;
    [SerializeField] private Slider hpSlider;

    //各ステータスの数値表示
    [SerializeField] private TextMeshProUGUI stressValue;
    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;
    [SerializeField] private TextMeshProUGUI hpValue;

    //画面左上のステータス増減の表示
    [SerializeField] private TextMeshProUGUI stressPoint;
    [SerializeField] private TextMeshProUGUI intelliPoint;
    [SerializeField] private TextMeshProUGUI skillPoint;
    [SerializeField] private TextMeshProUGUI commuPoint;
    [SerializeField] private TextMeshProUGUI hpPoint;

    //ストレスとHPの表示を切り替える
    [SerializeField] private TextMeshProUGUI stressOrHpText;

    //ストレスが100を超えたか
    public bool stressOver = false;
    //ストレスが0か
    public bool stresszero;
    //ストレスのバーの画像
    private Image stressImage;

    //ストレスのバーの通常の色と100を超えた後の色
    private Color normalColor = new Color32(255, 150, 70, 255);
    private Color overColor = new Color32(255, 70, 70, 255);

    //学年
    public int year;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackClip;

    void Start()
    {
        //ボスステージの場合
        if (OverSceneStatus.isBoss)
        {
            //ストレスを非表示
            stressSlider.gameObject.SetActive(false);
            stressValue.enabled = false;

            //テキスト変更
            stressOrHpText.text = "会社HP";

            //今までの総合ステータス
            intelli = OverSceneStatus.intelliTotal;
            skill = OverSceneStatus.skillTotal;
            commu = OverSceneStatus.commuTotal;

            //ステータスのバーの最大値を変更
            hpSlider.maxValue = bossStatus.statuses[bossStatus.bossType].hp;
            intelliSlider.maxValue = 300;
            skillSlider.maxValue = 300;
            commuSlider.maxValue = 300;
        }
        //ボスステージではない場合
        else
        {
            //HPを非表示
            hpSlider.gameObject.SetActive(false);
            hpValue.enabled = false;
            hpPoint.enabled = false;
        }

        //画面左上のステータス増減を非表示
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
        //ボスステージの場合
        if (OverSceneStatus.isBoss)
        {
            //各ボスのHP
            hpSlider.value = bossStatus.statuses[bossStatus.bossType].hp;
            hpValue.text = bossStatus.statuses[bossStatus.bossType].hp.ToString();
        }

        //各ステータスが0より小さくならないようにする
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

        ////画面左上のステータス増減の処理

        //一定時間を過ぎたら非表示
        if (stresstime < 0)
        {
            stressPoint.enabled = false;
            stressChange = 0;
        }
        //ステータスが増減したら
        else
        {
            //表示
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

        //HPが減ったら音を鳴らす
        if (hptime == 0.5f)
        {
            audioSource.clip = attackClip;
            audioSource.Play();
        }

        if (stresszero)
        {
            stresszero = false;
        }

        //ストレスが100から0に戻ったら
        if (stress <= 0 && stressOver)
        {
            stresszero = true;
            stressImage.color = normalColor;
            stressOver = false;
        }

        //ストレスが100を超えたら
        if (stress >= 100)
        {
            stressOver = true;
            stressImage.color = overColor;
        }

        //カウントダウンが終わったかつプレイヤーがゴールしていない場合
        if (textController.isCountFinish && !playerController.isGoal)
        {
            stressTimer += Time.deltaTime;
            if(stressTimer >= 0.6)
            {
                //ストレスが100を超えた場合、少しずつ減らす
                if (stressOver)
                {
                    stress -= 10;
                }
                //超えていない場合、少しずつ減らす
                else
                {
                    stress++;
                }
                stressTimer = 0;
            }
        }

        //ステータスのバーを更新
        stressSlider.value = stress;
        intelliSlider.value = intelli;
        skillSlider.value = skill;
        commuSlider.value = commu;

        //テキストを更新
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
