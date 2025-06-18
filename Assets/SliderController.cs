using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private StatusController statusController;

    [SerializeField] private Slider intelliSlider;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private Slider commuSlider;

    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;

    void Start()
    {
        // é©ìÆÇ≈StatusControllerÇå©Ç¬ÇØÇÈ
        if (statusController == null)
        {
            statusController = FindObjectOfType<StatusController>();
        }
    }

    void Update()
    {
        // statusControllerÇ™nullÇ≈Ç»Ç¢Ç∆Ç´ÇæÇØèàóù
        if (statusController != null)
        {
            intelliSlider.value = statusController.intelli;
            skillSlider.value = statusController.skill;
            commuSlider.value = statusController.commu;

            intelliValue.text = statusController.intelli.ToString();
            skillValue.text = statusController.skill.ToString();
            commuValue.text = statusController.commu.ToString();
        }
    }
}
