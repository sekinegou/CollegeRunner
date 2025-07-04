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
    //private StatusController statusController;

    [SerializeField] private Slider intelliSlider;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private Slider commuSlider;

    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;

    [SerializeField] private TextMeshProUGUI intelliTotalText;
    [SerializeField] private TextMeshProUGUI skillTotalText;
    [SerializeField] private TextMeshProUGUI commuTotalText;

    [SerializeField] private TextMeshProUGUI intelliArrow;
    [SerializeField] private TextMeshProUGUI skillArrow;
    [SerializeField] private TextMeshProUGUI commuArrow;

    public int year;

    private int intelli;
    private int skill;
    private int commu;

    private int intelliTotal;
    private int skillTotal;
    private int commuTotal;

    private bool isStatusDirection = false;
    void Start()
    {
        /*// Ž©“®‚ÅStatusController‚ðŒ©‚Â‚¯‚é
         if (statusController == null)
         {
             statusController = FindObjectOfType<StatusController>();
         }

         if(statusController != null)
         {
             statusController.year++;
             year = statusController.year;
             Debug.Log(year);
         }*/

        intelli = OverSceneStatus.intelliStatus;
        skill = OverSceneStatus.skillStatus;
        commu = OverSceneStatus.commuStatus;

        intelliSlider.value = intelli;
        skillSlider.value = skill;
        commuSlider.value = commu;

        intelliValue.text = intelli.ToString();
        skillValue.text = skill.ToString();
        commuValue.text = commu.ToString();

        year = OverSceneStatus.year;
        OverSceneStatus.year++;

        intelliTotal = OverSceneStatus.intelliTotal;
        skillTotal = OverSceneStatus.skillTotal;
        commuTotal = OverSceneStatus.commuTotal;

        OverSceneStatus.intelliTotal += OverSceneStatus.intelliStatus;
        OverSceneStatus.skillTotal += OverSceneStatus.skillStatus;
        OverSceneStatus.commuTotal += OverSceneStatus.commuStatus;

        intelliTotalText.text = intelliTotal.ToString();
        skillTotalText.text = skillTotal.ToString();
        commuTotalText.text = commuTotal.ToString();

        //Invoke("StatusDirection", 0.5f);
    }

    void Update()
    {
        /*if (intelli > 0)
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
        }*/
        Invoke("StatusDirection", 0.5f);

        if (isStatusDirection) Invoke("StatusDisEnable", 0.5f);

        intelliValue.text = intelli.ToString();
        skillValue.text = skill.ToString();
        commuValue.text = commu.ToString();

        intelliTotalText.text = intelliTotal.ToString();
        skillTotalText.text = skillTotal.ToString();
        commuTotalText.text = commuTotal.ToString();

        /*// statusController‚ªnull‚Å‚È‚¢‚Æ‚«‚¾‚¯ˆ—
        if (statusController != null)
        {
            intelliSlider.value = statusController.intelli;
            skillSlider.value = statusController.skill;
            commuSlider.value = statusController.commu;

            intelliValue.text = statusController.intelli.ToString();
            skillValue.text = statusController.skill.ToString();
            commuValue.text = statusController.commu.ToString();
        }*/
    }

    private void StatusDirection()
    {

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

        if (intelli == 0 && skill == 0 && commu == 0) isStatusDirection = true;
    }

    private void StatusDisEnable()
    {
        intelliValue.enabled = false;
        skillValue.enabled = false;
        commuValue.enabled = false;
        intelliArrow.enabled = false;
        skillArrow.enabled = false;
        commuArrow.enabled = false;
    }
}
