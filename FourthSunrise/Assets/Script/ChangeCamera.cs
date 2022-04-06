using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;
    [SerializeField] private GameObject Map3;

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
            if (Map1 == null && Map2 == null && Map3 == null)
            {
                Debug.Log("hi");
                return;
            }
            else
            {
                Map1.SetActive(true);
                Map2.SetActive(true);
                Map3.SetActive(false);
            }
        }
    }
}
