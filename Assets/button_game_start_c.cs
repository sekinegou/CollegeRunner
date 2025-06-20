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
        SceneManager.LoadScene("GameScene"); // 実際のシーン名に合わせてください
    }
}
