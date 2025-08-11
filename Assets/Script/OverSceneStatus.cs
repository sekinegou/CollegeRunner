using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//静的クラス
public static class OverSceneStatus
{
    //1年ごとの各ステータス
    public static int stressStatus;
    public static int intelliStatus;
    public static int skillStatus;
    public static int commuStatus;

    //各ステータスの合計
    public static int stressTotal = 0;
    public static int intelliTotal = 0;
    public static int skillTotal = 0;
    public static int commuTotal = 0;

    //学年
    public static int year = 1;

    //ボスステージか
    public static bool isBoss = false;

    //ボスの種類
    public static int bossType;

    //進級成功したか
    public static bool isPromotion;

    //ベストタイム
    public static int bestTime = 0;

    //就職成功したか
    public static bool isEmployment;

    //タイトルに戻るか
    public static bool returnTitle = false;

    //ステータスをリセット
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
