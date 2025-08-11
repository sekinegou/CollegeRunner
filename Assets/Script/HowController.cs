using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//ページごとに表示するものを変える
public class HowController : MonoBehaviour
{
    [SerializeField] private HowToPlayItem howToPlayItem;

    private int i = 0;

    void Start()
    {
        howToPlayItem.how[1].enabled = false;
        howToPlayItem.how[2].enabled = false;
    }

    public void FrontPage()
    {
        if (howToPlayItem.how[2].enabled) return;
        for (i = 0; i < howToPlayItem.how.Length; i++)
        {
            if (howToPlayItem.how[i].enabled)
            {
                howToPlayItem.how[i + 1].enabled = true;
                howToPlayItem.how[i].enabled = false;
                return;
            }
        }
    }

    public void BackPage()
    {
        if (howToPlayItem.how[0].enabled) return;
        for(i = 0; i < howToPlayItem.how.Length; i++)
        {
            if (howToPlayItem.how[i].enabled)
            {
                howToPlayItem.how[i - 1].enabled = true;
                howToPlayItem.how[i].enabled = false;
                return;
            }
        } 
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
