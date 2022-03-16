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
        //Player�����̒n�_���z�����Boss��HP�\���ƈړ����J�n����
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

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnTriggerEnter(Collider collider)
    {
        // �_���[�W���͏����X�L�b�v
        if (isDamage)
        {
            return;
        }
        if (collider.gameObject.tag == "Laser")
        {
            isDamage = true;
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
