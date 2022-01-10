using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    void Start()
    {
        //オブジェクトの色を赤に変更する
        GetComponent<Renderer>().material.color = Color.green;
    }
}
