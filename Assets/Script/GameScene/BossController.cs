using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private PlayerController playerController;
    private BossStatus bossStatus;
    private TextController textController;
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        bossStatus = FindObjectOfType<BossStatus>();
        textController = FindObjectOfType<TextController>();
    }

    void Update()
    {
        //�v���C���[�������Ă��āA�{�X���|����Ă��Ȃ��ꍇ
        if ((playerController.isMove || textController.isTimeFinish) && !bossStatus.isdefeat)
        {
            //�v���C���[�Ɠ������x�œ���
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
    }
}
