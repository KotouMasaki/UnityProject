using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class test : MonoBehaviour
{
    //[SerializeField]
    //private ChangeCamera changeCamera;
    public GameObject sensor_a;
    public GameObject sensor_b;
    public GameObject cameraA;
    public GameObject cameraB;

    //private bool change;

    void Start()
    {
        //changeCamera = GetComponentInParent<ChangeCamera>();
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            cameraA.SetActive(false);
            cameraB.SetActive(true);
            sensor_a.SetActive(true);
            sensor_b.SetActive(false);
            Debug.Log("Œ©Ž¸‚¤");
        }
    }
}
