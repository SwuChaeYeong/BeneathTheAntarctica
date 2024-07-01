using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ServerProgress {
    None = 0,
    Login = 1,
    LoadStageData,
    LoadPlayerData,
    LoadSkinData,
    Complete
}

/// <summary>
/// DataManager는 로딩화면에서 가장 처음으로 실행되는 매니저입니다.
/// DataManager에서 로컬 or 스팀 클라우드에 저장된 플레이어의 모든 데이터를 가져오는 역할을 합니다.
/// DataManager에서 모든 데이터를 불러오는 동안 Loading에서는 그 수치를 N%로 표기할 것이고
/// 모든 데이터가 로드되면 로비 씬으로 자연스럽게 넘어갑니다.
/// 사실상 이 DataManager는 게임 내 모든 데이터를 가지고 있고,
/// 로딩부터 시작해서 게임의 모든 씬에 관여하므로 싱글톤으로 구현됩니다.
/// </summary>
public class DataManager : Singleton<DataManager>
{
    public CharacterDataVO[] playerDataVo;
    public UserDataVO UserDataVo;
    
    private void Start()
    {
        playerDataVo = new CharacterDataVO[3];
        
        LoadUserData();


        gameObject.GetComponent<GameData>().Init();
    }
    
    public TextMeshProUGUI progressText;
    private ServerProgress progress;
    
    [SerializeField] private string GET_PLAYER_DATA = "";
    [SerializeField] private string COMPLETE = "";
    
    public void LoadingText(ServerProgress progress)
    {
        this.progress = progress;
        switch (this.progress)
        {
            case ServerProgress.None:
                break;
            case ServerProgress.LoadPlayerData:
                progressText.text = GET_PLAYER_DATA;
                break;
            case ServerProgress.Complete:
                progressText.text = COMPLETE;
                break;
        }
    }
    
    public void LoadUserData()
    {
        //UserDataVo = JsonDataManager.LoadJsonData<UserDataVO>("UserData", "UserData", 0);
        LoadCharacterData();
    }

    public void LoadCharacterData()
    {
        LoadingText(ServerProgress.LoadPlayerData);
        /*for (int i = 0; i < 3; i++)
        {
            playerDataVo[i] = JsonDataManager.LoadJsonData<CharacterDataVO>("UserData", "CharacterData", i);
        }*/
        CompleteLoad();
    }
    
    public void CompleteLoad()
    {
        LoadingText(ServerProgress.Complete);
        StartCoroutine(SceneChange());
        Debug.Log("로딩끝");
    }
    
    private IEnumerator SceneChange()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");
        asyncOperation.allowSceneActivation = false;
        
        while ( true ) {
            if (asyncOperation.progress >= 0.9f) {
                asyncOperation.allowSceneActivation = true;
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
