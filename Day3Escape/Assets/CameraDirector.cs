using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirector : MonoBehaviour
{
    public Transform player;
    public GameObject camera1;
    public GameObject camera2;
    public float distance;
    private bool passing;

    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        passing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = this.transform.position - player.transform.position;
        if(diff.magnitude < distance)
        {
            if (passing) passing = false;
            if (!passing) passing = true;
        }
        if(!passing)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        if(passing)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            
        }
    }
}
