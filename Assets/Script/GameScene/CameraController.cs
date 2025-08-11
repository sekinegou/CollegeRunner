using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BossStatus bossStatus;

    void Update()
    {
        //プレイヤーが動いていてゴールしてなくてボスがたおされていない場合
        if(playerController.isMove && !playerController.isGoal && !bossStatus.isdefeat)
        {
            //プレイヤーと同じ速さで移動
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
    }
}
