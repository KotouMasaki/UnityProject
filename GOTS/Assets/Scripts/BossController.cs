using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float Speed;
    public float maxHp = 100.0f;
    public float currentHp;
    public Slider slider;
    public GameObject HPBar;
    public Transform player;
    private int count;
    private bool HP;
    private bool isDamage;

    void Start()
    {
        HPBar.SetActive(false);
        HP = false;
        isDamage = false;
    }

    void Update()
    {
        count++;
        if(player.position.z >= 1500)
        {
            HPBar.SetActive(true);
            if(HP == false & count % 30 == 0)
            {
                slider.value += 0.05f;
                currentHp = maxHp;
                if(slider.value == 1)
                {
                    HP = true;
                }
            }
            transform.Translate(0f, 0f, Speed);
        }
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnTriggerEnter(Collider collider)
    {
        // ダメージ中は処理スキップ
        if (isDamage)
        {
            Debug.Log("当たってないよ");
            return;
        }
        if (collider.gameObject.tag == "Laser")
        {
            isDamage = true;
            Debug.Log("命中！！");
            int damage = 5;

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;

            StartCoroutine(OnDamage());
        }
        if (currentHp <= 0)
        {
            SceneManager.LoadScene("ClearScene");

        }
    }

    public IEnumerator OnDamage()
    {

        yield return new WaitForSeconds(0.5f);

        // 通常状態に戻す
        isDamage = false;
    }
}
