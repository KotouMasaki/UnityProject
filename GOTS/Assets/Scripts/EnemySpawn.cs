using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float Interval = 10.0f;
    public GameObject Enemy;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Interval);
        GameObject Enemys = Instantiate(Enemy, this.transform.position,this.transform.rotation);
        
    }
}
