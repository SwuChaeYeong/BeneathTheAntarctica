using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class MainSceneUIManager : Manager<MainSceneUIManager>
{
    [SerializeField] private GameObject characterSelectPanel;
    
    public void OpenCharacterSelect()
    {
        //SceneManager.LoadScene("Game");
        CharacterManager.Instance.Init();
        characterSelectPanel.transform.localScale = Vector3.zero;
        characterSelectPanel.gameObject.SetActive(true);
        characterSelectPanel.transform.DOScale(1, .2f);
    }

    public void CloseCharacterSelect()
    {
        characterSelectPanel.transform.DOScale(0, .2f).OnComplete(() =>
        {
            characterSelectPanel.gameObject.SetActive(false);
        });
    }
    
    public void OpenSetting()
    {
        
    }

    public void CloseSetting()
    {
        
    }

    public void OpenDeveloper()
    {
        
    }

    public void CloseDeveloper()
    {
        
    }
    
    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}
