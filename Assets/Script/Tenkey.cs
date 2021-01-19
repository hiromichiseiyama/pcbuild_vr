using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Tenkey : MonoBehaviour
{
    static List<string> fname = new List<string>();
    private Text inputtext;

    void Start()
    {
        //inputtext = GameObject.Find("InputText").GetComponent<Text>();
        inputtext = this.gameObject.GetComponent<Text>();
    }

    public void UpdateText()
    {
        inputtext.text = string.Join("",fname);
    }

    public void Input(GameObject button)
    {
        var result = 0;
        var ret = int.TryParse(button.name, out result);
        //Debug.Log(ret.ToString());

        if(button.gameObject.name == "BackSpace" && fname.Count>=1)
        {
            fname.RemoveAt(fname.Count - 1);
        }
        else if (fname.Count>=5)
        {
            GameObject[] allobjcts = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach(var val in allobjcts)
            {
                if(val.name == "Erorr")
                {
                    val.SetActive(true);
                    //Debug.Log(val.name);
                }
            }
        }
        else if(ret)
        {
            fname.Add(button.gameObject.name);
        }

        UpdateText();
    }

    public void OpenFile()
    {
        //string text = inputtext.text;
        string text= string.Join("", fname);
        var path = Application.dataPath + "/" + text+ ".txt";
        //Debug.Log(fname.Count.ToString());

        if (File.Exists(path))
        {
            SaveManager.fname = text+".txt";

        }
        else
        {
            Debug.Log("ファイルが存在しません");
        }
    }
}
