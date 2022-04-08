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
        //常にPlayerを向き続ける
        transform.LookAt(player.transform);
    }

    /// <summary>
    /// カメラを開始地点に戻す
    /// </summary>
    void Reset_Pos()
    {
        this.transform.position = cameraPos.position;
        return;
    }
}
