using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEvent : MonoBehaviour
{
    TitleResultSceen titleResult;
    void Start()
    {
        titleResult = FindObjectOfType<TitleResultSceen>();
    }
    public void OnClick_Start()
    {
        titleResult.sceenCheng = true;
    }
    public void OnClick_Result()
    {
        titleResult.Reset();
    }
}
