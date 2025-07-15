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

    [SerializeField] private TextMeshProUGUI sinkyuu;

    public int year;

    private int intelli;
    private int skill;
    private int commu;

    private int intelliTotal;
    private int skillTotal;
    private int commuTotal;

    private bool isStatusDirection = false;

    private float time = 0;
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

        intelliTotal = OverSceneStatus.intelliTotal;
        skillTotal = OverSceneStatus.skillTotal;
        commuTotal = OverSceneStatus.commuTotal;

        OverSceneStatus.intelliTotal += OverSceneStatus.intelliStatus;
        OverSceneStatus.skillTotal += OverSceneStatus.skillStatus;
        OverSceneStatus.commuTotal += OverSceneStatus.commuStatus;

        year = OverSceneStatus.year;
        OverSceneStatus.year++;

        /*if(intelliTotal >= intelliSlider.maxValue)
        {
            intelliSlider.maxValue += 100;
        }
        if(skillTotal >= skillSlider.maxValue)
        {
            skillSlider.maxValue += 100;
        }
        if(commuTotal >= commuSlider.maxValue)
        {
            commuSlider.maxValue += 100;
        }*/

        if (OverSceneStatus.isPromotion)
        {
            sinkyuu.text = "i‹‰!!";

        }
        else
        {
            sinkyuu.text = "—¯”N";
        }

        intelliSlider.value = intelliTotal;
        skillSlider.value = skillTotal;
        commuSlider.value = commuTotal;

        intelliValue.text = intelliTotal.ToString() + " © " + intelli.ToString();
        skillValue.text = skillTotal.ToString() + " © " + skill.ToString();
        commuValue.text = commuTotal.ToString() + " © " + commu.ToString();

        

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

        if (isStatusDirection)
        {
            
            time += Time.deltaTime;
            //Debug.Log(time);
            if(time > 0.03f)
            {
                Invoke("StatusDisEnable", 0.5f);
                return;
            }
        }
        

        intelliSlider.value = intelliTotal;
        skillSlider.value = skillTotal;
        commuSlider.value = commuTotal;

        intelliValue.text = intelliTotal.ToString() + " © " + intelli.ToString();
        skillValue.text = skillTotal.ToString() + " © " + skill.ToString();
        commuValue.text = commuTotal.ToString() + " © " + commu.ToString();

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
        intelliValue.text = intelliTotal.ToString();
        skillValue.text = skillTotal.ToString();
        commuValue.text = commuTotal.ToString();
    }
}
