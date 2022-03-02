using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cameraA;
    public GameObject cameraB;

    private bool change = true;

    void OnTriggerEnter(Collider col)
    {
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            Debug.Log("入った");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log(change);
            Test();
        }
    }

    void Test()
    {
        Debug.Log("test");
        if (change)
        {
            cameraA.SetActive(false);
            cameraB.SetActive(true);
            change = false;
        }
        if (!change)
        {
            cameraA.SetActive(true);
            cameraB.SetActive(false);
            change = true;
        }
    }
}
