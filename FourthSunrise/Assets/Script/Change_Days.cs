using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Days : MonoBehaviour
{
    private GameObject score_object; // Text�I�u�W�F�N�g

    void Start()
    {
        score_object = GameObject.Find("re_days");
    }
    void Rewrite(int days)
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = score_object.GetComponent<Text>();
        // �e�L�X�g�̕\�������ւ���
        score_text.text = "����" + days + "��";
    }
}
