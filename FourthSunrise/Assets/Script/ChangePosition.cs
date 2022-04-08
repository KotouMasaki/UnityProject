using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    
    [SerializeField] private Transform cameraPos;
    [SerializeField] private Transform changePos;
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;
    [SerializeField] private GameObject Map3;
    [SerializeField] private GameObject Map4;
    [SerializeField] private GameObject Map5;
    [SerializeField] private AudioClip clip1;

    private GameObject player;
    private GameObject playCamera;
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player");
        playCamera = GameObject.Find("Camera");
        audioSource = GetComponent<AudioSource>();

    }
    /// <summary>
    /// Playerの場所を変える時にマップを更新する関数
    /// </summary>
    void ChangePosPlayer()
    {
        audioSource.PlayOneShot(clip1);
        playCamera.transform.position = cameraPos.position;
        player.SendMessage("Warp", changePos);
        Map3.SetActive(false);
        Map1.SetActive(true);
        Map2.SetActive(true);
        
        if(Map4 == null && Map5 == null)
        {
            return;
        }
        else
        {
            Map4.SetActive(true);
            Map5.SetActive(false);
        }
    }
}
