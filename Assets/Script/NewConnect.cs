using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewConnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == other.gameObject.name)
        {
            Connect(this.gameObject,other.gameObject);
        }
    }

    public void Connect(GameObject own,GameObject other)
    {
        //新しくオブジェクトを生成
        var child = Instantiate(other, own.transform.position, Quaternion.identity);
        Destroy(child.gameObject.GetComponent<Controller>());
        Destroy(other.gameObject);

        //親子関係の設定
        child.transform.parent = own.transform;
        //ローカル座標をゼロにする
        child.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        child.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        //undo処理の登録

        //接続情報の登録
        Progress(own.gameObject.name);


    }

    private void Progress(string objname)
    {
        ProgressData controller = new ProgressData();
        controller.RegisteProgress(objname);
    }
}
