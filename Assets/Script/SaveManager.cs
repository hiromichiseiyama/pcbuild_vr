using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using System.ComponentModel.Design;


////保存用クラスのインターフェース
////仕様変更に応じて新たな子供クラスを定義してオーバーロードして使う
//public interface Save<T>
//{
//    //辞書型とクラスのメンバーを相互変換するメソッドを必ず実装すること
//    T Interconversion();
//}

//保存するクラス
//シリアライズ可能である

[Serializable]
public class SaveData /*: Save<Dictionary<string,bool>>*/
{
    public bool cpu;
    public bool memory;
    public bool storage;
    public bool gpu;
    public bool power;
    public bool fan;

    //この値を変更する
    //public Dictionary<string, bool> flag = new Dictionary<string, bool>();
    string fname = "16221.txt";

    //新規作成時はこのメソッドを呼ぶ
    //初期化用コンストラクタ
    public SaveData()
    {
        cpu = false;
        memory = false;
        storage = false;
        gpu = false;
        power = false;
        fan = false;
    }

    //Jsonをデシリアライズするメソッド
    //要修正)fnameをユーザが入力した文字列にする
    //public void RoadJson()
    //{
    //    var info = new FileInfo(Application.dataPath + "/" + fname);
    //    var reader = new StreamReader(info.OpenRead());
    //    var json = reader.ReadToEnd();
    //    var data = JsonUtility.FromJson<SaveData>(json);

    //    Dump();
    //}

    //public void WriteJson()
    //{
    //    var json = JsonUtility.ToJson(SaveData);
    //    var path = UnityEngine.Application.dataPath + "/" + fname;
    //    StreamWriter writer = new StreamWriter(path, false);
    //    writer.WriteLine(json);
    //    writer.Flush();
    //    writer.Close();
    //}

    //途中から始める場合はこのメソッドでフィールドを辞書型に変換する
    public Dictionary<string, bool> Interconversion(SaveData data)
    {
        var retdict = new Dictionary<string, bool>();
        List<string> names = new List<string>();

        var t = typeof(SaveData);
        foreach (var one in t.GetFields())
        {
            names.Add(one.Name);
        }

        retdict.Add(names[0], data.cpu);
        retdict.Add(names[1], data.memory);
        retdict.Add(names[2], data.storage);
        retdict.Add(names[3], data.gpu);
        retdict.Add(names[4], data.power);
        retdict.Add(names[5], data.fan);
        ////要削除)一応表示
        ////Dump(retdict);

        return retdict;
    }

    //辞書型をクラスのフィールドに変換
    //public void Interconversion(Dictionary<string, bool> dict)
    //{
    //    var t = typeof(SaveData);
    //    foreach (var val_f in t.GetFields())
    //    {
    //        var name_f = val_f.Name;
    //        var value_f = val_f.GetValue(t);

    //        foreach(KeyValuePair<string, bool> val_d in dict)
    //        {
    //            var name_d = val_d.Key;
    //            var value_d = val_d.Value;
    //            if (name_f == name_d)
    //            {
    //                value_f = value_d;
    //            }
                
    //        }
    //    }
    //}

    //表示系
    //public void Dump()
    //{
    //    var t = typeof(SaveData);
    //    foreach (var one in flag)
    //    {
    //        Debug.Log(one);
    //    }
    //}

    public void Dump(Dictionary<string, bool> dict)
    {
        Debug.Log("辞書型dump");
        foreach(var one in dict)
        {
            Debug.Log(one);
        }
    }
}

//この辞書型を直接書き換える
//public class tmpDict
//{
//    Dictionary<string, bool> flag = new Dictionary<string, bool>();

//    //新規作成の場合はこのメソッドを実行する
//    public void FillFalse()
//    {

//    }

//    public void DictConvert()
//    {

//    }

//    public void Interconversion()
//    {

//    }
//}

public class SaveManager : MonoBehaviour
{    
    SaveData savedata = new SaveData();
    public static string fname = "16221.txt";
    static Dictionary<string, bool> flag = new Dictionary<string, bool>();

    void Start()
    {
        //最初は初期化
        flag.Add("cpu", false);
        flag.Add("memory", false);
        flag.Add("storage", false);
        flag.Add("gpu", false);
        flag.Add("power", false);
        flag.Add("fan", false);
    }

    public void UpdateFlag(string name)
    {
        flag[name] = true;
        Debug.Log(flag);
    }

    public static void Updatefname(string name)
    {
        fname = name + ".txt";
    }

    public void Test()
    {
        List<string> names = new List<string>();
        var t = typeof(SaveData);
        foreach(var one in t.GetFields())
        {
            names.Add(one.Name);
        }

        var rand = UnityEngine.Random.Range(0, 5);
        Debug.LogWarning("value : " + names[rand]);
        var nowval = flag[names[rand]];
        flag[names[rand]] = !nowval;
    }

    //辞書型をクラスのフィールドに変換
    public void Interconversion(SaveData data,Dictionary<string, bool> dict)
    {
        List<bool> values = new List<bool>();

        foreach (KeyValuePair<string, bool> val_d in dict)
        {
            var name_d = val_d.Key;
            var value_d = val_d.Value;
            Debug.Log("values : "+val_d.ToString());
            values.Add(value_d);
        }

        data.cpu = values[0];
        data.memory = values[1];
        data.storage = values[2];
        data.gpu = values[3];
        data.power = values[4];
        data.fan = values[5];
    }

    public void WriteJson()
    {
        //dict内の値をクラスに書き込む
        //Interconversion(savedata,dict);
        Interconversion(savedata,flag);
        //savedata.Dump(dict);
        var json = JsonUtility.ToJson(savedata);
        //var path = Application.dataPath + "/" + fname;
        var path = Application.persistentDataPath + "/" + fname;
        StreamWriter writer = new StreamWriter(path,false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    //public void WriteJson()
    //{
    //    var json = JsonUtility.ToJson(savedata);
    //    var path = Application.dataPath + "/" + fname;
    //    StreamWriter writer = new StreamWriter(path, false);
    //    writer.WriteLine(json);
    //    writer.Flush();
    //    writer.Close();
    //}

    public void RoadJson()
    {
        var info = new FileInfo(Application.dataPath + "/" + fname);
        var reader = new StreamReader(info.OpenRead());
        var json = reader.ReadToEnd();
        var savedata = JsonUtility.FromJson<SaveData>(json);
        //クラスのフィールドから辞書型を書き換え
        flag = savedata.Interconversion(savedata);
        savedata.Dump(flag);
    }

    //テスト用コマンド
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Test();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            WriteJson();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RoadJson();
        }
    }
}
