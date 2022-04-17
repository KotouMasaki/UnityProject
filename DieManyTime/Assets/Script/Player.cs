using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotateSpeed;    //回転速度
    [SerializeField] private float gravity;       //重力の大きさ
    [SerializeField] private GameObject WhiteLight;
    [SerializeField] private Transform StartCamPos;
    [SerializeField] private GameObject FlashlightObj;
    [SerializeField] private bool Key_Lv1;
    [SerializeField] private bool Key_Lv2;
    [SerializeField] private bool Key_Lv3;
    [SerializeField] private bool flashlight;
    [SerializeField] private bool screwdriiver;

    private float h, v;
    private float walk;
    private bool look_up;
    private int lightCount;
    private GameObject playCamera;
    private GameObject SceneDirector;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playCamera = GameObject.Find("Camera");
        SceneDirector = GameObject.Find("SceneDirector");
        walk = walkSpeed;
        WhiteLight.SetActive(false);
        FlashlightObj.SetActive(false);
        flashlight = false;
        screwdriiver = false;
        Key_Lv1 = false;
        Key_Lv2 = false;
        Key_Lv3 = false;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");    //左右矢印キーの値(-1.0~1.0)
        v = Input.GetAxis("Vertical");      //上下矢印キーの値(-1.0~1.0)
        

        if (controller.isGrounded)
        {
            gameObject.transform.Rotate(new Vector3(0, (rotateSpeed * h), 0));
            moveDirection = walkSpeed * v * gameObject.transform.forward;
            if (moveDirection.magnitude > 0.1f)
            {
                animator.SetFloat("Speed", moveDirection.magnitude);
                transform.LookAt(transform.position + moveDirection);

                if (Input.GetKey(KeyCode.Space))
                {
                    walkSpeed = runSpeed;
                    animator.SetBool("Run", true);
                }
                else
                {
                    walkSpeed = walk;
                    animator.SetBool("Run", false);
                    animator.SetFloat("Speed", moveDirection.magnitude);
                }
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }

            //懐中電灯をつける
            if(Input.GetKeyDown(KeyCode.Q) && flashlight)
            {
                lightCount++;

                switch(lightCount)
                {
                    case 1:
                        WhiteLight.SetActive(true);
                        break;
                    case 2:
                        WhiteLight.SetActive(false);
                        lightCount = 0;
                        break;
                }
            }

            //マップを開く
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                SceneDirector.SendMessage("Show_Map");
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    /// <summary>
    /// 場所を変える時に使う関数
    /// </summary>
    /// <param name="ChangePos"></param>
    void Warp(Transform ChangePos)
    {
        SceneDirector.SendMessage("BackFadeOut");
        //　CharacterControllerコンポーネントを一旦無効化する
        controller.enabled = false;
        //　Playerの位置を変更する
        this.transform.position = ChangePos.position;
        //　CharacterControllerコンポーネントを有効化する
        controller.enabled = true;
        SceneDirector.SendMessage("Returned");
        SceneDirector.SendMessage("BackFadeIn");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Item")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.gameObject.name == "Light&Screwdriver")
                {
                    hit.gameObject.SetActive(false);
                    flashlight = true;
                    screwdriiver = true;
                    FlashlightObj.SetActive(true);
                    SceneDirector.SendMessage("Text", 1);
                    Debug.Log("懐中電灯とマイナスドライバーを手に入れた");
                }

                if (hit.gameObject.name == "Map")
                {
                    hit.gameObject.SetActive(false);
                    SceneDirector.SendMessage("Flag_Map");
                    SceneDirector.SendMessage("Text", 5);
                    Debug.Log("地図を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv1")
                {
                    hit.gameObject.SetActive(false);
                    Key_Lv1 = true;
                    SceneDirector.SendMessage("Text", 2);
                    Debug.Log("カードキーLv1を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv2")
                {
                    hit.gameObject.SetActive(false);
                    Key_Lv2 = true;
                    SceneDirector.SendMessage("Text", 3);
                    Debug.Log("カードキーLv2を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv3")
                {
                    hit.gameObject.SetActive(false);
                    Key_Lv3 = true;
                    SceneDirector.SendMessage("Text", 4);
                    Debug.Log("カードキーLv3を手に入れた");
                }

                if (hit.gameObject.name == "ControlPanel")
                {
                    hit.gameObject.SendMessage("control_panel");
                    hit.gameObject.SetActive(false);
                    SceneDirector.SendMessage("Text", 6);
                    Debug.Log("Lv.4の扉が開いたようだ");
                }
            }
        }

        if(hit.gameObject.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.gameObject.name == "Door_Lv1")
                {
                    if(Key_Lv1)
                    {
                        hit.gameObject.SendMessage("ChangePosPlayer");
                    }
                    else
                    {
                        SceneDirector.SendMessage("Text", 7);
                    }
                }

                if (hit.gameObject.name == "Door_Lv2")
                {
                    if (Key_Lv2)
                    {
                        hit.gameObject.SendMessage("ChangePosPlayer");
                    }
                    else
                    {
                        SceneDirector.SendMessage("Text", 7);
                    }
                }

                if (hit.gameObject.name == "Door_Lv3")
                {
                    if (Key_Lv3)
                    {
                        hit.gameObject.SendMessage("ChangePosPlayer");
                    }
                    else
                    {
                        SceneDirector.SendMessage("Text", 7);
                    }
                }

                if (hit.gameObject.name == "Vent")
                {
                    if (screwdriiver)
                    {
                        hit.gameObject.SendMessage("ChangePosPlayer");
                    }
                    else
                    {
                        SceneDirector.SendMessage("Text", 7);
                    }
                }
            }
        }

        if(hit.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
