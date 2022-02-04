using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemBaseData
{
    /// <summary>
    /// アイテムに触れた際の処理
    /// </summary>
    /// <param name="playerController"></param>
    void OnEnter(PlayerController playerController);
}
