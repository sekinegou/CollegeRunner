using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoBossA()
    {
        OverSceneStatus.bossType = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void GoBossB()
    {
        OverSceneStatus.bossType = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void GoBossC()
    {
        OverSceneStatus.bossType = 2;
        SceneManager.LoadScene("GameScene");
    }
}
