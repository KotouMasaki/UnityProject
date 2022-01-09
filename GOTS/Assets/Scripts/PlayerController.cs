using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    private Vector3 pos;
    public GameObject target;
    public Transform targetPos;

    void Start()
    {
        transform.LookAt(target.transform);
        target = GameObject.Find("Target");
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(target.transform);
        
        transform.Translate(0f, 0f, 0.125f);

        Vector3 diff = this.transform.position - targetPos.transform.position;
        if (diff.magnitude > 10.0f)
        {
            Quaternion sphereQuate = Quaternion.LookRotation(targetPos.transform.position - this.transform.position, Vector3.up);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, sphereQuate, 0.1f);
            rb.velocity = this.transform.forward * speed;
        }

        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}