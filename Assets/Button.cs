using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    [SerializeField] private SliderController sliderController;
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
        if(sliderController.year < 4)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            SceneManager.LoadScene("BossScene");
        }
        
    }
}
