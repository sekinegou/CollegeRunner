using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMController : MonoBehaviour
{
    public static BGMController instance;

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioClip menu;
    [SerializeField] private AudioClip game;
    [SerializeField] private AudioClip boss;

    private void Awake()
    {
        //シーン遷移後も消えないようにする
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgm.clip = menu;
        bgm.Play();

        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //次のシーンごとにBGMを変える
    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (next.name == "GameScene")
        {
            //ボスステージの場合
            if (OverSceneStatus.isBoss)
            {
                bgm.Stop();
                bgm.clip = boss;
                bgm.Play();
            }
            //ボスステージではない場合
            else
            {
                bgm.Stop();
                bgm.clip = game;
                bgm.Play();
            }
            
        }
        if (next.name == "Result")
        {
            bgm.Stop();
            bgm.clip = menu;
            bgm.Play();
        }
        if (next.name == "LastResult")
        {
            bgm.Stop();
            bgm.clip = menu;
            bgm.Play();
        }
    }
}
