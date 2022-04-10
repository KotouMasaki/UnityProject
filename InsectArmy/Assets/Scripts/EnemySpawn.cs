using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private float FastTime;
    [SerializeField]
    private float Interval;
    private float second1;
    private float second2;
    [SerializeField]
    private bool FastSpawn;

    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject firingPoint;
    

    void Start()
    {
        transform.LookAt(player.transform);
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.LookAt(player.transform);

        second1 = second1 + Time.deltaTime;
        if (second1 > FastTime)
        {
            if(FastSpawn == true)
            {
                Spawn();
                FastSpawn = false;
            }

            second2 = second2 + Time.deltaTime;
            if (second2 > Interval)
            {
                Spawn();
                second2 = 0;
            }
        }
    }

    public void Spawn()
    {
        //“G‚ğ¶¬‚·‚éêŠ‚ğæ“¾
        Vector3 laserPosition = firingPoint.transform.position;
        GameObject Enemys = Instantiate(Enemy, this.transform.position, this.transform.rotation);
    }
}
