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
    private int min;

    public bool isTimeFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        countDown.text = "3";

        if (OverSceneStatus.isBoss)
        {
            min = (int)(bossTime / 60);
            cornerText.text = "面接終了まで\n" + min + ":" + (bossTime % 60).ToString("00");
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
            if (isCountFinish)
            {
                if(bossTime >= 0)
                {
                    bossTime -= Time.deltaTime;
                }
                
                min = (int)(bossTime / 60);
                cornerText.text = "面接終了まで\n" + min + ":" + (bossTime % 60).ToString("00");
            }

            if (bossTime <= 0)
            {
                isTimeFinish = true;
                countDown.text = "TimeOver";
                countDown.enabled = true;
            }
            if (bossStatus.isdefeat)
            {
                countDown.text = "Clear!!";
                countDown.enabled = true;
            }
        }

        time += Time.deltaTime;
    }
}
