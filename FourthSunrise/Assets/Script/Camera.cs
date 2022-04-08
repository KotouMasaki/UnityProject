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
        //���Player������������
        transform.LookAt(player.transform);
    }

    /// <summary>
    /// �J�������J�n�n�_�ɖ߂�
    /// </summary>
    void Reset_Pos()
    {
        this.transform.position = cameraPos.position;
        return;
    }
}
