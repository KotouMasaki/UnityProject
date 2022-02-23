using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform searchArea;
    public GameObject player;
    public Transform playerPos;
    public GameObject cameraA;
    public GameObject cameraB;
    public Transform changePosA;
    public Transform changePosB;
    //　ドアエリアに入っているかどうか
    private bool openDoor;
	//　ドアのアニメーター
	private Animator animator;
    private float waitTime;
    private bool wait;
    
    void Start()
	{
        wait = false;
		openDoor = false;
		animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 diff = searchArea.transform.position - playerPos.transform.position;
        //Debug.Log(diff.magnitude);
        if (diff.magnitude < 2.0f && 0 < diff.magnitude)
        {
            if (Input.GetKey(KeyCode.E) && !wait)
            {
                Debug.Log("posA");
                cameraA.SetActive(false);
                cameraB.SetActive(true);
                player.SendMessage("Warp", changePosA);
                wait = true;
            }
        }
        if(diff.magnitude <1.3)
        {
            if (Input.GetKey(KeyCode.E) && !wait)
            {
                Debug.Log("posB");
                cameraA.SetActive(true);
                cameraB.SetActive(false);
                player.SendMessage("Warp", changePosB);
                wait = true;
            }
        }
        if(openDoor)
        {
            waitTime = waitTime + Time.deltaTime;
            Debug.Log(waitTime);
            if (waitTime >= 5.0f)
            {
                Debug.Log("hi!");
                waitTime = 0;
                animator.SetBool("Open", false);
                openDoor = false;
            }
        }

        if(wait)
        {
            waitTime = waitTime + Time.deltaTime;
            Debug.Log(waitTime);
            if(waitTime >= 2.0f)
            {
                waitTime = 0;
                wait = false;
            }

        }
    }

    void Sample()
    {
        Debug.Log("おめでとう");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }
    }
}
