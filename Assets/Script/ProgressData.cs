using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProgressData : MonoBehaviour
{
    public static List<string> progress_stack = new List<string>();
    int index = 0;
    
    public void RegisteProgress(string parts_name)
    {
        progress_stack.Add(parts_name);
        Debug.Log(progress_stack[index] + "を登録しました.");
        index++;

        if (index > 10)
        {

        }
    }
}
