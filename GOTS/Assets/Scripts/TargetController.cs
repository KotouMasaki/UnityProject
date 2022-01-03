using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float Speed;
    public float MaxX;
    public float MinX;
    public float MaxY;
    public float MinY;

    // 辞書型の変数を使う
    Dictionary<string, bool> move = new Dictionary<string, bool>
    {
        {"up", false },
        {"down", false },
        {"right", false },
        {"left", false },
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 1510)
        {
            transform.Translate(0f, 0f, Speed);
        }
        
        move["up"] = Input.GetKey(KeyCode.W);
        move["down"] = Input.GetKey(KeyCode.S);
        move["right"] = Input.GetKey(KeyCode.D);
        move["left"] = Input.GetKey(KeyCode.A);
    }

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