using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneTransition : State
{
    bool UpLoopStop;
    public override void OnEnter(State state, TitleResultSceen titleResult)
    {
        titleResult.startUI.gameObject.SetActive(true);
        UpLoopStop = true;
    }
    public override void OnExit(State state, TitleResultSceen titleResult)
    {
        titleResult.resultUI.gameObject.SetActive(true);
    }
    // 状態の更新はこのUpdateで行う
    public override void OnUpdate(State state, TitleResultSceen titleResult)
    {
        if (UpLoopStop == true)
        {
            titleResult.startUI.gameObject.SetActive(false);
            titleResult.resultUI.gameObject.SetActive(false);
            UpLoopStop = false;
        }
    }
}
