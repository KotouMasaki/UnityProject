using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float MaxX;
    [SerializeField]
    private float MinX;
    [SerializeField]
    private float MaxY;
    [SerializeField]
    private float MinY;

    // 辞書型の変数を使う
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up", false },
        {"down", false },
        {"right", false },
        {"left", false },
    };

    void Update()
    {
        transform.Translate(0f, 0f, Speed);
        
        move["up"] = Input.GetKey(KeyCode.W);
        move["down"] = Input.GetKey(KeyCode.S);
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);
    }

    //移動制限をつけて画面から出ないようにする
    void FixedUpdate()
    {

        if (move["up"] & transform.position.y < MaxY)
        {
            transform.position += new Vector3(0, 0.5f, 0);
        }
        if (move["down"] & transform.position.y > MinY)
        {
            transform.position -= new Vector3(0, 0.5f, 0);
        }
        if (move["right"] & transform.position.x < MaxX)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
        if (move["left"] & transform.position.x > MinX)
        {
            transform.position -= new Vector3(0.5f, 0, 0);
        }
    }
}