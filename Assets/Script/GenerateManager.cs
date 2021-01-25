using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateManager : MonoBehaviour
{
    //public GameObject cpu;
    //public GameObject memory;
    //public GameObject storage;
    //public GameObject gpu;
    //public GameObject power;
    //public GameObject fan;

    [SerializeField]
    List<GameObject> objects = new List<GameObject>();

    [SerializeField]
    Transform gpos;

    public void Generate(string name)
    {
        foreach(var item in objects)
        {
            if (item.name == name && !(Exsits(item)))
            {
                var parts = Instantiate(item, gpos.position, Quaternion.identity);
                parts.name = item.name;
            }
        }
    }

    //引数に指定したGameObjctがシーン内に存在すれば正を返す
    public bool Exsits(GameObject obj)
    {
        GameObject[] allobjcts = SceneManager.GetActiveScene().GetRootGameObjects();
        bool isExsits = false;

        foreach(var item in allobjcts)
        {
            if (obj.name == item.name) isExsits = true;
        }

        return isExsits;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Generate("memory");
        }
    }
}
