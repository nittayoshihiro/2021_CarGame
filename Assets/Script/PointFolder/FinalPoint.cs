using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    /// <summary>チェックポイントの番号</summary>
    [Header("最終チェックポイントの番号")]
    public int CheckPointNumber = 0;
    /// <summary>OrbitManagementを呼び出し</summary>
    OrbitManagement Orbit_M;
    [Header("このスクリプトが付いているObjを入れる")]
    public GameObject Orbit_obj;
    void Start()
    {
        Orbit_M = FindObjectOfType<OrbitManagement>();
        Orbit_M.checkPointObj[CheckPointNumber] = Orbit_obj;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //全てのチェックポイントを通過したかどうか
            if (Orbit_M.allCheckPoint == true)
            {
                Orbit_M.num = CheckPointNumber;
                Orbit_M.WeekNum += 1;
                Orbit_M.lapsText.text = Orbit_M.WeekNum.ToString()+"/3";
                Orbit_M.allCheckPoint = false;
            }
        }
    }
}
