using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cameraA;
    public GameObject cameraB;

    private bool change = true;

    int i = 0;

    public void Test()
    {
        Debug.Log("test");
        Debug.Log(i);
        i = 10;
        Debug.Log(i);
        cameraA.SetActive(false);
        cameraB.SetActive(true);
    }
}
