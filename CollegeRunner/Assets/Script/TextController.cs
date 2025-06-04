using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public TextMeshPro countDown;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        countDown.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        if(3 - time < -0.5)
        {
            Destroy(countDown);
        }
        time += Time.deltaTime;
        countDown.text = (3 - (int)time).ToString();
    }
}
