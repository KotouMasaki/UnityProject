using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float rotateSpeed;    //��]���x
    [SerializeField]
    private float gravity;       //�d�͂̑傫��
    [SerializeField]
    private bool Key_Lv1;
    [SerializeField]
    private bool Key_Lv2;
    [SerializeField]
    private bool Key_Lv3;
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;

    private float h, v;
    private float walk;
    private float waitTime;
    private bool wait;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    private AudioSource audioSource;
    private Animator animator;

    [SerializeField] private Timer timer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        walk = walkSpeed;
        wait = false;

        //timer = GetComponentInParent<Timer>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");    //���E���L�[�̒l(-1.0~1.0)
        v = Input.GetAxis("Vertical");      //�㉺���L�[�̒l(-1.0~1.0)

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
                Debug.Log("hi!");
                //timer.TimeLimit();
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //�h�A���J������̑҂�����
        if (wait)
        {
            waitTime = waitTime + Time.deltaTime;
            Debug.Log(waitTime);
            if (waitTime >= 1.0f)
            {
                wait = false;
                waitTime = 0;
            }
        }
    }

    void Warp(Transform transform)
    {
        //�@CharacterController�R���|�[�l���g����U����������
        controller.enabled = false;
        audioSource.PlayOneShot(sound1);
        //�@Player�̈ʒu��ύX����
        this.transform.position = transform.position;
        //�@CharacterController�R���|�[�l���g��L��������
        controller.enabled = true;
        Debug.Log("Warp!");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Door_Lv0")
        {

            if (Input.GetKey(KeyCode.E))
            {
                //Debug.Log("HitB");
                hit.gameObject.SendMessage("ChangePosPlayer");
                //wait = true;
            }
        }

        if (hit.gameObject.name == "Door_Lv1" && Key_Lv1)
        {
            if(Input.GetKey(KeyCode.E))
            {
                //Debug.Log("HitB");
                hit.gameObject.SendMessage("ChangePosPlayer");
                //wait = true;
            }
        }

        if (hit.gameObject.name == "Door_Lv2" && Key_Lv2)
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                //Debug.Log("HitA");
                hit.gameObject.SendMessage("ChangePosPlayer");
                //wait = true;
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

    void Footsteps()
    {
        //if (sound2) return;
        audioSource.PlayOneShot(sound2);
    }
}
