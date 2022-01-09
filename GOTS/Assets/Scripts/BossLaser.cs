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
        //Debug.Log(second1);
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
            //Debug.Log(second2);
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
            Debug.Log("ƒŒ[ƒU[”­Ë");
            GameObject Laser = Instantiate(laser, transform.position, Quaternion.identity);
            Rigidbody LaserRb = Laser.GetComponent<Rigidbody>();

            // ’e‘¬‚Í©—R‚Éİ’è
            LaserRb.AddForce(transform.forward * LaserSpeed);

            // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
            Destroy(Laser, LifeTime);

    }
}
