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

    //�e������������Player��HP�̉񕜂�Enemy�̍폜
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Laser")
        {
            PlayerObj.GetComponent<PlayerController>().AddHP();
            Destroy(gameObject);
        }
    }
}
