using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //private const float posVelocity = 8.0f;
    [SerializeField] private int jumpVelocity = 300;
    public int moveVelocity = 10;

    private Rigidbody rb;

    private bool isJump;
    public bool isGoal = false;
    public bool isMove = false;

    [SerializeField] protected TextController textController;
    [SerializeField] private GameObject goal;
    [SerializeField] private StatusController statusController;

    private bool left = false;
    private bool right = false;

    private float time = 0;
    [SerializeField] private float moveTime = 0.2f;

    protected Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (textController.isCountFinish && transform.position.z < goal.transform.position.z + 3 && !textController.isTimeFinish)
        {
            playerMove();
            isMove = true;
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
        }

        if (transform.position.z >= goal.transform.position.z || textController.isTimeFinish)
        {
            isGoal = true;
        }
    }

    protected void playerMove()
    {
        if(transform.position.x < -1)
        {
            left = true;
            //Debug.Log("l");
        }
        else
        {
            left = false;
            //Debug.Log("nl");
        }
        if (transform.position.x > 1)
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
        time += Time.deltaTime;
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
            statusController.intelliChange += 10;
            statusController.stressChange += 10;

            statusController.intellitime = 0.5f;
            statusController.stresstime = 0.5f;

            //statusController.intelliPoint.text = statusController.intelliChange.ToString();
            //statusController.stressPoint.text = statusController.stressChange.ToString();
            //statusController.intelliPoint.enabled = true;
            //statusController.stressPoint.enabled = true;
        }
        if (other.gameObject.tag == "Skill")
        {
            Destroy(other.gameObject);
            statusController.skill += 10;
            statusController.stress += 10;
            statusController.skillChange += 10;
            statusController.stressChange += 10;

            statusController.skilltime = 0.5f;
            statusController.stresstime = 0.5f;

            /*statusController.skillPoint.text = "+10";
            statusController.stressPoint.text = "+10";
            statusController.skillPoint.enabled = true;
            statusController.stressPoint.enabled = true;*/
        }
        if (other.gameObject.tag == "Commu")
        {
            Destroy(other.gameObject);
            statusController.commu += 10;
            statusController.stress += 10;
            statusController.commuChange += 10;
            statusController.stressChange += 10;

            statusController.commutime = 0.5f;
            statusController.stresstime = 0.5f;

            /*statusController.commuPoint.text = "+10";
            statusController.stressPoint.text = "+10";
            statusController.commuPoint.enabled = true;
            statusController.stressPoint.enabled = true;*/
        }
        if (other.gameObject.tag == "Beer")
        {
            Destroy(other.gameObject);
            statusController.intelli -= 10;
            statusController.stress -= 10;
            statusController.intelliChange -= 10;
            statusController.stressChange -= 10;

            statusController.intellitime = 0.5f;
            statusController.stresstime = 0.5f;

            /*statusController.intelliPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.intelliPoint.enabled = true;
            statusController.stressPoint.enabled = true;*/
        }
        if (other.gameObject.tag == "Phone")
        {
            Destroy(other.gameObject);
            statusController.skill -= 10;
            statusController.stress -= 10;
            statusController.skillChange -= 10;
            statusController.stressChange -= 10;

            statusController.skilltime = 0.5f;
            statusController.stresstime = 0.5f;

            /*statusController.skillPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.skillPoint.enabled = true;
            statusController.stressPoint.enabled = true;*/
        }
        if (other.gameObject.tag == "Switch")
        {
            Destroy(other.gameObject);
            statusController.commu -= 10;
            statusController.stress -= 10;
            statusController.commuChange -= 10;
            statusController.stressChange -= 10;

            statusController.commutime = 0.5f;
            statusController.stresstime = 0.5f;

            /*statusController.commuPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.commuPoint.enabled = true;
            statusController.stressPoint.enabled = true;*/
        }
    }
}
