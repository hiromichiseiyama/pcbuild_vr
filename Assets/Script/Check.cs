using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
    //パーツの接続可能個数
    public int num = 1;
    
    public void CheckConnect()
    {
        if (isConnect())
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            Debug.Log("未接続の箇所があります");
        }
    }

    public bool isConnect()
    {
        //ProgressData progress = new ProgressData();

        //Debug.Log(progress.progress_stack.Count);
        //リストの要素数で接続がされているかを確認している
        if (ProgressData.progress_stack.Count >= num)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
