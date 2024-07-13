using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonDataManager
{
    public static T LoadJsonData<T>(string dataType, string folderName, int index)
    {
        T DATA;

        string Path = Application.persistentDataPath + "/" + folderName + "/" + index + ".json";
        string Resources_Path = "Data/" + dataType + "/" + folderName + "/" + index;
        
        if (File.Exists(Path)) // 해당 경로에 폴더가 있다면
        {
            string jsonData = File.ReadAllText(Path);
            DATA = JsonUtility.FromJson<T>(jsonData);
        }
        else // 해당 경로에 파일이 없다면 VO 값을 초기화하고 Json 파일을 생성함
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + folderName + "/");
            TextAsset Data_Asset = Resources.Load<TextAsset>(Resources_Path);
            var Data_Tmp = Data_Asset.ToString();
            File.WriteAllText(Path, Data_Tmp);
            DATA = JsonUtility.FromJson<T>(Data_Tmp);
        }
        return DATA;
    }

    // public static void SaveJsonStageData(string folderName, StageVO stageVo, int clearedStage)
    // {
    //     clearedStage += 1;
    //     string path = Application.persistentDataPath + "/" + folderName + "/" + clearedStage + ".json";
    //     string jsonData = JsonUtility.ToJson(stageVo, true);
    //     File.WriteAllText(path, jsonData);
    // }

    // public static void SaveJsonPlayerData(string dataType, string folderName, PlayerDataVO playerDataVo)
    // {
    //     string path = Application.persistentDataPath + "/" + folderName + "/0.json";
    //     string jsonData = JsonUtility.ToJson(playerDataVo, true);
    //     File.WriteAllText(path, jsonData);
    // }
    
    // public static void SaveJsonSkinData<T>(string dataType, string folderName, int num, T playerDataVo)
    // {
    //     string path = Application.persistentDataPath + "/" + folderName + "/" + num + ".json";
    //     string jsonData = JsonUtility.ToJson(playerDataVo, true);
    //     File.WriteAllText(path, jsonData);
    // }
}