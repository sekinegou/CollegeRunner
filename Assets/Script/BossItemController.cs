using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemController : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private float speed = 50;
    private Vector3 bosPos;

    private bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        boss = GameObject.FindWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < player.transform.position.z - 3)
        {
            Destroy(gameObject);
        }

        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, bosPos, speed * Time.deltaTime);
        }

        bosPos = new Vector3(boss.transform.position.x, boss.transform.position.y + 3, boss.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("t");
        if (other.gameObject.tag == "Player")
        {
            
            //Debug.Log("p");
            isMove = true;
            //Vector3 current = transform.position;
            //transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, speed * Time.deltaTime);
        }

        if(isMove && other.gameObject.tag == "Boss")
        {
            Debug.Log("b");
            Destroy(gameObject);
        }
    }
}
