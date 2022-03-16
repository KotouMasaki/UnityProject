using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField]
    private int LaserSpeed;
    [SerializeField]
    private float LifeTime;
    [SerializeField]
    private float FastTime;
    [SerializeField]
    private float Interval;
    [SerializeField]
    private bool FastLaser;
    private float second1;
    private float second2;

    [SerializeField]
    private GameObject laser;

    void Update()
    {
        second1 = second1 + Time.deltaTime;
        if(second1 > FastTime)
        {
            if(FastLaser == true)
            {
                for(int i = 0; i < 50; i++)
                {
                    Laser();
                }
                FastLaser = false;
            }
            
            second2 = second2 + Time.deltaTime;
            if(second2 > Interval)
            {
                for(int j = 0; j < 50; j++)
                {
                    Laser();
                }
                second2 = 0;
            }
        }
    }

    void Laser()
    {
        GameObject Laser = Instantiate(laser, transform.position, Quaternion.identity);
        Rigidbody LaserRb = Laser.GetComponent<Rigidbody>();

        //LaserRbに力を加える
        LaserRb.AddForce(transform.forward * LaserSpeed);

        //LifeTimeで設定した秒数後Laserを削除
        Destroy(Laser, LifeTime);

    }
}
