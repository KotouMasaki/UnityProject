using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public float lifetime = 5.0f;
    private Vector3 velocity;
    private Vector3 EnemyPos;
    private Transform target;
    private float period = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifetime);
        target = GameObject.Find("Player").transform;
        EnemyPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var acceleration = Vector3.zero;

        var diff = target.position - EnemyPos;
        acceleration += (diff - velocity * period) * 2f
                    / (period * period);
        period -= Time.deltaTime;
        if (period < 0f)
        {
            return;
        }
        if (acceleration.magnitude > 100f)
        {
            acceleration = acceleration.normalized * 100f;
        }

        velocity += acceleration * Time.deltaTime;
        EnemyPos += velocity * Time.deltaTime;
        this.transform.position = EnemyPos;
    }
}