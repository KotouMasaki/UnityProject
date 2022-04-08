using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    [SerializeField] private Image backImage;
    [SerializeField] private Text caught;
    [SerializeField] private Text days1;
    [SerializeField] private Text days2;
    [SerializeField] private Text days3;
    [SerializeField] private Text text1;
    [SerializeField] private Text text2;
    [SerializeField] private Text text3;
    [SerializeField] private Text text4;
    [SerializeField] private Text text5;
    [SerializeField] private Text text6;
    [SerializeField] private GameObject Map;
    [SerializeField] private GameObject blankMap1;
    [SerializeField] private GameObject blankMap2;
    [SerializeField] private GameObject floorMap01;
    [SerializeField] private GameObject floorMap02;
    [SerializeField] private Transform StartPos;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;
    [SerializeField] private AudioClip clip3;

    private new GameObject camera;
    private AudioSource audioSource;
    private GameObject player;
    private bool is_returned;
    private int MapCount;
    private int day;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
        Map.SetActive(false);
        blankMap1.SetActive(false);
        blankMap2.SetActive(false);
        is_returned = false;
        day = 3;
        StartCoroutine("Opening");
    }

    /// <summary>
    /// フェードアウト演出
    /// </summary>
    void BackFadeOut()
    {
        backImage.DOFade(1f, 0f);
    }

    /// <summary>
    /// フェードイン演出
    /// </summary>
    void BackFadeIn()
    {
        backImage.DOFade(0f, 2f);
    }

    /// <summary>
    /// アイテム入手時の演出
    /// </summary>
    /// <param name="num">switch文のための引数</param>
    void Text(int num)
    {
        audioSource.PlayOneShot(clip2);
        switch (num)
        {
            case 1:
                text1.DOFade(1f, 0f);
                text1.DOFade(0f, 5f);
                break;
            case 2:
                text2.DOFade(1f, 0f);
                text2.DOFade(0f, 5f);
                break;
            case 3:
                text3.DOFade(1f, 0f);
                text3.DOFade(0f, 5f);
                break;
            case 4:
                text4.DOFade(1f, 0f);
                text4.DOFade(0f, 5f);
                break;
            case 5:
                text5.DOFade(1f, 0f);
                text5.DOFade(0f, 5f);
                break;
            case 6:
                text6.DOFade(1f, 0f);
                text6.DOFade(0f, 5f);
                break;
        }
    }

    /// <summary>
    /// マップ表示、非表示の関数
    /// </summary>
    void Show_Map()
    {
        MapCount++;

        switch (MapCount)
        {
            case 1:
                Map.SetActive(true);
                break;
            case 2:
                Map.SetActive(false);
                MapCount = 0;
                break;
        }
    }

    /// <summary>
    /// マップを入手した時のフラグ
    /// </summary>
    void Flag_Map()
    {
        blankMap1.SetActive(true);
        blankMap2.SetActive(true);
    }

    /// <summary>
    /// 敵に捕まった時の演出
    /// </summary>
    void Get_caught()
    {
        if(!is_returned)
        {
            StartCoroutine("NextDay");
            is_returned = true;
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 捕まった時の演出が何回も呼ばれないようにする
    /// </summary>
    void Returned()
    {
        is_returned = false;
        return;
    }
    /// <summary>
    /// ゲーム開始時の演出のコルーチン関数
    /// </summary>
    /// <returns></returns>
    IEnumerator Opening()
    {
        audioSource.PlayOneShot(clip3);
        backImage.DOFade(1f, 0f);
        days3.DOFade(1f, 0f);
        yield return new WaitForSeconds(2);
        days3.DOFade(0f, 2f);
        BackFadeIn();
    }

    /// <summary>
    /// 捕まった時の演出のコルーチン関数
    /// </summary>
    /// <returns></returns>
    IEnumerator NextDay()
    {
        floorMap02.SetActive(false);
        audioSource.PlayOneShot(clip1);
        day--;
        Debug.Log(day);
        //if(day == 0) ChangeScene();
        backImage.DOFade(0.75f, 2f);
        caught.DOFade(1f, 2f);
        yield return new WaitForSeconds(5);
        audioSource.PlayOneShot(clip3);
        caught.DOFade(0f, 0f);
        backImage.DOFade(1f, 0f);
        switch(day)
        {
            case 2:
                days2.DOFade(1f, 0f);
                break;
            case 1:
                days1.DOFade(1f, 0f);
                break;
            case 0:
                SceneManager.LoadScene("GameOver");
                break;
        }
        yield return new WaitForSeconds(2);
        days2.DOFade(0f, 2f);
        days1.DOFade(0f, 2f);
        floorMap01.SetActive(true);
        camera.SendMessage("Reset_Pos");
        player.SendMessage("Warp", StartPos);
    }
}
