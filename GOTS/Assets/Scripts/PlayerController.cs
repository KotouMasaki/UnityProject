using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxHp;
    [SerializeField]
    private float currentHp;
    [SerializeField]
    private float speed;
    private int count;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform targetPos;

    private Rigidbody rb;
    private Vector3 pos;
    
    void Start()
    {
        slider.value = 0.5f;
        transform.LookAt(target.transform);
        target = GameObject.Find("Target");
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        count += 1;

        //Targetを向き続ける
        transform.LookAt(target.transform);
        
        transform.Translate(0f, 0f, 0.5f);

        //Targetに一定距離保ってついていく
        Vector3 diff = this.transform.position - targetPos.transform.position;
        if (diff.magnitude > 10.0f)
        {
            Quaternion sphereQuate = Quaternion.LookRotation(targetPos.transform.position - this.transform.position, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, sphereQuate, 0.1f);
            rb.velocity = this.transform.forward * speed;
        }

        if (count % 30 == 0)
        {
            currentHp = currentHp - 1;
            slider.value = (float)currentHp / (float)maxHp;
        }
    }

    //敵を倒すと呼ばれる関数
    public void AddHP()
    {
        currentHp = currentHp + 5;
        slider.value = (float)currentHp / (float)maxHp;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            int damage = 5;

            //敵に当たるたびに体力を５づつ減らす
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHp;
        }

        if (currentHp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}