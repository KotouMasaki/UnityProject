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
            //　主人公の方向
            var playerDirection = other.transform.position - transform.position;
            //　敵の前方からの主人公の方向
            var angle = Vector3.Angle(transform.forward, playerDirection);
            //　サーチする角度内だったら発見
            if (angle <= searchAngle)
            {
                Debug.Log("主人公発見: " + angle);
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
    //　サーチする角度表示
    private void OnDrawGizmos() {
        Handles.color = Color.red;
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
#endif
}
