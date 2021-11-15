using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    /// <summary>イベント前</summary>
    /// <param name="state"></param>
    public abstract void OnEnter(State state, TitleResultSceen titleResult);
    /// <summary>イベント後</summary>
    /// <param name="state"></param>
    public abstract void OnExit(State state, TitleResultSceen titleResult);
    public abstract void OnUpdate(State state, TitleResultSceen titleResult);
}
