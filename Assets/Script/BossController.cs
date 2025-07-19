using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private PlayerController playerController;
    private BossStatus bossStatus;
    private TextController textController;
    //private BossItemController bossItemController;

    //[SerializeField] private AudioSource audioSource;

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
        textController = FindObjectOfType<TextController>();
        //bossItemController = FindObjectOfType<BossItemController>();
        //Debug.Log("s");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (bossStatus.isdefeat)
        {
            gameObject.SetActive(false);
        }*/
        if ((playerController.isMove || textController.isTimeFinish) && !bossStatus.isdefeat)
        {
            transform.Translate(0, 0, playerController.moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime, Space.World);
        }
        //Debug.Log("u");
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(bossItemController.isMove && (other.gameObject.tag == "IAttack" || other.gameObject.tag == "SAttack" || other.gameObject.tag == "CAttack"))
        {
            audioSource.Play();
        }
        
    }*/
}
