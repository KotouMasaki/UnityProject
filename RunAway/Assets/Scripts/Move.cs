using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float Level;
    [SerializeField]
    private int stock;
    private float timer;
    private float moveX;
    private float moveZ;
    
    [SerializeField]
    private GameObject point_A;
    [SerializeField]
    private GameObject point_B;
    [SerializeField]
    private GameObject point_C;
    [SerializeField]
    private GameObject point_D;
    [SerializeField]
    private GameObject door_a;
    [SerializeField]
    private GameObject door_b;
    [SerializeField]
    private GameObject door_c;
    [SerializeField]
    private GameObject door_d;

    private Animator animator;
    private GameObject TextObj;
    private CharacterController controller;
    private Vector3 moveDirection;

    /// <summary>
    /// コンポ－ネントを取得する
    /// </summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        TextObj = GameObject.Find("Stock");
    }

    /// <summary>
    /// 移動用のクラス
    /// </summary>
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
                moveDirection.y = jump;
                animator.SetBool("Jump", true);
            }else
            {
                animator.SetBool("Jump", false);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if(this.transform.position.y <= -10)
        {
            stock -= 1;
            TextObj.GetComponent<Stock>().SubStock();
            Debug.Log(stock);
            if (stock == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
            else
            {
                controller.enabled = false;
                this.transform.position = point_A.transform.position;
                controller.enabled = true;
            }
        }
    }

    /// <summary>
    /// CharacterController用の当たり判定のクラス
    /// </summary>
    /// <param name="hit">/// </param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Obstacle")
        {
            stock -= 1;
            TextObj.GetComponent<Stock>().SubStock();
            Debug.Log(stock);
            if (stock == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
            else
            {
                controller.enabled = false;
                this.transform.position = point_A.transform.position;
                controller.enabled = true;
            }
        }
        if (hit.gameObject.tag == "Door_A")
        {
            //　CharacterControllerコンポーネントを一旦無効化する
            controller.enabled = false;
            //　Playerの位置を変更する
            this.transform.position = point_A.transform.position;
            //　CharacterControllerコンポーネントを有効化する
            controller.enabled = true;
            Destroy(door_a);
            Instantiate(door_b, new Vector3(-1.15625f, 0.125f, 120.0f), Quaternion.identity);
        }
        if(hit.gameObject.tag == "Door_B")
        {
            controller.enabled = false;
            this.transform.position = point_B.transform.position;
            controller.enabled = true;
        }
        if(hit.gameObject.tag == "Door_C")
        {
            controller.enabled = false;
            this.transform.position = point_C.transform.position;
            controller.enabled = true;
            Destroy(door_c);
            Instantiate(door_d, new Vector3(-1.15625f, 0.125f, 120.0f), Quaternion.identity);
        }
        if(hit.gameObject.tag == "Door_D")
        {
            controller.enabled = false;
            this.transform.position = point_D.transform.position;
            controller.enabled = true;
        }
        if(hit.gameObject.tag == "Door_E")
        {
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
