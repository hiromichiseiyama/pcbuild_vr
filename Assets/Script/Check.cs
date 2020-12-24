using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
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
