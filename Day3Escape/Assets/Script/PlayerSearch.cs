using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField]
    private EnemyMove enemyMove;
    [SerializeField]
    private LayerMask obstacleLayer;

    void Start()
    {
        enemyMove = GetComponentInParent<EnemyMove>();
    }

    void OnTriggerStay(Collider col)
    {
        //�@�v���C���[�L�����N�^�[�𔭌�
        if (col.tag == "Player")
        {
            //�@�G�L�����N�^�[�̏�Ԃ��擾
            EnemyMove.EnemyState state = enemyMove.GetState();

            Debug.DrawLine(transform.position + Vector3.up, col.transform.position + Vector3.up, Color.blue);

            //�@�T�[�`����p�x���������甭��
            if ((state == EnemyMove.EnemyState.Walk)
                && !Physics.Linecast(transform.position + Vector3.up, col.transform.position + Vector3.up, obstacleLayer))
            {
                Debug.Log("��l���𔭌�");
                enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
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
}
