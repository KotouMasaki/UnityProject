using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public Transform player;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float chaseSpeed;

    private int destPoint;
    private bool find;
    private EnemyState state;   // 敵の状態
    private NavMeshAgent agent;
    private Animator animator;

    public enum EnemyState
    {
        Walk,
        Chase
    };

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        agent.autoBraking = false;
        destPoint = 0;
        SetState(EnemyState.Walk);
        GotoNextPoint();
    }

    /// <summary>
    /// 次の目標地点をセットする
    /// </summary>
    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
        {
            return;
        }


        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
    }

    /// <summary>
    /// 敵の状態を設定する
    /// </summary>
    /// <param name="tempState">変更したい敵の状態</param>
    /// <param name="targetObj">目標物</param>
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if(tempState == EnemyState.Walk)
        {
            find = false;
            animator.SetBool("Speed", false);
            agent.speed = walkSpeed;
            GotoNextPoint();
        }else if(tempState == EnemyState.Chase)
        {
            find = true;
            animator.SetBool("Speed", true);
            agent.speed = chaseSpeed;
            agent.destination = player.position;
        }
    }

    //　敵キャラクターの状態取得メソッド
    public EnemyState GetState()
    {
        return state;
    }

    void Update()
    {
        if(!find)
        {
            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
    }
}
