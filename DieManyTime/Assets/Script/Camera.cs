using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] bool subCam;
    [SerializeField] private Transform cameraPos;
    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        if(subCam) Reset_Pos();
    }

    void Update()
    {
        //���Player������������
        transform.LookAt(player.transform);
        if(subCam)
        {
            this.transform.position = target.position + offset;
            this.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
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
