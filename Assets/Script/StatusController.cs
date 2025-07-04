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

    public int stressChange = 0;
    public int intelliChange = 0;
    public int skillChange = 0;
    public int commuChange = 0;

    public float stresstime = 0;
    public float intellitime = 0;
    public float skilltime = 0;
    public float commutime = 0;
   
    [SerializeField] private Slider stressSlider;
    [SerializeField] private Slider intelliSlider;
    [SerializeField] private Slider skillSlider;
    [SerializeField] private Slider commuSlider;

    [SerializeField] private TextMeshProUGUI stressValue;
    [SerializeField] private TextMeshProUGUI intelliValue;
    [SerializeField] private TextMeshProUGUI skillValue;
    [SerializeField] private TextMeshProUGUI commuValue;

    [SerializeField] private TextMeshProUGUI stressPoint;
    [SerializeField] private TextMeshProUGUI intelliPoint;
    [SerializeField] private TextMeshProUGUI skillPoint;
    [SerializeField] private TextMeshProUGUI commuPoint;

    public bool stressOver = false;
    public bool stresszero;
    private Image stressImage;

    private Color normalColor = new Color32(255, 150, 70, 255);
    private Color overColor = new Color32(255, 70, 70, 255);

    public int year;

    /*private static StatusController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {
        //stressSlider = GetComponent<Slider>();
        stressPoint.enabled = false;
        intelliPoint.enabled = false;
        skillPoint.enabled = false;
        commuPoint.enabled = false;

        stressImage = stressSlider.fillRect.GetComponent<Image>();

        year = OverSceneStatus.year;
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

        /*if(stressChange != 0)
        {
            
            stresstime = 0.3f;
            
            //Invoke("stressPointEnabled", 2.0f);
        }

        if (intelliChange != 0)
        {
            
            intellitime = 0.3f;
            
            //Invoke("stressPointEnabled", 2.0f);
        }

        if (skillChange != 0)
        {
            if (skillChange > 0)
            {
                skillPoint.text = "+" + skillChange.ToString();
            }
            else
            {
                skillPoint.text = skillChange.ToString();
            }
            skillPoint.enabled = true;
            skilltime = 0.3f;
            
            //Invoke("stressPointEnabled", 2.0f);
        }

        if (commuChange != 0)
        {
            
            commutime = 0.3f;
            
            //Invoke("stressPointEnabled", 2.0f);
        }*/

        if (stresstime < 0)
        {
            stressPoint.enabled = false;
            stressChange = 0;
        }
        else
        {
            if (stressChange > 0)
            {
                stressPoint.text = "+" + stressChange.ToString();
            }
            else
            {
                stressPoint.text = stressChange.ToString();
            }
            stressPoint.enabled = true;
        }

        if (intellitime < 0)
        {
            intelliPoint.enabled = false;
            intelliChange = 0;
        }
        else
        {
            if (intelliChange > 0)
            {
                intelliPoint.text = "+" + intelliChange.ToString();
            }
            else
            {
                intelliPoint.text = intelliChange.ToString();
            }
            intelliPoint.enabled = true;
        }

        if (skilltime < 0)
        {
            skillPoint.enabled = false;
            skillChange = 0;
        }
        else
        {
            if (skillChange > 0)
            {
                skillPoint.text = "+" + skillChange.ToString();
            }
            else
            {
                skillPoint.text = skillChange.ToString();
            }
            skillPoint.enabled = true;
        }

        if (commutime < 0)
        {
            commuPoint.enabled = false;
            commuChange = 0;
        }
        else
        {
            if (commuChange > 0)
            {
                commuPoint.text = "+" + commuChange.ToString();
            }
            else
            {
                commuPoint.text = commuChange.ToString();
            }
            commuPoint.enabled = true;
        }

        if (stresszero)
        {
            stresszero = false;
        }

        if (stress <= 0 && stressOver)
        {
            //Debug.Log("not");
            stresszero = true;
            stressImage.color = normalColor;
            stressOver = false;
        }

        if (stress >= 100)
        {
            stressOver = true;
            stressImage.color = overColor;
        }

        

        stressSlider.value = stress;
        intelliSlider.value = intelli;
        skillSlider.value = skill;
        commuSlider.value = commu;

        stressValue.text = stress.ToString();
        intelliValue.text = intelli.ToString();
        skillValue.text = skill.ToString();
        commuValue.text = commu.ToString();

        stresstime -= Time.deltaTime;
        intellitime -= Time.deltaTime;
        skilltime -= Time.deltaTime;
        commutime -= Time.deltaTime;
        //Debug.Log(stresstime);
    }

    /*void stressPointEnabled()
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
    }*/
}
