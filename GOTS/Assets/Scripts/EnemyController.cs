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

    //’e‚ª“–‚½‚Á‚½Player‚ÌHP‚Ì‰ñ•œ‚ÆEnemy‚Ìíœ
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Laser")
        {
            PlayerObj.GetComponent<PlayerController>().AddHP();
            Destroy(gameObject);
        }
    }
}
