using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject SliderObj;

    // Start is called before the first frame update
    void Start()
    {
        SliderObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Laser")
        {
            SliderObj.GetComponent<PlayerHPBar>().AddHP();
            Destroy(gameObject);
        }
    }
}
