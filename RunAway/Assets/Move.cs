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

        // 接地しているなら
        if (controller.isGrounded)
        {
            // スペースキーでジャンプ
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ジャンプ力を設定
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

        // 重力計算
        moveDirection.y -= gravity * Time.deltaTime;

        // Playerを動かす処理
        controller.Move(moveDirection * Time.deltaTime);
    }
    
    void FixedUpdate()
    {
        
    }
}
