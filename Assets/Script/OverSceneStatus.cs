using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OverSceneStatus
{
    public static int stressStatus;
    public static int intelliStatus;
    public static int skillStatus;
    public static int commuStatus;

    public static int stressTotal = 0;
    public static int intelliTotal = 0;
    public static int skillTotal = 0;
    public static int commuTotal = 0;

    public static int year = 1;

    public static bool isBoss = false;

    public static int bossType;

    public static bool isPromotion;

    public static int bestTime = 0;

    public static bool isEmployment;

    public static bool returnTitle = false;

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
