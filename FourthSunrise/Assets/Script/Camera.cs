using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        Reset_Pos();
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }

    void Reset_Pos()
    {
        this.transform.position = cameraPos.position;
        return;
    }
}
