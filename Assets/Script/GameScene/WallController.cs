using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    void Update()
    {
        //�J������ʂ�߂�����j��
        if (transform.position.z < Camera.main.transform.position.z - 10)
        {
            Destroy(gameObject);
        }
    }
}
