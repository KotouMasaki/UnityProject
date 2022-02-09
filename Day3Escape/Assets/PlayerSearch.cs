using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSearch : MonoBehaviour
{
    //[SerializeField]
    //private OnlyForwardSearchEnemy onlyForwardSearchEnemy;
    [SerializeField]
    private SphereCollider searchArea;
    [SerializeField]
    private float searchAngle = 130f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //�@��l���̕���
            var playerDirection = other.transform.position - transform.position;
            //�@�G�̑O������̎�l���̕���
            var angle = Vector3.Angle(transform.forward, playerDirection);
            //�@�T�[�`����p�x���������甭��
            if (angle <= searchAngle)
            {
                Debug.Log("��l������: " + angle);
                //onlyForwardSearchEnemy.SetState(OnlyForwardSearchEnemy.EnemyState.Chase, other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //onlyForwardSearchEnemy.SetState(OnlyForwardSearchEnemy.EnemyState.Wait);
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
