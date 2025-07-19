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
    public int[] moveVelocity = { 10, 11, 12, 13 };

    private Rigidbody rb;

    private bool isJump;
    public bool isGoal = false;
    public bool isMove = false;

    [SerializeField] protected TextController textController;
    [SerializeField] private GameObject goal;
    [SerializeField] private StatusController statusController;
    [SerializeField] private BossStatus bossStatus;
    [SerializeField] private ItemEffect itemEffect;

    private bool left = false;
    private bool right = false;

    private float time = 0;
    [SerializeField] private float moveTime = 0.2f;

    protected Animator animator = null;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip itemClip;
    [SerializeField] private AudioClip goalClip;

    private bool isGoalClip = true;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Debug.Log(moveVelocity[OverSceneStatus.year - 1]);
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
            isMove = false;
            animator.SetBool("move", false);
        }

        if (transform.position.z >= goal.transform.position.z)
        {
            isGoal = true;
            if(isGoalClip)
            {
                audioSource.clip = goalClip;
                audioSource.Play();
                isGoalClip = false;
            }
            
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
            animator.SetBool("jump", true);
            //animator.SetBool("move", false);

            audioSource.clip = jumpClip;
            audioSource.Play();
        }
        transform.Translate(0, 0/*jumpVelocity *= 0.1f*/, moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime);
        time += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Road"){
            isJump = true;
            //Debug.Log("rr");
            animator.SetBool("jump", false);
            //animator.SetBool("move", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.clip = itemClip;
        audioSource.Play();

        if (other.gameObject.tag == "Intelli")
        {
            Destroy(other.gameObject);
            statusController.intelli += itemEffect.goodIntelli;
            statusController.stress += itemEffect.goodStress;
            statusController.intelliChange += itemEffect.goodIntelli;
            statusController.stressChange += itemEffect.goodStress;

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
            statusController.skill += itemEffect.goodSkill;
            statusController.stress += itemEffect.goodStress;
            statusController.skillChange += itemEffect.goodSkill;
            statusController.stressChange += itemEffect.goodStress;

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
            statusController.commu += itemEffect.goodCommu;
            statusController.stress += itemEffect.goodStress;
            statusController.commuChange += itemEffect.goodCommu;
            statusController.stressChange += itemEffect.goodStress;

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
            statusController.intelli -= itemEffect.badIntelli;
            statusController.stress -= itemEffect.badStress;
            statusController.intelliChange -= itemEffect.badIntelli;
            statusController.stressChange -= itemEffect.badStress;

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
            statusController.skill -= itemEffect.goodSkill;
            statusController.stress -= itemEffect.badStress;
            statusController.skillChange -= itemEffect.goodSkill;
            statusController.stressChange -= itemEffect.badStress;

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
            statusController.commu -= itemEffect.goodCommu;
            statusController.stress -= itemEffect.badStress;
            statusController.commuChange -= itemEffect.goodCommu;
            statusController.stressChange -= itemEffect.badStress;

            statusController.commutime = 0.5f;
            statusController.stresstime = 0.5f;

            /*statusController.commuPoint.text = "-10";
            statusController.stressPoint.text = "-10";
            statusController.commuPoint.enabled = true;
            statusController.stressPoint.enabled = true;*/
        }
    }
}
