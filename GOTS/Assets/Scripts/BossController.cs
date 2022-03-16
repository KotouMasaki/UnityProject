using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float maxHp;
    [SerializeField]
    private float currentHp;
    private int count;
    private bool HP;
    private bool isDamage;

    [SerializeField]
    private Slider slider;
    [SerializeField]
    private GameObject HPBar;
    [SerializeField]
    private Transform player;
    
    void Start()
    {
        HPBar.SetActive(false);
        HP = false;
        isDamage = false;
        slider.value = 0;
    }

    void Update()
    {
        //Playerが一定の地点を越えるとBossのHP表示と移動を開始する
        if(player.position.z >= 1500)
        {
            count++;
            HPBar.SetActive(true);
            if(HP == false & count % 90 == 0)
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
            return;
        }
        if (collider.gameObject.tag == "Laser")
        {
            isDamage = true;
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
