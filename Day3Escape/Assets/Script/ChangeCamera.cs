using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject sensor_a;
    [SerializeField]
    private GameObject sensor_b;
    [SerializeField]
    private Transform cameraPos;

    private GameObject playCamera;

    void Start()
    {
        playCamera = GameObject.Find("Camera");
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            playCamera.transform.position = cameraPos.position;
            sensor_a.SetActive(true);
            sensor_b.SetActive(false);
        }
    }
}
