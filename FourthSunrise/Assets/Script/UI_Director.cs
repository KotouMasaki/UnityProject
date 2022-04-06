using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Director : MonoBehaviour
{
    [SerializeField] Image backImage;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject text5;
    [SerializeField] GameObject text6;

    void Start()
    {
        BackFadeIn();
    }
    
    public void BackFadeIn()
    {
        backImage.DOFade(0f, 2f);
    }

    public void BackFadeOut()
    {
        backImage.DOFade(1f, 2f);
    }

    void Text(int num)
    {
        switch(num)
        {
            case 1:
                text1.SetActive(true);
                break;
            case 2:
                text2.SetActive(true);
                break;
            case 3:
                text3.SetActive(true);
                break;
            case 4:
                text4.SetActive(true);
                break;
            case 5:
                text5.SetActive(true);
                break;
            case 6:
                text6.SetActive(true);
                break;
        }
    }
}
