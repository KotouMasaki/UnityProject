using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    private GameObject player;
    private GameObject soldier;
    public GameObject cameraA;
    public GameObject cameraB;
    public Transform changePos;

    void Start()
    {
        player = GameObject.Find("Player");
        soldier = GameObject.Find("Soldier");
    }

    void Update()
    {
        
    }

    void ChangePosPlayer()
    {
        Debug.Log("posA");
        cameraA.SetActive(false);
        cameraB.SetActive(true);
        player.SendMessage("Warp", changePos);
    }
}
