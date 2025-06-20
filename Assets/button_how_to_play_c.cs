using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_how_to_play_c : MonoBehaviour
{
    void Start()
    {
        UnityEngine.UI.Button button = this.GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(HowToPlay);
    }

    void HowToPlay()
    {
        //SceneManager.LoadScene("How_to_play");
    }
}
