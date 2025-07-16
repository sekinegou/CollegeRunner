using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestTimeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI bestTime;

    private int min;
    // Start is called before the first frame update
    void Start()
    {
        if(OverSceneStatus.bestTime == 0)
        {
            text.enabled = false;
            bestTime.enabled = false;
        }
        else
        {
            min = OverSceneStatus.bestTime / 60;
            bestTime.text = min + ":" + (OverSceneStatus.bestTime % 60).ToString("00");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
