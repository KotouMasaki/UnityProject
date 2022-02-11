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
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            //　主人公の方向
            var playerDirection = col.transform.position - transform.position;
            //　敵の前方からの主人公の方向
            var angle = Vector3.Angle(transform.forward, playerDirection);
            //　敵キャラクターの状態を取得
            EnemyMove.EnemyState state = enemyMove.GetState();

            //　サーチする角度内だったら発見
            if (angle <= searchAngle)
            {
                //　敵キャラクターが追いかける状態でなければ追いかける設定に変更
                if (state != EnemyMove.EnemyState.Chase)
                {
                    Debug.Log("主人公を発見2");
                    enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
                }
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("見失う");
            enemyMove.SetState(EnemyMove.EnemyState.Walk);
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
