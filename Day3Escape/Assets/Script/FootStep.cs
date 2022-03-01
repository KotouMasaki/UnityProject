using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField]
    private float deleteTime;

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }
}
