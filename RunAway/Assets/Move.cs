using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
    CharacterController controller;
    private float speed = 6.0f;
    private float gravity = 9.8f;
    private Vector3 moveDirection;
    private float timer;
    private float moveX;
    private float moveZ;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveZ = speed;
        moveX = Input.GetAxis("Horizontal") * speed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        controller.SimpleMove(direction);

        // �ڒn���Ă���Ȃ�
        if (controller.isGrounded)
        {
            // �X�y�[�X�L�[�ŃW�����v
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // �W�����v�͂�ݒ�
                moveDirection.y = 8;
                animator.SetBool("Jump", true);
                //if(animator.SetBool("Jump"))
                //{

                //}
            }else
            {
                animator.SetBool("Jump", false);
            }
            animator.SetBool("Ground", true);
        }
        //animator.SetBool("Ground", false);

        // �d�͌v�Z
        moveDirection.y -= gravity * Time.deltaTime;

        // Player�𓮂�������
        controller.Move(moveDirection * Time.deltaTime);
    }
    
    void FixedUpdate()
    {
        
    }
}
