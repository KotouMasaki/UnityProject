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

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnTriggerEnter(Collider collider)
    {
        // �_���[�W���͏����X�L�b�v
        if (isDamage)
        {
            Debug.Log("�������ĂȂ���");
            return;
        }
        if (collider.gameObject.tag == "Laser")
        {
            isDamage = true;
            Debug.Log("�����I�I");
            int damage = 5;

            //���݂�HP����_���[�W������
            currentHp = currentHp - damage;

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
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

        // �ʏ��Ԃɖ߂�
        isDamage = false;
    }
}
