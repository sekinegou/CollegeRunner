using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//GameScene����̃V�[���J�ڂ�����
public class ChangeResult : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] StatusController statusController;
    [SerializeField] TextController textController;
    [SerializeField] BossStatus bossStatus;

    private string sceneName;

    void Update()
    {
        //�S�[��������
        if (playerController.isGoal)
        {
            //�ÓI�N���X�̃X�e�[�^�X���X�V����
            OverSceneStatus.stressStatus = statusController.stress;
            OverSceneStatus.intelliStatus = statusController.intelli;
            OverSceneStatus.skillStatus = statusController.skill;
            OverSceneStatus.commuStatus = statusController.commu;

            OverSceneStatus.year = statusController.year;

            //Result�ɑJ��
            sceneName = "Result";
            Invoke("changeScene", 1.5f);
        }

        //���Ԑ؂�
        if (textController.isTimeFinish)
        {
            //�A�E���s
            OverSceneStatus.isEmployment = false;
            //LastResult�ɑJ��
            sceneName = "LastResult";
            Invoke("changeScene", 3f);
        }

        //�{�X��|����
        if (bossStatus.isdefeat)
        {
            //�A�E���s
            OverSceneStatus.isEmployment = true;
            //LastResult�ɑJ��
            sceneName = "LastResult";
            Invoke("changeScene", 3f);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
