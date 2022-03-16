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

    private GameObject camera;

    void Start()
    {
        camera = GameObject.Find("Camera");
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            camera.transform.position = cameraPos.position;
            sensor_a.SetActive(true);
            sensor_b.SetActive(false);
        }
    }
}
