using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameSceneBase
{
    void OnEnter(GameSceneBase gameSceneBase);
    void OnUpdata(GameSceneBase gameSceneBase);
    void OnExit(GameSceneBase gameSceneBase);
}
