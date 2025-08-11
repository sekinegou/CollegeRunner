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
        //プレイヤーが動いていて、ボスが倒されていない場合
        if ((playerController.isMove || textController.isTimeFinish) && !bossStatus.isdefeat)
        {
            //プレイヤーと同じ速度で動く
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
    }
}
