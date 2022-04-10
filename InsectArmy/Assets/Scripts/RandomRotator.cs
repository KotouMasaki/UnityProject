using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    //隕石を回転させる
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}