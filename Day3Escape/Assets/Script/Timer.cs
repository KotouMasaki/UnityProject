using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float Limit_day1;
    [SerializeField] private float Limit_day2;
    [SerializeField] private float Limit_day3;

    private GameObject enemy_day1;
    private GameObject enemy_day2;
    private GameObject enemy_day3;
    int dayCount;

    void Start()
    {
        enemy_day1 = GameObject.Find("Day_1");
        enemy_day2 = GameObject.Find("Day_2");
        enemy_day3 = GameObject.Find("Day_3");
        //TimeLimit();
    }

    public void TimeLimit()
    {
        dayCount++;
        float time;

        switch(dayCount)
        {
            case 1:
                time = Limit_day1;
                while(time <= 0)
                {
                    time = time - Time.deltaTime;
                    Debug.Log(time);
                }
                break;
            case 2:
                time = Limit_day2;
                while (time <= 0)
                {
                    time = time - Time.deltaTime;
                    Debug.Log(time);
                }
                break;
            case 3:
                time = Limit_day3;
                while (time <= 0)
                {
                    time = time - Time.deltaTime;
                    Debug.Log(time);
                }
                break;
        }
    }
}
