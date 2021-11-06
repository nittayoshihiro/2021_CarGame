using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : State
{
    public override void OnEnter(State state)
    {
        SceneManager.LoadScene("TestMap");
    }
    public override void OnExit(State state)
    {
        SceneManager.LoadScene("TitleResult");
    }
    // 状態の更新はこのUpdateで行う
    public override void OnUpdate(State state)
    {

    }
}
