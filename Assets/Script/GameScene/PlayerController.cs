using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //ジャンプの速度
    [SerializeField] private int jumpVelocity = 300;
    //学年ごとの移動速度
    public int[] moveVelocity = { 10, 11, 12, 13 };

    private Rigidbody rb;

    //ジャンプできるか
    private bool isJump;
    //ゴールしたか
    public bool isGoal = false;
    //動いているか
    public bool isMove = false;

    //ゴール
    [SerializeField] private GameObject goal;

    [SerializeField] protected TextController textController;
    [SerializeField] private StatusController statusController;
    [SerializeField] private BossStatus bossStatus;
    [SerializeField] private ItemEffect itemEffect;

    //左側、右側にいるか
    private bool left = false;
    private bool right = false;

    private float time = 0;
    //左右に動ける間隔
    [SerializeField] private float moveTime = 0.2f;

    protected Animator animator = null;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip itemClip;
    [SerializeField] private AudioClip goalClip;

    //音を2回鳴らさないためのbool
    private bool isGoalClip = true;

    void Start()
    {
        UnityEngine.Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //カウントダウン終了かつゴールのz座標+3より手前かつ時間切れじゃない場合、プレイヤーが動く
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

        //ゴールに着いた場合
        if (transform.position.z >= goal.transform.position.z)
        {
            isGoal = true;
            //音を1回だけ鳴らす
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
        //左端
        if(transform.position.x < -1)
        {
            left = true;
        }
        else
        {
            left = false;
        }
        //右端
        if (transform.position.x > 1)
        {
            right = true;
        }
        else
        {
            right = false;
        }

        //Aが押されたかつゴールしていないかつ左端じゃないかつ地面についているかつ動ける間隔の場合
        if (Input.GetKeyDown(KeyCode.A) && !isGoal && !left && isJump && time > moveTime)
        {
            //1つ左にずれる
            transform.Translate(-1.2f, 0, 0);
            time = 0;
        }
        //Dが押されたかつゴールしていないかつ右端じゃないかつ地面についているかつ動ける間隔の場合
        if (Input.GetKeyDown(KeyCode.D) && !isGoal && !right && isJump && time > moveTime)
        {
            //1つ右にずれる
            transform.Translate(1.2f, 0, 0);
            time = 0;
        }
        //Space or Wが押されたかつ地面についている場合、ジャンプする
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && isJump)
        {
            rb.AddForce(new Vector3(0, jumpVelocity, 0));
            isJump = false;
            animator.SetBool("jump", true);

            audioSource.clip = jumpClip;
            audioSource.Play();
        }
        //前に進む
        transform.Translate(0, 0, moveVelocity[OverSceneStatus.year - 1] * Time.deltaTime);
        time += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //道に接触している場合
        if(collision.gameObject.tag == "Road"){
            isJump = true;
            animator.SetBool("jump", false);
        }
    }

    //各アイテムを取得した場合、ステータスの増減と画面左上のステータス増減の表示の処理
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
