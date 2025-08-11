using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BossStatus bossStatus;

    void Update()
    {
        //�v���C���[�������Ă��ăS�[�����ĂȂ��ă{�X����������Ă��Ȃ��ꍇ
        if(playerController.isMove && !playerController.isGoal && !bossStatus.isdefeat)
        {
            //�v���C���[�Ɠ��������ňړ�
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
    }
}
