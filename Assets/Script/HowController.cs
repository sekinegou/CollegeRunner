using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowController : MonoBehaviour
{
    [SerializeField] private Image[] how;
    //private Button front;
    //private Button back;



    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        how[1].enabled = false;
        how[2].enabled = false;
        //front = GameObject.Find("FrontButton").GetComponent<Button>();
        //back = GameObject.Find("BackButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(i == 0)
        {
            back.enabled = false;
        }
        if(i == 2)
        {
            front.enabled = false;
        }*/
    }

    public void FrontPage()
    {
        if (how[2].enabled) return;
        for (i = 0; i < how.Length; i++)
        {
            if (how[i].enabled)
            {
                how[i + 1].enabled = true;
                how[i].enabled = false;
                return;
            }
        }
    }

    public void BackPage()
    {
        if (how[0].enabled) return;
        for(i = 0; i < how.Length; i++)
        {
            if (how[i].enabled)
            {
                how[i - 1].enabled = true;
                how[i].enabled = false;
                return;
            }
        } 
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
