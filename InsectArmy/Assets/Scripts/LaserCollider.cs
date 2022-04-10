using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
