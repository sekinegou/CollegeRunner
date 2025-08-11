using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    //カウントダウンのテキスト
    [SerializeField] private TextMeshProUGUI countDown;
    //ゴール
    [SerializeField] private GameObject goal;
    //右上のテキスト
    [SerializeField] private TextMeshProUGUI cornerText;

    //ゴールまでの距離
    private int distance;

    //カウントダウン
    private float countDownTime = 0;

    //カウントダウンが終わったか
    public bool isCountFinish = false;

    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected StatusController statusController;
    [SerializeField] private BossStatus bossStatus;

    //ボスステージの時間制限
    [SerializeField] private float bossTime = 60;

    private float time;
    //クリアタイム
    private int clearTime;
    //分
    private int min;

    //時間制限を過ぎたか
    public bool isTimeFinish = false;

    void Start()
    {
        time = bossTime;
        countDown.text = "3";

        //ボスステージの場合
        if (OverSceneStatus.isBoss)
        {
            //制限時間を表す
            min = (int)(time / 60);
            cornerText.text = statusController.year + "年終了まで\n" + min + ":" + (time % 60).ToString("00");
        }
    }

    void Update()
    {
        //カウントダウン
        if (3 - countDownTime > 0)
        {
            countDown.text = (3 - (int)countDownTime).ToString();
        }
        else
        {
            isCountFinish = true;
            countDown.text = "GO";
            if (3 - countDownTime < -0.5)
            {
                countDown.enabled = false;
            }
        }

        //ボスステージではない場合
        if (!OverSceneStatus.isBoss)
        {
            //プレイヤーがゴールした場合
            if (playerController.isGoal == true)
            {
                countDown.text = "Goal";
                countDown.enabled = true;
                cornerText.text = statusController.year + "年終了まで\n0m";
            }
            else
            {
                //ゴールまでの距離を表示
                distance = (int)(goal.transform.position.z - playerController.transform.position.z);
                cornerText.text = statusController.year + "年終了まで\n" + distance.ToString() + "m";
            }
        }
        //ボスステージの場合
        else
        {
            //カウントダウンが終わったかつボスが倒されていない場合
            if (isCountFinish && !bossStatus.isdefeat)
            {
                //制限時間を表す
                if(time >= 0)
                {
                    time -= Time.deltaTime;
                }
                
                min = (int)(time / 60);
                cornerText.text = statusController.year + "年終了まで\n" + min + ":" + (time % 60).ToString("00");
            }

            //制限時間を過ぎたら
            if (time <= 0)
            {
                isTimeFinish = true;
                //テキストを更新
                countDown.text = "内定獲得失敗";
                countDown.enabled = true;
            }
            //ボスが倒された場合
            if (bossStatus.isdefeat)
            {
                //テキストを更新
                countDown.text = "内定獲得";
                countDown.enabled = true;

                //クリアタイム
                clearTime = (int)(bossTime - time);

                //クリアタイムがベストタイムより短いorベストタイムが0の場合
                if(clearTime < OverSceneStatus.bestTime || OverSceneStatus.bestTime == 0)
                {
                    //ベストタイムを更新
                    OverSceneStatus.bestTime = clearTime;
                }
            }
        }

        countDownTime += Time.deltaTime;
    }
}
