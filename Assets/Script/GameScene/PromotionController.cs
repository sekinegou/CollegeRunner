using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//進級判定
public class PromotionController : MonoBehaviour
{
    [SerializeField] private StatusController statusController;
    [SerializeField] private PlayerController playerController;

    //各ステータスの進級条件を表す
    [SerializeField] private TextMeshProUGUI intelliStar;
    [SerializeField] private TextMeshProUGUI skillStar;
    [SerializeField] private TextMeshProUGUI commuStar;

    //学年ごとの各ステータスの進級条件の合計値
    private int[] yearPromo = { 3, 5, 6 };
    //各ステータスの進級条件
    public int intelliPromo;
    public int skillPromo;
    public int commuPromo;

    //進級条件を表す記号の位置
    private int[] starPos = { 96, 136, 177, 218, 258, 298, 337, 377, 417, 457, 497 };

    //各ステータスにランダムに設定される進級条件
    private int promoNumber;

    //各ステータスが進級条件を満たしたか
    private bool isIntelliPromo = false;
    private bool isSkillPromo = false;
    private bool isCommuPromo = false;

    //各ステータスのバーの画像
    private Image intelliImage;
    private Image skillImage;
    private Image commuImage;

    //各ステータスのバーの通常の色と進級条件を満たしている場合の色
    private Color normalColor = new Color32(15, 90, 15, 255);
    private Color promoColor = new Color32(105, 255, 100, 255);

    //各ステータスの進級条件を表す記号の通常の色と進級条件を満たしている場合の色
    private Color normalStarColor = new Color32(0, 0, 0, 255);
    private Color promoStarColor = new Color32(255, 255, 0, 255);

    void Start()
    {
        intelliImage = statusController.intelliSlider.fillRect.GetComponent<Image>();
        skillImage = statusController.skillSlider.fillRect.GetComponent<Image>();
        commuImage = statusController.commuSlider.fillRect.GetComponent<Image>();

        //ボスステージの場合、記号を非表示
        if (OverSceneStatus.isBoss)
        {
            intelliStar.enabled = false;
            skillStar.enabled = false;
            commuStar.enabled = false;

            intelliImage.color = promoColor;
            skillImage.color = promoColor;
            commuImage.color = promoColor;
        }
        //ボスステージではない場合
        else
        {
            //各ステータスの進級条件を設定する
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
        //プレイヤーがゴールした場合
        if (playerController.isGoal)
        {
            //全ステータスが進級条件を満たしている場合
            if(isIntelliPromo && isSkillPromo && isCommuPromo)
            {
                //進級成功
                OverSceneStatus.isPromotion = true;
            }
            else
            {
                //進級失敗
                OverSceneStatus.isPromotion = false;
            }
        }

        //ボスステージではない場合
        if (!OverSceneStatus.isBoss)
        {
            //各ステータスが進級条件を満たした場合、各画像の色を変える
            if (statusController.intelli >= intelliPromo)
            {
                intelliImage.color = promoColor;
                intelliStar.color = promoStarColor;
                isIntelliPromo = true;
            }
            //満たしていない場合、色を戻す
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
