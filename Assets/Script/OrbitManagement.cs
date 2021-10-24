using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManagement : MonoBehaviour
{
    /// <summary> 現在のチェックポイント</summary>
    [Header("現在通過したチェックポイント番号")]
    public float num;
    /// <summary> 置いてあるチェックポイントの最大数</summary>
    [Header("最大チェックポイントの数")]
    public int MaxCheckPoint;
    ///<summary> チェックポイント全て通ったかどうか</summary>
    [HideInInspector]
    public bool allCheckPoint = false;
    /// <summary> 周回数</summary>
    public int WeekNum;
    /// <summary> チェックポイントobjを保管しておく</summary>
    [HideInInspector]
    public GameObject[] checkPointObj = new GameObject[50];
}
