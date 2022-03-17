using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    private GameObject player;
    //private GameObject soldier;
    private GameObject playCamera;
    [SerializeField]
    private Transform cameraPos;
    [SerializeField]
    private Transform changePos;

    void Start()
    {
        player = GameObject.Find("Player");
        //soldier = GameObject.Find("Soldier");
        playCamera = GameObject.Find("Camera");

    }

    void Update()
    {
        
    }

    void ChangePosPlayer()
    {
        playCamera.transform.position = cameraPos.position;
        player.SendMessage("Warp", changePos);
    }
}
