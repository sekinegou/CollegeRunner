using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI intelliDescription;
    [SerializeField] private TextMeshProUGUI skillDescription;
    [SerializeField] private TextMeshProUGUI commuDescription;

    [SerializeField] private TextMeshProUGUI[] badDiscription;

    [SerializeField] private Image[] item;
    [SerializeField] private Image[] bossItem;

    // Start is called before the first frame update
    void Start()
    {
        if (OverSceneStatus.isBoss)
        {
            intelliDescription.text = "知能\nAttack";
            skillDescription.text = "技術\nAttack";
            commuDescription.text = "コミュ力\nAttack";

            for(int i=0;i < badDiscription.Length;i++)
            {
                badDiscription[i].enabled = false;
            }

            for(int i=0;i < item.Length;i++)
            {
                item[i].enabled = false;
            }
            for(int i=0;i < bossItem.Length;i++)
            {
                bossItem[i].enabled = true;
            }
        }
        else
        {
            for(int i=0;i < bossItem.Length; i++)
            {
                bossItem[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
