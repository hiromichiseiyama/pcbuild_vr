using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private Flagmanager flagManager;

    //全てのパーツに接続されていないという意味のboolにfalseを持たせる
    void Start()
    {
        flagManager = GetComponent<Flagmanager>();

        flagManager.flagDict.Add("CPU",false);
        flagManager.flagDict.Add("MEMORY", false);
        flagManager.flagDict.Add("MOTHER", false);
        flagManager.flagDict.Add("POWER", false);
        flagManager.flagDict.Add("STORAGE", false);
    }

    //テストで関数を呼ぶ用
    private void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    StateChanger("CPU");
        //}

        Debug.Log(flagManager.flagDict["CPU"]);
    }

    //引数で取得したパーツの接続状態を反転する
    public void StateChanger(string parts_name)
    {
        flagManager.flagDict[parts_name] = !(bool)flagManager.flagDict[parts_name];
    }
}
