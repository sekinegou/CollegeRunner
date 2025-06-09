using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI countDown;
    private float time = 0;

    public bool isCountFinish = false;

    [SerializeField] private PlayerController playerController;

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
        }
        time += Time.deltaTime;
    }
}
