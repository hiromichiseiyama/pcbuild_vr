using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//各パーツが接続されているか否かのbool情報を持つフラグ管理用クラス
public class Flagmanager : MonoBehaviour
{
    public Dictionary<string, object> flagDict = new Dictionary<string, object>();
}
