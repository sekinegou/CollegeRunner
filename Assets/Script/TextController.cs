using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextMeshPro countDown;
    private float time = 0;

    public bool isCountFinish = false;

    private Renderer r;

    [SerializeField] private GameObject Camera;
    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        r = countDown.GetComponent<Renderer>();
        countDown.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        if(3 - time > 0)
        {
            countDown.text = (3 - (int)time).ToString();
        }
        else
        {
            isCountFinish = true;
            countDown.text = "GO";
            if(3 - time < -0.5)
            {
                r.enabled = false;
            }
        }
        if(playerController.isGoal == true)
        {
            countDown.text = "Goal";
            r.enabled = true;
        }
        time += Time.deltaTime;
        

        //transform.position = new Vector3(transform.position.x, transform.position.y, Camera.transform.position.z + 2.7f);
    }
}
