using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxHp = 90.0f;
    [SerializeField] float currentHp;
    public float speed = 10.0f;
    private Rigidbody rb;
    private Vector3 pos;
    //Sliderを入れる
    public Slider slider;
    public GameObject target;
    public Transform targetPos;
    private int count;

    void Start()
    {
        //Sliderを半分にする。
        slider.value = 0.5f;
        transform.LookAt(target.transform);
        target = GameObject.Find("Target");
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        count += 1;

        //標準の動きに合わせて傾ける
        transform.LookAt(target.transform);
        
        transform.Translate(0f, 0f, 0.125f);

        //標準に間隔をあけてついていく
        Vector3 diff = this.transform.position - targetPos.transform.position;
        if (diff.magnitude > 10.0f)
        {
            Quaternion sphereQuate = Quaternion.LookRotation(targetPos.transform.position - this.transform.position, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, sphereQuate, 0.1f);
            rb.velocity = this.transform.forward * speed;
        }

        if (count % 120 == 0)
        {
            currentHp = currentHp - 1;
            slider.value = (float)currentHp / (float)maxHp;
        }
    }

    //敵と弾の衝突時にEnemyControllerから呼ばれる
    public void AddHP()
    {
        currentHp = currentHp + 5;
        slider.value = (float)currentHp / (float)maxHp;
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            int damage = 5;

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
        }

        if (currentHp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}