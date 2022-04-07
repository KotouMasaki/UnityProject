using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;
    [SerializeField] private GameObject Map3;
    //[SerializeField] private int Map_numA;
    //[SerializeField] private int Map_numB;
    //[SerializeField] private int Map_numC;

    private GameObject playCamera;
    //private GameObject ui_Director;

    void Start()
    {
        playCamera = GameObject.Find("Camera");
        //ui_Director = GameObject.Find("UI_Director");
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            playCamera.transform.position = cameraPos.position;
            if (Map1 == null && Map2 == null && Map3 == null)
            {
                return;
            }
            else
            {
                //ui_Director.SendMessage("Flag_Map", Map_numA);
                //ui_Director.SendMessage("Flag_Map", Map_numB);
                //ui_Director.SendMessage("Flag_Map", Map_numC);
                Map1.SetActive(true);
                Map2.SetActive(true);
                Map3.SetActive(false);
            }
        }
    }
}
