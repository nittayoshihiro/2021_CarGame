using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitManagement : MonoBehaviour
{
    public Text lapsText;
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
    public int WeekNum = 1;
    /// <summary> チェックポイントobjを保管しておく</summary>
    [HideInInspector]
    public GameObject[] checkPointObj = new GameObject[50];
    void Start()
    {
        lapsText.text = WeekNum.ToString()+"/3";
    }
    public void Reset()
    {
        WeekNum = 1;
        lapsText.text = WeekNum.ToString() + "/3";
        num = 0;
    }
}
