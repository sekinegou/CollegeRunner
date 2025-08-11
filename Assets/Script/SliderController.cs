using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    //Nextのボタン
    [SerializeField] private NextButton nextButton;

    //各ステータスのバー
    [SerializeField] private Slider intelliSlider;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private Slider commuSlider;

    //各ステータス
    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;


    [SerializeField] private TextMeshProUGUI sinkyuu;

    //学年
    public int year;

    //各ステータス
    private int intelli;
    private int skill;
    private int commu;

    //各ステータスの合計
    private int intelliTotal;
    private int skillTotal;
    private int commuTotal;

    //合計ステータスが上がる演出が終わったか
    private bool isStatusDirection = false;

    private float time = 0;

    void Start()
    {
        //各変数を静的クラスから更新
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

        //ボスステージの場合
        if (OverSceneStatus.isBoss)
        {
            //就職可否によってテキストを更新
            if (OverSceneStatus.isEmployment)
            {
                sinkyuu.text = "就職成功";
            }
            else
            {
                sinkyuu.text = "就職失敗";
            }

            intelliValue.text = intelliTotal.ToString();
            skillValue.text = skillTotal.ToString();
            commuValue.text = commuTotal.ToString();
        }
        //ボスステージではない場合
        else
        {
            //進級可否によってテキストを更新
            if (OverSceneStatus.isPromotion)
            {
                sinkyuu.text = "進級!!";

            }
            else
            {
                sinkyuu.text = "留年";
            }

            intelliValue.text = intelliTotal.ToString() + " ← " + intelli.ToString();
            skillValue.text = skillTotal.ToString() + " ← " + skill.ToString();
            commuValue.text = commuTotal.ToString() + " ← " + commu.ToString();
        }
        

        intelliSlider.value = intelliTotal;
        skillSlider.value = skillTotal;
        commuSlider.value = commuTotal;
    }

    void Update()
    {
        //ボスステージorタイトルに戻る場合
        if(OverSceneStatus.isBoss || OverSceneStatus.returnTitle) return;

        //Nextボタンが押された場合
        if (nextButton.isPush)
        {
            intelliTotal = OverSceneStatus.intelliTotal;
            skillTotal = OverSceneStatus.skillTotal;
            commuTotal = OverSceneStatus.commuTotal;

            intelliSlider.value = intelliTotal;
            skillSlider.value = skillTotal;
            commuSlider.value = commuTotal;

            //合計ステータスのみを表示する
            StatusDisEnable();

            return;
        }

        //合計ステータスが上がる演出
        Invoke("StatusDirection", 0.5f);

        //全ての演出が終わったら
        if (isStatusDirection)
        {
            
            time += Time.deltaTime;

            if(time > 0.03f)
            {
                //合計ステータスのみを表示する
                Invoke("StatusDisEnable", 0.5f);
                return;
            }
        }
        
        //各テキストの更新
        intelliSlider.value = intelliTotal;
        skillSlider.value = skillTotal;
        commuSlider.value = commuTotal;

        intelliValue.text = intelliTotal.ToString() + " ← " + intelli.ToString();
        skillValue.text = skillTotal.ToString() + " ← " + skill.ToString();
        commuValue.text = commuTotal.ToString() + " ← " + commu.ToString();
    }

    //合計ステータスが上がる演出
    private void StatusDirection()
    {

        //合計ステータスを上げる
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

        //全ての演出が終わったら
        if (intelli == 0 && skill == 0 && commu == 0) isStatusDirection = true;
    }

    //合計ステータスのみを表示する
    private void StatusDisEnable()
    {
        intelliValue.text = intelliTotal.ToString();
        skillValue.text = skillTotal.ToString();
        commuValue.text = commuTotal.ToString();
    }
}
