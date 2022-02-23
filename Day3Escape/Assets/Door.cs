using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject player;
    public Transform playerPos;
    public GameObject cameraA;
    public GameObject cameraB;
    public Transform changePos;
    private float waitTime;
    private bool wait;

    void Start()
    {
        wait = false;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (wait)
        {
            waitTime = waitTime + Time.deltaTime;
            Debug.Log(waitTime);
            if (waitTime >= 2.0f)
            {
                waitTime = 0;
                wait = false;
            }

        }
    }

    void Change()
    {
        Debug.Log("posA");
        cameraA.SetActive(false);
        cameraB.SetActive(true);
        player.SendMessage("Warp", changePos);
        wait = true;
    }
}
