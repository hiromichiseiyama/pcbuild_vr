using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 mousepos = new Vector3();
    Vector3 mousepos_screen = new Vector3();
    
    //[SerializeField]
    //private GameObject obj;

    void Start()
    {
        
    }

    void Update()
    {
//#if UNTIY_EDITOR
        if (Input.GetMouseButton(0))
        {
            mousepos = Input.mousePosition;

            mousepos.z = 5.4f;

            mousepos_screen = Camera.main.ScreenToWorldPoint(mousepos);

            this.gameObject.transform.position = mousepos_screen;
        }
//#endif
    }
}
