using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //�W�����v�̑��x
    [SerializeField] private int jumpVelocity = 300;
    //�w�N���Ƃ̈ړ����x
    public int[] moveVelocity = { 10, 11, 12, 13 };

    private Rigidbody rb;

    //�W�����v�ł��邩
    private bool isJump;
    //�S�[��������
    public bool isGoal = false;
    //�����Ă��邩
    public bool isMove = false;

    //�S�[��
    [SerializeField] private GameObject goal;

    [SerializeField] protected TextController textController;
    [SerializeField] private StatusController statusController;
    [SerializeField] private BossStatus bossStatus;
    [SerializeField] private ItemEffect itemEffect;

    //�����A�E���ɂ��邩
    private bool left = false;
    private bool right = false;

    private float time = 0;
    //���E�ɓ�����Ԋu
    [SerializeField] private float moveTime = 0.2f;

    protected Animator animator = null;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip itemClip;
    [SerializeField] private AudioClip goalClip;

    //����2��炳�Ȃ����߂�bool
    private bool isGoalClip = true;

    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //�J�E���g�_�E���I�����S�[����z���W+3����O�����Ԑ؂ꂶ��Ȃ��ꍇ�A�v���C���[������
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

        //�S�[���ɒ������ꍇ
        if (transform.position.z >= goal.transform.position.z)
        {
            isGoal = true;
            //����1�񂾂��炷
            if(isGoalClip)
            {
                audioSource.clip = goalClip;
                audioSource.Play();
                isGoalClip = false;
            }
        }
    }

    private void playerMove()
    {
        //���[
        if(transform.position.x < -1)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        //�E�[
        if (transform.position.x > 1)
        {
            right = true;
        }
        else
        {
            right = false;
        }

        //A�������ꂽ���S�[�����Ă��Ȃ������[����Ȃ����n�ʂɂ��Ă��邩������Ԋu�̏ꍇ
        if (Input.GetKeyDown(KeyCode.A) && !isGoal && !left && isJump && time > moveTime)
        {
            //1���ɂ����
            transform.Translate(-1.2f, 0, 0);
            time = 0;
        }
        //D�������ꂽ���S�[�����Ă��Ȃ����E�[����Ȃ����n�ʂɂ��Ă��邩������Ԋu�̏ꍇ
        if (Input.GetKeyDown(KeyCode.D) && !isGoal && !right && isJump && time > moveTime)
        {
            //1�E�ɂ����
            transform.Translate(1.2f, 0, 0);
            time = 0;
        }
        //Space or W�������ꂽ���n�ʂɂ��Ă���ꍇ�A�W�����v����
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isJump)
        {
            rb.AddForce(new Vector3(0, jumpVelocity, 0));
            isJump = false;
            animator.SetBool("jump", true);

            audioSource.clip = jumpClip;
            audioSource.Play();
        }
        //�O�ɐi��
        transform.Translate(0, 0, moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime);
        time += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //���ɐڐG���Ă���ꍇ
        if(collision.gameObject.tag == "Road"){
            isJump = true;
            animator.SetBool("jump", false);
        }
    }

    //�e�A�C�e�����擾�����ꍇ�A�X�e�[�^�X�̑����Ɖ�ʍ���̃X�e�[�^�X�����̕\���̏���
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
        }
    }
}
