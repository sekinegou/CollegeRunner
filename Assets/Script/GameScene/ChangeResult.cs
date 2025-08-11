using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//GameScene‚©‚ç‚ÌƒV[ƒ“‘JˆÚ‚ğ‚·‚é
public class ChangeResult : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] StatusController statusController;
    [SerializeField] TextController textController;
    [SerializeField] BossStatus bossStatus;

    private string sceneName;

    void Update()
    {
        //ƒS[ƒ‹‚µ‚½‚ç
        if (playerController.isGoal)
        {
            //Ã“IƒNƒ‰ƒX‚ÌƒXƒe[ƒ^ƒX‚ğXV‚·‚é
            OverSceneStatus.stressStatus = statusController.stress;
            OverSceneStatus.intelliStatus = statusController.intelli;
            OverSceneStatus.skillStatus = statusController.skill;
            OverSceneStatus.commuStatus = statusController.commu;

            OverSceneStatus.year = statusController.year;

            //Result‚É‘JˆÚ
            sceneName = "Result";
            Invoke("changeScene", 1.5f);
        }

        //ŠÔØ‚ê
        if (textController.isTimeFinish)
        {
            //AE¸”s
            OverSceneStatus.isEmployment = false;
            //LastResult‚É‘JˆÚ
            sceneName = "LastResult";
            Invoke("changeScene", 3f);
        }

        //ƒ{ƒX‚ğ“|‚µ‚½
        if (bossStatus.isdefeat)
        {
            //AE¸”s
            OverSceneStatus.isEmployment = true;
            //LastResult‚É‘JˆÚ
            sceneName = "LastResult";
            Invoke("changeScene", 3f);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
