using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Transform startPos;

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
            //Debug.Log(transform.position - col.transform.position);
            //�@�T�[�`����p�x���������甭��
            if ((state == EnemyMove.EnemyState.Walk)
                && !Physics.Linecast(transform.position + Vector3.up, col.transform.position + Vector3.up, obstacleLayer))
            {
                //Debug.Log("��l���𔭌�");
                enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
            }
            Vector3 diff = transform.position - col.transform.position;
            Debug.Log(diff.magnitude);
            if (diff.magnitude <= 1.5)
            {

                col.gameObject.SendMessage("Get_caught", startPos);
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
