using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : MonoBehaviour,GameSceneBase
{
    [SerializeField] GameObject m_titleCanvas = null;

    public void OnEnter(GameSceneBase gameSceneBase)
    {
        m_titleCanvas.SetActive(true);
    }

    public void OnUpdata(GameSceneBase gameSceneBase)
    {

    }

    public void OnExit(GameSceneBase gameSceneBase)
    {
        m_titleCanvas.SetActive(false);
    }
}
