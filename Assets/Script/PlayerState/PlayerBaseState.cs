using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerBaseState
{
    /// <summary>このステータス中に呼ばれ続ける処理</summary>
    void OnUpdate(PlayerController playerController);
}
