using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform[] points;
    public Transform player;
    public float walkSpeed;
    public float chaseSpeed;
    private int destPoint = 0;
    private bool find;
    // 敵の状態
    private EnemyState state;
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
        //animator.SetBool("Speed", true);
        SetState(EnemyState.Walk);
        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        Debug.Log("次の目標へ");
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

    void Warp(Transform transform)
    {
        //　Enemyの位置を変更する
        this.transform.position = transform.position;
        Debug.Log("Warp!");
    }
}
