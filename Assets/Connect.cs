using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
    //マザーボードのゲームオブジェクトリファレンス
    public GameObject mother;
    
    public void ConnectParts(GameObject other)
    {
        //Debug.Log("現在接触したパーツは" + other.gameObject.name + "です");
        //衝突したパーツとコライダーを持っているオブジェクトの名前が一致したら接続する
        if (other.name == this.name)
        {
            var fixedJoint = other.gameObject.GetComponent<FixedJoint>();

            if (fixedJoint == null)
            {
                other.gameObject.AddComponent<FixedJoint>();
                fixedJoint = other.GetComponent<FixedJoint>();

                //other.transform.rotation = this.transform.rotation;
                other.transform.rotation = this.transform.localRotation;
                other.transform.position = this.transform.position;
                //other.transform.position = this.transform.localPosition;

                fixedJoint.connectedBody = mother.gameObject.GetComponent<Rigidbody>();
                //fixedJoint.breakForce = breakForce;
                //fixedJoint.breakTorque = breakTorque;
                //fixedJoint.enableCollision = true;
                //fixedJoint.enablePreprocessing = true;

                //　Rigidbodyの速度を0にし、スリープ状態にして止める
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().Sleep();

                UpdateSaveData(other.name);
            }
        }
    }

    public void UpdateSaveData(string name)
    {
        var ins = new SaveManager();
        ins.UpdateFlag(name);
    }

    private void OnTriggerEnter(Collider other)
    {
        ConnectParts(other.gameObject);
    }
}