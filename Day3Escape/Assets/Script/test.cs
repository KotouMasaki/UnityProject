using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class test : MonoBehaviour
{
    public float speed = 6.0F;          //���s���x
    public float jumpSpeed = 8.0F;      //�W�����v��
    public float gravity = 20.0F;       //�d�͂̑傫��
    public float rotateSpeed = 3.0F;    //��]���x

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float h, v;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }//Start()

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxis("Horizontal");    //���E���L�[�̒l(-1.0~1.0)
        v = Input.GetAxis("Vertical");      //�㉺���L�[�̒l(-1.0~1.0)
        Debug.Log(v);

        if (controller.isGrounded)
        {
            gameObject.transform.Rotate(new Vector3(0, rotateSpeed * h, 0));
            moveDirection = speed * v * gameObject.transform.forward;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }//Update()
}
