using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectParts : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        if (this.gameObject.GetComponent<FixedJoint>().connectedBody == false)
        {
            Destroy(this.gameObject.GetComponent<FixedJoint>());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "parts")
        //{
        //    ConnectbyFixedJoint(other.gameObject, this.gameObject);
        //}
        //ConnectbyFixedJoint(obj, other.gameObject);
    }

    //Partsタグを持ったオブジェクトと衝突すると接続される
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Parts")
        {
            ConnectbyFixedJoint(this.gameObject, collision.gameObject);
        }
    }

    //objがrevobjに接続される
    void ConnectbyFixedJoint(GameObject obj, GameObject revobj)
    {
        //接続したオブジェクトの接続ステータスを変更する
        GameObject status = GameObject.Find("Status").gameObject;
        var state = status.GetComponent<Status>();
        state.StateChanger(obj.gameObject.name);
        

        //相対座標、相対回転量
        Vector3 localpos = new Vector3(0, 1, 0);
        Quaternion localrot = new Quaternion(0, 0, 0, 0);

        //親子にする
        obj.transform.parent = revobj.transform;
        //ローカルトランスフォームを代入する
        obj.transform.localPosition = localpos;
        obj.transform.localRotation = localrot;

        //重力を切る
        //revobj.GetComponent<Rigidbody>().useGravity = false;

        obj.AddComponent<FixedJoint>();
        FixedJoint joint = obj.GetComponent<FixedJoint>();
        joint.connectedBody = revobj.GetComponent<Rigidbody>();
        joint.breakForce = 100f;
        joint.breakTorque = 100f;
    }
}
