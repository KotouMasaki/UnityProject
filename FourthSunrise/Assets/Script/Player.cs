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
    [SerializeField] private Transform StartPos;
    [SerializeField] private Transform StartCamPos;
    [SerializeField] private GameObject Map;
    [SerializeField] private bool Key_Lv1;
    [SerializeField] private bool Key_Lv2;
    [SerializeField] private bool Key_Lv3;
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;

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
        walk = walkSpeed;
        WhiteLight.SetActive(false);
        playCamera = GameObject.Find("Camera");
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
            if(Input.GetKeyDown(KeyCode.Q))
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
        //　CharacterControllerコンポーネントを一旦無効化する
        controller.enabled = false;
        audioSource.PlayOneShot(sound1);
        //　Playerの位置を変更する
        this.transform.position = ChangePos.position;
        //　CharacterControllerコンポーネントを有効化する
        controller.enabled = true;
        //Debug.Log("Warp!");
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
        if (hit.gameObject.name == "Door_Lv1" && Key_Lv1)
        {
            if(Input.GetKey(KeyCode.E))
            {
                hit.gameObject.SendMessage("ChangePosPlayer");
            }
        }

        if (hit.gameObject.name == "Door_Lv2" && Key_Lv2)
        {
            if (Input.GetKey(KeyCode.E))
            {
                hit.gameObject.SendMessage("ChangePosPlayer");
            }
        }

        if(hit.gameObject.name == "Door_Lv3" && Key_Lv3)
        {
            if(Input.GetKey(KeyCode.E))
            {
                hit.gameObject.SendMessage("ChangePosPlayer");
            }
        }

        if (hit.gameObject.name == "Vent")
        {
            if (Input.GetKey(KeyCode.E))
            {
                hit.gameObject.SendMessage("ChangePosPlayer");
            }
        }
    }
}
