using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    [SerializeField] private TextMeshProUGUI distanceText;

    private float time = 0;

    public bool isCountFinish = false;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private StatusController statusController;
    [SerializeField] private GameObject goal;
    private int distance;

    // Start is called before the first frame update
    void Start()
    {
        countDown.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        if(3 - time > 0)
        {
            countDown.text = (3 - (int)time).ToString();
        }
        else
        {
            isCountFinish = true;
            countDown.text = "GO";
            if(3 - time < -0.5)
            {
                countDown.enabled = false;
            }
        }
        if(playerController.isGoal == true)
        {
            countDown.text = "Goal";
            countDown.enabled = true;
            distanceText.text = statusController.year + "年終了まで\n0m";
        }
        else
        {
            distance = (int)(goal.transform.position.z - playerController.transform.position.z);
            distanceText.text = statusController.year + "年終了まで\n" + distance.ToString() + "m";
        }

        time += Time.deltaTime;
    }
}
