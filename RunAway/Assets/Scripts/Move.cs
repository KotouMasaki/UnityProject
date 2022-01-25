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
    public GameObject player;
    public GameObject point_A;
    public GameObject point_B;
    public GameObject point_C;
    public GameObject door_a;
    public GameObject door_b;
    public GameObject door_c;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > 10)
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
                //Debug.Log("ジャンプ！");
            }else
            {
                animator.SetBool("Jump", false);
            }
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
        if (hit.gameObject.tag == "Door_A")
        {
            Debug.Log("hit_A");
            //　CharacterControllerコンポーネントを一旦無効化する
            controller.enabled = false;
            //　Playerの位置を変更する
            player.transform.position = point_A.transform.position;
            //　CharacterControllerコンポーネントを有効化する
            controller.enabled = true;
            Destroy(door_a);
            Instantiate(door_b, new Vector3(-1.15625f, 0.125f, 120f), Quaternion.identity);
        }
        if(hit.gameObject.tag == "Door_B")
        {
            Debug.Log("hit_B");
            controller.enabled = false;
            player.transform.position = point_B.transform.position;
            controller.enabled = true;
        }
    }
}
