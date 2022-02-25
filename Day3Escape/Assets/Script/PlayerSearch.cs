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
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            //　敵キャラクターの状態を取得
            EnemyMove.EnemyState state = enemyMove.GetState();

            Debug.DrawLine(transform.position + Vector3.up, col.transform.position + Vector3.up, Color.blue);

            //　サーチする角度内だったら発見
            if ((state == EnemyMove.EnemyState.Walk)
                && !Physics.Linecast(transform.position + Vector3.up, col.transform.position + Vector3.up, obstacleLayer))
            {
                Debug.Log("主人公を発見");
                enemyMove.SetState(EnemyMove.EnemyState.Chase, col.transform);
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
}
