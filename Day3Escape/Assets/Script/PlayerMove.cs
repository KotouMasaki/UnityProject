using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float rotateSpeed = 3.0F;    //��]���x
    [SerializeField]
    private float gravity = 20.0F;       //�d�͂̑傫��
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private GameObject footSteps;
    private float h, v;
    private float walk;
    private float waitTime;
    private bool wait;
    private CharacterController controller;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        walk = walkSpeed;
        wait = false;
    }

    // Update is called once per frame
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
                    //Debug.Log("����");
                    //Instantiate(footSteps);
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
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //�h�A���J������̑҂�����
        if (wait)
        {
            waitTime = waitTime + Time.deltaTime;
            //Debug.Log(waitTime);
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
        //�@Player�̈ʒu��ύX����
        this.transform.position = transform.position;
        //�@CharacterController�R���|�[�l���g��L��������
        controller.enabled = true;
        Debug.Log("Warp!");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "ChangePosB")
        {
            
            if(Input.GetKey(KeyCode.E) && !wait)
            {
                Debug.Log("HitB");
                hit.gameObject.SendMessage("Change");
                wait = true;
            }
        }

        if (hit.gameObject.name == "ChangePosA")
        {
            
            if (Input.GetKey(KeyCode.E) && !wait)
            {
                Debug.Log("HitA");
                hit.gameObject.SendMessage("Change");
                wait = true;
            }
        }
        if(hit.gameObject.name == "ChangeCameraB" && !wait)
        {
            hit.gameObject.SendMessage("Change");
            wait = true;
        }
        if(hit.gameObject.name == "ChangeCameraA" && !wait)
        {
            Debug.Log("Hi!");
            hit.gameObject.SendMessage("Change");
            wait = true;
        }
    }
}
