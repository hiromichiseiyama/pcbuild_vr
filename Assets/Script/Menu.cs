using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //非表示のセッティングメニューのゲームオブジェクト
    [SerializeField]
    private GameObject settingmenu;

    void Start()
    {
        //もし表示のままだった場合、非表示にしておく
        settingmenu.SetActive(false);
    }

    void Update()
    {

        
    }

    public void Start_Exercise(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Quit_Exercise()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();

#endif

    }

    public void Activate_SettingMenu()
    {
        settingmenu.SetActive(true);
    }

    public void Deactivate_SettingMenu()
    {
        settingmenu.SetActive(false);
    }

    public void Restart_Exercise()
    {
        string scenename = "Title";
        SceneManager.LoadScene(scenename);
    }
}
