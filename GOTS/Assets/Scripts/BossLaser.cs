using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public int LaserSpeed;
    public float LifeTime;
    public GameObject laser;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject Laser = Instantiate(laser, transform.position, Quaternion.identity);
            Rigidbody LaserRb = Laser.GetComponent<Rigidbody>();

            // ’e‘¬‚Í©—R‚Éİ’è
            LaserRb.AddForce(transform.forward * LaserSpeed);

            // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
            Destroy(Laser, LifeTime);
        }
    }
}
