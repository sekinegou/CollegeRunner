using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    void Update()
    {
        //ƒJƒƒ‰‚ğ’Ê‚è‰ß‚¬‚½‚ç”j‰ó
        if (transform.position.z < Camera.main.transform.position.z - 10)
        {
            Destroy(gameObject);
        }
    }
}
