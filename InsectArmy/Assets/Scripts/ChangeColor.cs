using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    void Start()
    {
        //�I�u�W�F�N�g�̐F��ԂɕύX����
        GetComponent<Renderer>().material.color = Color.green;
    }
}
