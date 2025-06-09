using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private const float posVelocity = 8.0f;
    private int jumpVelocity = 300;

    private Rigidbody rb;

    private bool isJump;
    public bool isGoal = false;

    [SerializeField] private TextController textController;
    [SerializeField] private GameObject Goal;
    [SerializeField] private StatusController statusController;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textController.isCountFinish == true && transform.position.z < Goal.transform.position.z + 3)
        {
            playerMove();
        }
        if(transform.position.z >= Goal.transform.position.z)
        {
            isGoal = true;
        }
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.A) && isGoal != true)
        {
            transform.Translate(-posVelocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && isGoal != true)
        {
            transform.Translate(posVelocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == true)
        {
            //jumpVelocity = 50.0f;
            //transform.Translate(0, jumpVelocity, 0);
            rb.AddForce(new Vector3(0, jumpVelocity, 0));
            isJump = false;
        }
        transform.Translate(0, 0/*jumpVelocity *= 0.1f*/, 7.0f * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Road2"){
            isJump = true;
            //Debug.Log("rr");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "IntelliItem")
        {
            Destroy(other.gameObject);
            statusController.intelli += 10;
        }
        if (other.gameObject.name == "SkillItem")
        {
            Destroy(other.gameObject);
            statusController.skill += 10;
        }
        if (other.gameObject.name == "CommuItem")
        {
            Destroy(other.gameObject);
            statusController.commu += 10;
        }
    }
}
