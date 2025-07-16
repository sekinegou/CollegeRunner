using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI countDown;
    [SerializeField] private GameObject goal;
    [SerializeField] private TextMeshProUGUI cornerText;

    private int distance;

    private float time = 0;

    public bool isCountFinish = false;

    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected StatusController statusController;
    [SerializeField] private BossStatus bossStatus;

    [SerializeField] private float bossTime = 60;
    private float lapseTime;
    private int clearTime;
    private int min;

    public bool isTimeFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        lapseTime = bossTime;
        countDown.text = "3";

        if (OverSceneStatus.isBoss)
        {
            min = (int)(lapseTime / 60);
            cornerText.text = statusController.year + "年終了まで\n" + min + ":" + (lapseTime % 60).ToString("00");
        }
    }

    void Update()
    {
        if (3 - time > 0)
        {
            countDown.text = (3 - (int)time).ToString();
        }
        else
        {
            isCountFinish = true;
            countDown.text = "GO";
            if (3 - time < -0.5)
            {
                countDown.enabled = false;
            }
        }

        if (!OverSceneStatus.isBoss)
        {
            if (playerController.isGoal == true)
            {
                countDown.text = "Goal";
                countDown.enabled = true;
                cornerText.text = statusController.year + "年終了まで\n0m";
            }
            else
            {
                distance = (int)(goal.transform.position.z - playerController.transform.position.z);
                cornerText.text = statusController.year + "年終了まで\n" + distance.ToString() + "m";
            }
        }
        else
        {
            if (isCountFinish && !bossStatus.isdefeat)
            {
                if(lapseTime >= 0)
                {
                    lapseTime -= Time.deltaTime;
                }
                
                min = (int)(lapseTime / 60);
                cornerText.text = statusController.year + "年終了まで\n" + min + ":" + (lapseTime % 60).ToString("00");
            }

            if (lapseTime <= 0)
            {
                isTimeFinish = true;
                countDown.text = "内定獲得失敗";
                countDown.enabled = true;
            }
            if (bossStatus.isdefeat)
            {
                countDown.text = "内定獲得!!";
                countDown.enabled = true;

                clearTime = (int)(bossTime - lapseTime);

                if(clearTime < OverSceneStatus.bestTime || OverSceneStatus.bestTime == 0)
                {
                    OverSceneStatus.bestTime = clearTime;
                }
            }
        }

        time += Time.deltaTime;
    }
}
