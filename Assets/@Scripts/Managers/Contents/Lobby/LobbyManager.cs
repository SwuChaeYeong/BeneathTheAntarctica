using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    #region Scene

    public void LoadScene()
    {
        StartCoroutine(SceneChange());
    }
    
    private IEnumerator SceneChange()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game");
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

    #endregion
    
}
