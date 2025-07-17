using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BossStatus bossStatus;
    //[SerializeField] private GameObject boss;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isMove && !playerController.isGoal && !bossStatus.isdefeat)
        {
            transform.Translate(0, 0, playerController.moveVelocity * Time.deltaTime, Space.World);
            //boss.transform.Translate(0, 0, playerController.moveVelocity * Time.deltaTime, Space.World);
        }
        //transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 3.7f);
    }
}
