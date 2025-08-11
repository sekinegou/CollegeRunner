using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    //ƒJƒƒ‰‚ğ’Ê‚è‰ß‚¬‚½‚ç”j‰ó
    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z - 20)
        {
            Destroy(gameObject);
        }
    }
}
