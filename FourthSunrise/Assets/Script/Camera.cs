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
        this.transform.position = cameraPos.position;
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
