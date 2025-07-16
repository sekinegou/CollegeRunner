using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeResult : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] StatusController statusController;
    [SerializeField] TextController textController;
    [SerializeField] BossStatus bossStatus;

    //[SerializeField] PromotionController promotionController;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGoal)
        {
            /*if (OverSceneStatus.isPromotion)
            {
                OverSceneStatus.stressStatus = statusController.stress;
                OverSceneStatus.intelliStatus = statusController.intelli;
                OverSceneStatus.skillStatus = statusController.skill;
                OverSceneStatus.commuStatus = statusController.commu;

                OverSceneStatus.year = statusController.year;

                sceneName = "Result";
                Invoke("changeScene", 1.5f);
            }
            else
            {
                sceneName = "Title";
                Invoke("changeScene", 1.5f);
            }*/
            OverSceneStatus.stressStatus = statusController.stress;
            OverSceneStatus.intelliStatus = statusController.intelli;
            OverSceneStatus.skillStatus = statusController.skill;
            OverSceneStatus.commuStatus = statusController.commu;

            OverSceneStatus.year = statusController.year;

            sceneName = "Result";
            Invoke("changeScene", 1.5f);
        }

        if (textController.isTimeFinish)
        {
            sceneName = "Title";
            Invoke("changeScene", 3f);
        }

        if (bossStatus.isdefeat)
        {
            sceneName = "Title";
            Invoke("changeScene", 3f);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
