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

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Laser")
        {
            PlayerObj.GetComponent<PlayerHP>().AddHP();
            Destroy(gameObject);
        }
    }
}
