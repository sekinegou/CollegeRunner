using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    void Update()
    {
        //ボスステージかつプレイヤーが動いている場合
        if (OverSceneStatus.isBoss && playerController.isMove == true)
        {
            //プレイヤーと同じ速度で動く
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
    }
}
