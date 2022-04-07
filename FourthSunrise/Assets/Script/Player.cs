using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int lightCount;
    private int MapCount;
    //private int day;
    private GameObject playCamera;
    private GameObject ui_Director;
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
        ui_Director = GameObject.Find("UI_Director");
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
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                ui_Director.SendMessage("Show_Map");
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void Warp(Transform ChangePos)
    {
        ui_Director.SendMessage("BackFadeOut");
        //　CharacterControllerコンポーネントを一旦無効化する
        controller.enabled = false;
        //　Playerの位置を変更する
        this.transform.position = ChangePos.position;
        //　CharacterControllerコンポーネントを有効化する
        controller.enabled = true;
        ui_Director.SendMessage("Returned");
        ui_Director.SendMessage("BackFadeIn");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Item")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (hit.gameObject.name == "Light&Screwdriver")
                {
                    flashlight = true;
                    screwdriiver = true;
                    FlashlightObj.SetActive(true);
                    ui_Director.SendMessage("Text", 1);
                    Debug.Log("懐中電灯とマイナスドライバーを手に入れた");
                }

                if (hit.gameObject.name == "Map")
                {
                    ui_Director.SendMessage("Flag_Map");
                    ui_Director.SendMessage("Text", 5);
                    Debug.Log("地図を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv1")
                {
                    Key_Lv1 = true;
                    ui_Director.SendMessage("Text", 2);
                    Debug.Log("カードキーLv1を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv2")
                {
                    Key_Lv2 = true;
                    ui_Director.SendMessage("Text", 3);
                    Debug.Log("カードキーLv2を手に入れた");
                }
                if (hit.gameObject.name == "Key_Lv3")
                {
                    Key_Lv3 = true;
                    ui_Director.SendMessage("Text", 4);
                    Debug.Log("カードキーLv3を手に入れた");
                }
            }
        }

        if(hit.gameObject.tag == "Door")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (hit.gameObject.name == "Door_Lv1" && Key_Lv1)
                {
                    hit.gameObject.SendMessage("ChangePosPlayer");
                }

                if (hit.gameObject.name == "Door_Lv2" && Key_Lv2)
                {
                    hit.gameObject.SendMessage("ChangePosPlayer");
                }

                if (hit.gameObject.name == "Door_Lv3" && Key_Lv3)
                {
                    hit.gameObject.SendMessage("ChangePosPlayer");
                }

                if (hit.gameObject.name == "Vent" && screwdriiver)
                {
                    hit.gameObject.SendMessage("ChangePosPlayer");
                }
            }
        }
    }
}
