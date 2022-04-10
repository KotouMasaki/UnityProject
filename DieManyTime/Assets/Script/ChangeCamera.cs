using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;
    [SerializeField] private GameObject Map3;

    private GameObject playCamera;
    private GameObject SceneDirector;

    void Start()
    {
        playCamera = GameObject.Find("Camera");
        SceneDirector = GameObject.Find("SceneDirector");
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            //カメラの位置を変える
            playCamera.transform.position = cameraPos.position;
            if (Map1 == null && Map2 == null && Map3 == null)
            {
                return;
            }
            else
            {
                //マップの表示を変更する
                Map1.SetActive(true);
                Map2.SetActive(true);
                Map3.SetActive(false);
                SceneDirector.SendMessage("Get_Object",Map2);
            }
        }
    }
}
