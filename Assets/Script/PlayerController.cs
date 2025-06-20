using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private const float posVelocity = 8.0f;
    [SerializeField] private int jumpVelocity = 300;
    public int moveVelocity = 10;

    private Rigidbody rb;

    private bool isJump;
    public bool isGoal = false;
    public bool isMove = false;

    [SerializeField] private TextController textController;
    [SerializeField] private GameObject goal;
    [SerializeField] private StatusController statusController;

    private bool left = false;
    private bool right = false;

    private float time = 0;
    [SerializeField] private float moveTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textController.isCountFinish == true && transform.position.z < goal.transform.position.z + 3)
        {
            playerMove();
            isMove = true;
        }
        if(transform.position.z >= goal.transform.position.z)
        {
            isGoal = true;
        }

        time += Time.deltaTime;
    }

    void playerMove()
    {
        if(transform.position.x == -1.2f)
        {
            left = true;
            //Debug.Log("l");
        }
        else
        {
            left = false;
            //Debug.Log("nl");
        }
        if (transform.position.x == 1.2f)
        {
            right = true;
            //Debug.Log("r");
        }
        else
        {
            right = false;
            //Debug.Log("nr");
        }

        if (Input.GetKeyDown(KeyCode.A) && !isGoal && !left && isJump && time > moveTime)
        {
            transform.Translate(-1.2f, 0, 0);
            time = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) && !isGoal && !right && isJump && time > moveTime)
        {
            transform.Translate(1.2f, 0, 0);
            time = 0;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isJump == true)
        {
            //jumpVelocity = 50.0f;
            //transform.Translate(0, jumpVelocity, 0);
            rb.AddForce(new Vector3(0, jumpVelocity, 0));
            isJump = false;
        }
        transform.Translate(0, 0/*jumpVelocity *= 0.1f*/, moveVelocity * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Road"){
            isJump = true;
            //Debug.Log("rr");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Intelli")
        {
            Destroy(other.gameObject);
            statusController.intelli += 10;
            statusController.stress += 10;
            statusController.intelliPoint.text = "+10";
            statusController.stressPoint.text = "+10";
            statusController.intelliPoint.enabled = true;
            statusController.stressPoint.enabled = true;
        }
        if (other.gameObject.tag == "Skill")
        {
            Destroy(other.gameObject);
            statusController.skill += 10;
            statusController.stress += 10;
            statusController.skillPoint.text = "+10";
            statusController.stressPoint.text = "+10";
            statusController.skillPoint.enabled = true;
            statusController.stressPoint.enabled = true;
        }
        if (other.gameObject.tag == "Commu")
        {
            Destroy(other.gameObject);
            statusController.commu += 10;
            statusController.stress += 10;
            statusController.commuPoint.text = "+10";
            statusController.stressPoint.text = "+10";
            statusController.commuPoint.enabled = true;
            statusController.stressPoint.enabled = true;
        }
        if (other.gameObject.tag == "Beer")
        {
            Destroy(other.gameObject);
            statusController.intelli -= 10;
            statusController.stress -= 10;
            statusController.intelliPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.intelliPoint.enabled = true;
            statusController.stressPoint.enabled = true;
        }
        if (other.gameObject.tag == "Phone")
        {
            Destroy(other.gameObject);
            statusController.skill -= 10;
            statusController.stress -= 10;
            statusController.skillPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.skillPoint.enabled = true;
            statusController.stressPoint.enabled = true;
        }
        if (other.gameObject.tag == "Switch")
        {
            Destroy(other.gameObject);
            statusController.commu -= 10;
            statusController.stress -= 10;
            statusController.commuPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.commuPoint.enabled = true;
            statusController.stressPoint.enabled = true;
        }
    }
}
