using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] float maxHp = 90.0f;
    [SerializeField] float currentHp;
    //Sliderを入れる
    public Slider slider;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 0.5f;
        
        Debug.Log("Start currentHp : " + currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;

        if(count % 90 == 0)
        {
            currentHp = currentHp - 1;
            Debug.Log("After currentHp : " + currentHp);
            slider.value = (float)currentHp / (float)maxHp;
        }
    }

    public void AddHP()
    {
        currentHp = currentHp + 5;
        Debug.Log("After currentHp : " + currentHp);
        slider.value = (float)currentHp / (float)maxHp;
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            int damage = 5;
            Debug.Log("damage : " + damage);

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            Debug.Log("After currentHp : " + currentHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
            Debug.Log("slider.value : " + slider.value);
        }

        if(currentHp <= 0)
        {
            Debug.Log("HPO");
        }
    }
}