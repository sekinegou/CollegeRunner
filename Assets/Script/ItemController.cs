using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private GameObject player;
    private StatusController statusController;

    /*[SerializeField] private GameObject intelliPrefab;
    [SerializeField] private GameObject skillPrefab;
    [SerializeField] private GameObject commuPrefab;
    [SerializeField] private GameObject beerPrefab;
    [SerializeField] private GameObject switchPrefab;
    [SerializeField] private GameObject phonePrefab;*/

    [SerializeField] private GameObject[] goodItem;
    [SerializeField] private GameObject[] badItem;

    private int itemNumber;
    private bool reverse = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        statusController = FindObjectOfType<StatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < player.transform.position.z - 3)
        {
            Destroy(gameObject);
        }

        if(statusController.stressOver)
        {
            //Debug.Log("over");
            changeItem();
            reverse = false;
            
        }

        if (statusController.stresszero && !reverse)
        {
            //Debug.Log(good + "r");
            reverse = true;
            reverseItem();
        }
    }

    void changeItem()
    {
        /*if (!statusController.stressOver)
        {
            Debug.Log("normal");
            if (good == "intelli")
            {
                Debug.Log("i");
                Destroy(gameObject);
                Instantiate(intelliPrefab, transform.position, Quaternion.identity);
            }
            if (good == "skill")
            {
                Debug.Log("s");
                Destroy(gameObject);
                Instantiate(skillPrefab, transform.position, Quaternion.identity);
            }
            if (good == "commu")
            {
                Debug.Log("c");
                Destroy(gameObject);
                Instantiate(commuPrefab, transform.position, Quaternion.identity);
            }
            return;
        }*/

        if (tag == "Intelli" || tag == "Skill" || tag == "Commu")
        {
            Destroy(gameObject);
            itemNumber = Random.Range(0, badItem.Length);
            Instantiate(badItem[itemNumber], transform.position, Quaternion.identity);
        }
        /*if (tag == "Skill")
        {
            good = "skill";
            Debug.Log(good);
            Destroy(gameObject);
            Instantiate(phonePrefab, transform.position, Quaternion.identity);
        }
        if (tag == "Commu")
        {
            good = "commu";
            Debug.Log(good);
            Destroy(gameObject);
            Instantiate(switchPrefab, transform.position, Quaternion.identity);
        }*/
    }

    void reverseItem()
    {
        if(Random.Range(0, 2) == 0)
        {

            Destroy(gameObject);
            itemNumber = Random.Range(0, goodItem.Length);
            Instantiate(goodItem[itemNumber], transform.position, Quaternion.identity);
        }
        //Debug.Log("normal");
        /*if (good == "intelli")
        {
            Debug.Log(good + "r");
            Destroy(gameObject);
            Instantiate(intelliPrefab, transform.position, Quaternion.identity);
        }
        if (good == "skill")
        {
            Debug.Log(good + "r");
            Destroy(gameObject);
            Instantiate(skillPrefab, transform.position, Quaternion.identity);
        }
        if (good == "commu")
        {
            Debug.Log(good + "r");
            Destroy(gameObject);
            Instantiate(commuPrefab, transform.position, Quaternion.identity);
        }*/
    }
}
