using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromotionController : MonoBehaviour
{
    [SerializeField] private StatusController statusController;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private TextMeshProUGUI intelliStar;
    [SerializeField] private TextMeshProUGUI skillStar;
    [SerializeField] private TextMeshProUGUI commuStar;

    private int[] yearPromo = { 5, 6, 7 };
    private int intelliPromo;
    private int skillPromo;
    private int commuPromo;

    private int[] starPos = { 47, 66, 87, 107, 127, 146, 167, 187, 206, 227, 246 };

    private int promoNumber;

    private bool isIntelliPromo = false;
    private bool isSkillPromo = false;
    private bool isCommuPromo = false;

    //private bool isPromotion = false;

    private Image intelliImage;
    private Image skillImage;
    private Image commuImage;

    /*private Image intellistarImage;
    private Image skillStarImage;
    private Image commuStarImage;*/

    private Color normalColor = new Color32(15, 90, 15, 255);
    private Color promoColor = new Color32(105, 255, 100, 255);

    private Color normalStarColor = new Color32(0, 0, 0, 255);
    private Color promoStarColor = new Color32(255, 255, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        intelliImage = statusController.intelliSlider.fillRect.GetComponent<Image>();
        skillImage = statusController.skillSlider.fillRect.GetComponent<Image>();
        commuImage = statusController.commuSlider.fillRect.GetComponent<Image>();

        /*intellistarImage = intelliStar.GetComponent<Image>();
        skillStarImage = skillStar.GetComponent<Image>();
        commuStarImage = commuStar.GetComponent<Image>();*/

        if (OverSceneStatus.isBoss)
        {
            intelliStar.enabled = false;
            skillStar.enabled = false;
            commuStar.enabled = false;

            intelliImage.color = promoColor;
            skillImage.color = promoColor;
            commuImage.color = promoColor;
        }
        else
        {
            promoNumber = Random.Range(0, yearPromo[OverSceneStatus.year - 1] + 1);
            Debug.Log(promoNumber);
            intelliPromo = promoNumber * 10;
            intelliStar.rectTransform.anchoredPosition = new Vector2(starPos[promoNumber], intelliStar.rectTransform.anchoredPosition.y);

            yearPromo[OverSceneStatus.year - 1] -= promoNumber;
            //if(yearPromo[OverSceneStatus.year - 1] == 0)
            promoNumber = Random.Range(0, yearPromo[OverSceneStatus.year - 1] + 1);
            Debug.Log(promoNumber);
            skillPromo = promoNumber * 10;
            skillStar.rectTransform.anchoredPosition = new Vector2(starPos[promoNumber], skillStar.rectTransform.anchoredPosition.y);

            promoNumber = yearPromo[OverSceneStatus.year - 1] - promoNumber;
            commuPromo = promoNumber * 10;
            commuStar.rectTransform.anchoredPosition = new Vector2(starPos[promoNumber], commuStar.rectTransform.anchoredPosition.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGoal)
        {
            if(isIntelliPromo && isSkillPromo && isCommuPromo)
            {
                //isPromotion = true;
                OverSceneStatus.isPromotion = true;
            }
            else
            {
                //isPromotion = false;
                OverSceneStatus.isPromotion = false;
            }
        }
        if (!OverSceneStatus.isBoss)
        {
            if (statusController.intelli >= intelliPromo)
            {
                intelliImage.color = promoColor;
                intelliStar.color = promoStarColor;
                isIntelliPromo = true;
            }
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
