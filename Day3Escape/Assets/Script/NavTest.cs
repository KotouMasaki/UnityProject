using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        agent.autoBraking = false;
        animator.SetBool("Speed", true);

        GotoNextPoint();
    }


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


    void Update()
    {
        // エージェントが現目標地点に近づいてきたら、
        // 次の目標地点を選択します
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}
