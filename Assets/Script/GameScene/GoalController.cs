using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    void Update()
    {
        //�{�X�X�e�[�W���v���C���[�������Ă���ꍇ
        if (OverSceneStatus.isBoss && playerController.isMove == true)
        {
            //�v���C���[�Ɠ������x�œ���
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
    }
}
