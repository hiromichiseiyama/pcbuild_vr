using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[Serializable]
public class PlayerData : MonoBehaviour
{
    void Start()
    {
        //保存しておいたデータを取り出す
        //static変数を取得
        PlayerDataInstance _pInstance = PlayerDataInstance.Instance;
        //dataList = gameObject.GetComponent<DataList>();
        var parts = _pInstance.GetConnectedParts();
        Debug.Log(parts);
    }

    void Update()
    {
        
    }
}
