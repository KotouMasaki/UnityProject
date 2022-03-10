using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public int LaserSpeed;
    public float LifeTime;
    public float FastTime;
    public float Interval;
    private float second1;
    private float second2;
    public GameObject laser;
    public bool FastLaser = true;

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
                    //laser.SetActive(true);
                }
                FastLaser = false;
                //laser.SetActive(false);
            }
            
            second2 = second2 + Time.deltaTime;
            if(second2 > Interval)
            {
                for(int j = 0; j < 50; j++)
                {
                    Laser();
                    //laser.SetActive(true);
                }
                second2 = 0;
                //laser.SetActive(false);
            }
        }
    }

    void Laser()
    {
            GameObject Laser = Instantiate(laser, transform.position, Quaternion.identity);
            Rigidbody LaserRb = Laser.GetComponent<Rigidbody>();

            // �e���͎��R�ɐݒ�
            LaserRb.AddForce(transform.forward * LaserSpeed);

            // �T�b��ɖC�e��j�󂷂�
            Destroy(Laser, LifeTime);

    }
}
