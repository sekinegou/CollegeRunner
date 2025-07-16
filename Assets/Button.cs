using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    //[SerializeField] private SliderController sliderController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Go_boss()
    {
        /*OverSceneStatus.stressStatus = 0;
        OverSceneStatus.intelliStatus = 0;
        OverSceneStatus.skillStatus = 0;
        OverSceneStatus.commuStatus = 0;*/
        if (!OverSceneStatus.isPromotion)
        {
            OverSceneStatus.ResetStatus();
            SceneManager.LoadScene("Title");
        }
        else
        {
            if (OverSceneStatus.year == 4)
            {
                OverSceneStatus.isBoss = true;
            }
            SceneManager.LoadScene("GameScene");
        }
        

    }
}
