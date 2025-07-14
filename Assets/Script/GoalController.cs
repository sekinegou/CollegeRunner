using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OverSceneStatus.isBoss && playerController.isMove == true && playerController.isGoal == false)
        {
            transform.Translate(0, 0, playerController.moveVelocity * Time.deltaTime, Space.World);
        }
    }
}
