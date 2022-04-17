using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject PlayerObj;

    void Start()
    {
        PlayerObj = GameObject.Find("Player");
    }

    //弾が当たった時PlayerのHPの回復とEnemyの削除
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerObj.GetComponent<PlayerController>().AddHP();
            Destroy(gameObject);
        }
    }
}
