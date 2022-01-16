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
    //Slider������
    public Slider slider;
    public GameObject target;
    public Transform targetPos;
    private int count;

    void Start()
    {
        //Slider�𔼕��ɂ���B
        slider.value = 0.5f;
        transform.LookAt(target.transform);
        target = GameObject.Find("Target");
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        count += 1;

        //�W���̓����ɍ��킹�ČX����
        transform.LookAt(target.transform);
        
        transform.Translate(0f, 0f, 0.5f);

        //�W���ɊԊu�������Ă��Ă���
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

    //�G�ƒe�̏Փˎ���EnemyController����Ă΂��
    public void AddHP()
    {
        currentHp = currentHp + 5;
        slider.value = (float)currentHp / (float)maxHp;
    }

    //Collider�I�u�W�F�N�g��IsTrigger�Ƀ`�F�b�N����邱�ƁB
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            int damage = 5;

            //���݂�HP����_���[�W������
            currentHp = currentHp - damage;

            //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
            //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            slider.value = (float)currentHp / (float)maxHp;
        }

        if (currentHp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}