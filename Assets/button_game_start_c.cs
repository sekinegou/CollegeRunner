using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_game_start_c : MonoBehaviour
{
    void Start()
    {
        UnityEngine.UI.Button button = this.GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(Osu);
    }

    void Osu()
    {
        OverSceneStatus.returnTitle = false;
        if(OverSceneStatus.bestTime == 0)
        {
            SceneManager.LoadScene("BossIntro");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
