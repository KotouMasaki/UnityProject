using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class test : MonoBehaviour
{
    public GameObject cameraA;
    public GameObject cameraB;

    private bool change;

    void OnTriggerEnter(Collider col)
    {
        //�@�v���C���[�L�����N�^�[�𔭌�
        if (col.tag == "Player")
        {
            Debug.Log("������");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("������");
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
}
