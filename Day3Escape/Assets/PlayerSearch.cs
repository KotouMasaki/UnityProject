using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField]
    private EnemyMove enemyMove;
    [SerializeField]
    private SphereCollider searchArea;
    [SerializeField]
    private float searchAngle = 130f;

    void Start()
    {
        enemyMove = GetComponentInParent<EnemyMove>();
    }

    void OnTriggerStay(Collider col)
    {
        //�@�v���C���[�L�����N�^�[�𔭌�
        if (col.tag == "Player")
        {
            //�@��l���̕���
            var playerDirection = col.transform.position - transform.position;
            //�@�G�̑O������̎�l���̕���
            var angle = Vector3.Angle(transform.forward, playerDirection);
            //�@�G�L�����N�^�[�̏�Ԃ��擾
            EnemyMove.EnemyState state = enemyMove.GetState();

            //�@�T�[�`����p�x���������甭��
            if (angle <= searchAngle)
            {
                //�@�G�L�����N�^�[���ǂ��������ԂłȂ���Βǂ�������ݒ�ɕύX
                if (state != EnemyMove.EnemyState.Chase)
                {
                    Debug.Log("��l���𔭌�2");
                    enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("������");
            enemyMove.SetState(EnemyMove.EnemyState.Walk);
        }
    }

#if UNITY_EDITOR
    //�@�T�[�`����p�x�\��
    private void OnDrawGizmos() {
        Handles.color = Color.red;
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
#endif
}
