using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    [SerializeField] private bool UI_display;
    [SerializeField] private bool UI_hide;
    [SerializeField] private bool quitGame;
    [SerializeField] private GameObject UI_image;

    /// <summary>
    /// �{�^�����������Ƃ��̌Ă΂��֐�
    /// </summary>
    public void OnClick()
    {
        if(UI_display)
        {
            UI_image.SetActive(true);
        }
        if(UI_hide)
        {
            UI_image.SetActive(false);
        }
        if(quitGame)
        {

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
