using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    private GameObject player;
    public GameObject cameraA;
    public GameObject cameraB;
    public Transform changePos;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    void Change()
    {
        Debug.Log("posA");
        cameraA.SetActive(false);
        cameraB.SetActive(true);
        player.SendMessage("Warp", changePos);
    }
}
