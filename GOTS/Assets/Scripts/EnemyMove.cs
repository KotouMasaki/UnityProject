using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float second;
    [SerializeField]
    private float wateTime1;
    [SerializeField]
    private float wateTime2;
    [SerializeField]
    private float wateTime3;
    [SerializeField]
    private float wateTime4;
    [SerializeField]
    private float deleteTime;

    //ç∂âEÇ…à⁄ìÆÇ∑ÇÈ
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