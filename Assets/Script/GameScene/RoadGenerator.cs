using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    //�J������ʂ�߂�����j��
    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z - 20)
        {
            Destroy(gameObject);
        }
    }
}
