using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private bool GameScene;
    [SerializeField] private bool TitleScene;
    [SerializeField] private bool fadeIn;
    [SerializeField] private bool fadeOut;
    [SerializeField] private Image backImageA;
    [SerializeField] private GameObject backImageB;

    void Start()
    {
        if (fadeIn) StartCoroutine("FadeIn");
    }

    /// <summary>
    /// ��ʑJ�ڂ�����{�^���p�̊֐�
    /// </summary>
    public void OnClickChangeScene()
    {
        StartCoroutine("FadeOut");
    }

    /// <summary>
    /// �t�F�[�h�A�E�g���o
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut()
    {
        if (fadeOut)
        {
            backImageB.SetActive(true);
            backImageA.DOFade(1f, 2f);
        }

        yield return new WaitForSeconds(3);
        
        if (GameScene) SceneManager.LoadScene("GameScene");
        if (TitleScene) SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// �t�F�[�h�C�����o
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIn()
    {
        backImageA.DOFade(0f, 3f);

        yield return new WaitForSeconds(3);

        backImageB.SetActive(false);
    }
}
