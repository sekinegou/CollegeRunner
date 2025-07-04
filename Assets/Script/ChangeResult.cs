using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeResult : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] StatusController statusController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGoal)
        {
            OverSceneStatus.stressStatus = statusController.stress;
            OverSceneStatus.intelliStatus = statusController.intelli;
            OverSceneStatus.skillStatus = statusController.skill;
            OverSceneStatus.commuStatus = statusController.commu;

            OverSceneStatus.year = statusController.year;

            Invoke("changeScene", 0.5f);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene("Result");
    }
}
