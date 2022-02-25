using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float gravity = 20.0F;
    public float rotateSpeed = 0.5F;
    private float moveX, moveZ;
    private float waitTime;
    private bool wait;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 1.0f;
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 2.0f;
            animator.SetBool("Run", true);
        }else
        {
            animator.SetBool("Run", false);
        }
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed;

        if (controller.isGrounded)
        {
            gameObject.transform.Rotate(new Vector3(0, rotateSpeed * moveX, 0));
            moveDirection = speed * moveZ * gameObject.transform.forward;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //ドアを開けた後の待ち時間
        if (wait)
        {
            waitTime = waitTime + Time.deltaTime;
            //Debug.Log(waitTime);
            if (waitTime >= 2.0f)
            {
                waitTime = 0;
                wait = false;
            }

        }
    }

    void Warp(Transform transform)
    {
        //　CharacterControllerコンポーネントを一旦無効化する
        controller.enabled = false;
        //　Playerの位置を変更する
        this.transform.position = transform.position;
        //　CharacterControllerコンポーネントを有効化する
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
    }
}
