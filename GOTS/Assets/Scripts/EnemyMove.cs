using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float second;
    public float wateTime1 = 1.5f;
    public float wateTime2 = 3.0f;
    public float wateTime3 = 4.5f;
    public float wateTime4 = 6.0f;
    public float deleteTime = 30;

    // Update is called once per frame
    void Update()
    {
        second = second + Time.deltaTime;
        if (second < wateTime1)
        {
            transform.Translate(0.12f, 0f, -0.05f);
        }
        if (wateTime1 < second & second < wateTime2)
        {
            transform.Translate(-0.12f, 0f, -0.05f);
        }
        if (wateTime2 < second)
        {
            second = 0;
        }
    }
}