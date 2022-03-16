using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    
    void Update()
    {
        transform.Translate(0f, 0f, Speed);
    }
}
