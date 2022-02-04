using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameState : MonoBehaviour, GameSceneBase
{
    [SerializeField] GameObject m_ingameCanvas = null;
    [SerializeField] GameObject m_player = null;
    [SerializeField] Text m_timeText = null;
    [SerializeField] Text m_speedText = null;
    bool m_time = false;
    float m_timer = 0f;
    PlayerController m_playerController = null;
    GameManager　m_gameManager = null;

    public void OnEnter(GameSceneBase gameSceneBase)
    {
        m_ingameCanvas.SetActive(true);
        m_player.SetActive(true);
        m_time = true;
        m_playerController = FindObjectOfType<PlayerController>();
    }

    public void OnUpdata(GameSceneBase gameSceneBase)
    {
        if (m_time)
        {
            m_timer += Time.deltaTime;
            m_timeText.text = string.Format("Time:{0:000.0}", m_timer);
            m_speedText.text = string.Format("{0:00}Km", m_playerController.m_speed);
        }
    }

    public void OnExit(GameSceneBase gameSceneBase)
    {
        m_gameManager = FindObjectOfType<GameManager>();
        m_gameManager.m_time = m_timer;
        m_time = false;
        m_timer = 0f;
        m_playerController.PlayerReset();
        m_player.SetActive(false);
        m_ingameCanvas.SetActive(false);
    }
}
