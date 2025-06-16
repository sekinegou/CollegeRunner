using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    public int stress = 0;
    public int intelli = 0;
    public int skill = 0;
    public int commu = 0;

    [SerializeField] private Slider stressSlider;
    [SerializeField] private Slider intelliSlider;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private Slider commuSlider;

    [SerializeField] private TextMeshProUGUI stressValue;
    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;

    public TextMeshProUGUI stressPoint;
    public TextMeshProUGUI intelliPoint;
    public TextMeshProUGUI skillPoint;
    public TextMeshProUGUI commuPoint;

    public bool stressOver = false;
    private Image stressImage;

    private Color normalColor = new Color32(255, 150, 70, 255);
    private Color overColor = new Color32(255, 70, 70, 255);

    // Start is called before the first frame update
    void Start()
    {
        //stressSlider = GetComponent<Slider>();
        stressPoint.enabled = false;
        intelliPoint.enabled = false;
        skillPoint.enabled = false;
        commuPoint.enabled = false;

        stressImage = stressSlider.fillRect.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stress < 0)
        {
            stress = 0;
        }
        if(intelli < 0)
        {
            intelli = 0;
        }
        if(skill < 0)
        {
            skill = 0;
        }
        if(commu < 0)
        {
            commu = 0;
        }

        if(stressPoint.enabled == true)
        {
            Invoke("stressPointEnabled", 2.0f);
        }
        if(intelliPoint.enabled == true)
        {
            Invoke("intelliPointEnabled", 2.0f);
        }
        if (skillPoint.enabled == true)
        {
            Invoke("skillPointEnabled", 2.0f);
        }
        if (commuPoint.enabled == true)
        {
            Invoke("commuPointEnabled", 2.0f);
        }

        if(stress > 100)
        {
            stressOver = true;
            stressImage.color = overColor;

            if (stress <= 0)
            {
                stressOver = false;
                stressImage.color = normalColor;
            }
        }

        stressSlider.value = stress;
        intelliSlider.value = intelli - ((intelli / 100) * 100);
        skillSlider.value = skill - ((skill / 100) * 100);
        commuSlider.value = commu - ((commu / 100) * 100);

        stressValue.text = stress.ToString();
        intelliValue.text = intelli.ToString();
        skillValue.text = skill.ToString();
        commuValue.text = commu.ToString();
    }

    void stressPointEnabled()
    {
        stressPoint.enabled = false;
    }
    void intelliPointEnabled()
    {
        intelliPoint.enabled = false;
    }
    void skillPointEnabled()
    {
        skillPoint.enabled = false;
    }
    void commuPointEnabled()
    {
        commuPoint.enabled = false;
    }
}
