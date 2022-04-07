using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private bool GameScene;
    [SerializeField] private bool TitleScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickChangeScene()
    {
        if(GameScene)
        {
            SceneManager.LoadScene("GameScene");
        }
        if(TitleScene)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
