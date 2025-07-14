using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private PlayerController playerController;
    private BossStatus bossStatus;

    //[SerializeField] private GameObject[] boss;
    // Start is called before the first frame update
    void Start()
    {
        /*if (!OverSceneStatus.isBoss)
        {
            gameObject.SetActive(false);
        }*/

        playerController = FindObjectOfType<PlayerController>();
        bossStatus = FindObjectOfType<BossStatus>();
        //Debug.Log("s");
    }

    // Update is called once per frame
    void Update()
    {
        if (bossStatus.isdefeat)
        {
            gameObject.SetActive(false);
        }
        if (playerController.isMove == true && playerController.isGoal == false)
        {
            transform.Translate(0, 0, playerController.moveVelocity * Time.deltaTime, Space.World);
        }
        //Debug.Log("u");
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "IAttack")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SAttack")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "CAttack")
        {
            Destroy(other.gameObject);
        }
    }*/
}
