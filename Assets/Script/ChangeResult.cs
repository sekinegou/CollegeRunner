using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeResult : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] StatusController statusController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGoal)
        {
            
            Invoke("changeScene", 1.5f);
        }
    }

    void changeScene()
    {
        SceneManager.LoadScene("Result");
    }
}
