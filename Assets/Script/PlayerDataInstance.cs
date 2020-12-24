using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[Serializable]
public class PlayerDataInstance : ISerializationCallbackReceiver
{
    private static PlayerDataInstance _instance = null;
    public static PlayerDataInstance Instance
    {
        get
        {
            if (_instance == null)
            {
                Load();
            }
            return _instance;
        }
    }

    [SerializeField]
    private static string _jsonText = "";

    //保存されるデータ

    [SerializeField]
    private string _partsDictJson = "";
    public Dictionary<string, bool> PartsDict = new Dictionary<string, bool>();

    //シリアライズ・デシリアライズ時のコールバック
    public void OnBeforeSerialize()
    {
        //Debug.Log("OnBeforeSerialize");
        //辞書型はここでシリアライズする
        _partsDictJson = Serialize(PartsDict);
    }

    public void OnAfterDeserialize()
    {
        //Debug.Log("OnAfterDeserialize");
        //もしシリアライズされていた辞書型があればでシリアライズしておく
        if (!string.IsNullOrEmpty(_partsDictJson))
        {
            PartsDict = Deserialize<Dictionary<string, bool>>(_partsDictJson);
        }
    }

    private static string Serialize<T>(T obj)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        binaryFormatter.Serialize(memoryStream, obj);
        return Convert.ToBase64String(memoryStream.GetBuffer());
    }

    private static T Deserialize<T>(string str)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(str));
        return (T)binaryFormatter.Deserialize(memoryStream);
    }

    public void Reload()
    {
        JsonUtility.FromJsonOverwrite(GetJson(), this);
    }

    private static void Load()
    {
        _instance = JsonUtility.FromJson<PlayerDataInstance>(GetJson());
    }

    private static string GetJson()
    {
        if (!string.IsNullOrEmpty(_jsonText))
        {
            return _jsonText;
        }

        //Jsonを保存しているファイルのパスを取得する
        string filepath = GetSaveFilePath();

        //Jsonが存在するかどうかを調べて、そんざいしなければ新しいクラスを作成し、Jsonに変換する
        if (File.Exists(filepath))
        {
            Debug.Log(filepath);
            _jsonText = File.ReadAllText(filepath);
        }
        else
        {
            Debug.Log("No search path");
            _jsonText = JsonUtility.ToJson(new PlayerDataInstance());
        }

        return _jsonText;
    }

    public void Save()
    {
        _jsonText = JsonUtility.ToJson(this);
        File.WriteAllText(GetSaveFilePath(), _jsonText);
    }

    public void Delete()
    {
        _jsonText = JsonUtility.ToJson(new PlayerDataInstance());
        Reload();
    }

    private static string GetSaveFilePath()
    {
        string filePath = "PlayerDataInstance";
#if UNITY_EDITOR
        filePath += ".json";
#else
        filePath = Application.persistentDataPath + "/" + filePath;
#endif
        Debug.Log(filePath);
        return filePath;
    }

    public Dictionary<string,bool> GetConnectedParts()
    {
        return PartsDict;
    }

    public void SetPlayerData(PlayerData data)
    {
        PartsDict = GetConnectedParts();
    }
}
