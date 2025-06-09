using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    public float stress = 0;
    public int intelli = 0;
    public int skill = 0;
    public int commu = 0;

    [SerializeField] private Slider stressSlider;
    // Start is called before the first frame update
    void Start()
    {
        //stressSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        stressSlider.value = stress;
    }
}
