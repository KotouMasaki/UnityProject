using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private Animator animator;
    CharacterController controller;
    private float speed = 6.0f;
    private float gravity = 9.8f;
    private Vector3 moveDirection;
    private float timer;
    private float Level = 1.0f;
    private float moveX;
    private float moveZ;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 5)
        {
            Level += 0.1f;
            timer = 0.0f;
            Debug.Log(Level);
        }
        moveZ = speed * Level;
        moveX = Input.GetAxis("Horizontal") * speed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        controller.SimpleMove(direction);

        if (controller.isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = 8;
                animator.SetBool("Jump", true);
                Debug.Log("ÉWÉÉÉìÉvÅI");
            }else
            {
                animator.SetBool("Jump", false);
            }
            //animator.SetBool("Ground", true);
        }

        //
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if(this.transform.position.y <= -10)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Obstacle")
        {
            Debug.Log("hit");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
