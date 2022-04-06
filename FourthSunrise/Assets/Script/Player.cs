using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotateSpeed;    //回転速度
    [SerializeField] private float gravity;       //重力の大きさ
    [SerializeField] private GameObject WhiteLight;
    [SerializeField] private Transform StartPos;
    [SerializeField] private Transform StartCamPos;
    //[SerializeField] private Transform waitPos;
    [SerializeField] private GameObject Map;
    [SerializeField] private GameObject blankMap1;
    [SerializeField] private GameObject blankMap2;
    [SerializeField] private GameObject FlashlightObj;
    [SerializeField] private UI_Director ui_Director;
    [SerializeField] private bool Key_Lv1;
    [SerializeField] private bool Key_Lv2;
    [SerializeField] private bool Key_Lv3;
    [SerializeField] private bool flashlight;
    [SerializeField] private bool screwdriiver;
    //[SerializeField] private AudioClip sound1;
    //[SerializeField] private AudioClip sound2;
    [SerializeField] private Image backImage;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text text4;
    [SerializeField] private Text text5;
    [SerializeField] private Text text6;

    private float h, v;
    private float walk;
    private int lightCount;
    private int MapCount;
    private int day;
    private GameObject playCamera;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        ui_Director = GetComponentInParent<UI_Director>();
        playCamera = GameObject.Find("Camera");
        walk = walkSpeed;
        WhiteLight.SetActive(false);
        Map.SetActive(false);
        blankMap1.SetActive(false);
        blankMap2.SetActive(false);
        FlashlightObj.SetActive(false);
        flashlight = false;
        screwdriiver = false;
        Key_Lv1 = false;
        Key_Lv2 = false;
        Key_Lv3 = false;
        text1.DOFade(0f, 0f);
        text2.DOFade(0f, 0f);
        text3.DOFade(0f, 0f);
        text4.DOFade(0f, 0f);
        text5.DOFade(0f, 0f);
        text6.DOFade(0f, 0f);
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
                MapCount++;

                switch(MapCount)
                {
                    case 1:
                        Map.SetActive(true);
                        break;
                    case 2:
                        Map.SetActive(false);
                        MapCount = 0;
                        break;
                }
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void Warp(Transform ChangePos)
    {
        BackFadeOut();
        //　CharacterControllerコンポーネントを一旦無効化する
        controller.enabled = false;
        //　Playerの位置を変更する
        this.transform.position = ChangePos.position;
        //　CharacterControllerコンポーネントを有効化する
        controller.enabled = true;
        BackFadeIn();
    }

    void Get_caught(Transform ChangePos)
    {
        //　CharacterControllerコンポーネントを一旦無効化する
        controller.enabled = false;
        //　Playerの位置を変更する
        this.transform.position = ChangePos.position;
        //　CharacterControllerコンポーネントを有効化する
        controller.enabled = true;
        playCamera.transform.position = StartCamPos.position;
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
                    Text(1);
                    Debug.Log("懐中電灯とマイナスドライバーを手に入れた");
                }

                if (hit.gameObject.name == "Map")
                {
                    blankMap1.SetActive(true);
                    blankMap2.SetActive(true);
                    Text(5);
                    Debug.Log("地図を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv1")
                {
                    Key_Lv1 = true;
                    Text(2);
                    Debug.Log("カードキーLv1を手に入れた");
                }

                if (hit.gameObject.name == "Key_Lv2")
                {
                    Key_Lv2 = true;
                    Text(3);
                    Debug.Log("カードキーLv2を手に入れた");
                }
                if (hit.gameObject.name == "Key_Lv3")
                {
                    Key_Lv3 = true;
                    Text(4);
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

    void BackFadeOut()
    {
        backImage.DOFade(1f, 0f);
    }

    void BackFadeIn()
    {
        backImage.DOFade(0f, 2f);
    }

    void Text(int num)
    {
        switch (num)
        {
            case 1:
                text1.DOFade(1f, 0f);
                text1.DOFade(0f, 5f);
                break;
            case 2:
                text2.DOFade(1f, 0f);
                text2.DOFade(0f, 5f);
                break;
            case 3:
                text3.DOFade(1f, 0f);
                text3.DOFade(0f, 5f);
                break;
            case 4:
                text4.DOFade(1f, 0f);
                text4.DOFade(0f, 5f);
                break;
            case 5:
                text5.DOFade(1f, 0f);
                text5.DOFade(0f, 5f);
                break;
            case 6:
                text6.DOFade(1f, 0f);
                text6.DOFade(0f, 5f);
                break;
        }
    }
}
