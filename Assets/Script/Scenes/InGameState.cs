using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InGameState : MonoBehaviour, GameSceneBase
{
    [SerializeField] GameObject m_ingameCanvas = null;
    [SerializeField] GameObject m_player = null;
    [SerializeField] Text m_timeText = null;
    [SerializeField] Text m_speedText = null;
    [SerializeField] Text m_countText = null;
    [SerializeField] GameObject m_countObject = null;
    bool m_time = false;
    float m_timer = 0f;
    PlayerController m_playerController = null;
    GameManager m_gameManager = null;
    AudioController m_audioController = null;

    public void OnEnter(GameSceneBase gameSceneBase)
    {
        m_ingameCanvas.SetActive(true);
        m_player.SetActive(true);
        m_playerController = FindObjectOfType<PlayerController>();
        m_audioController = FindObjectOfType<AudioController>();
        m_audioController.StartCount();
        m_countObject.SetActive(true);
        m_timeText.text = string.Format("Time:{0:000.0}",0f);
        m_speedText.text = string.Format("{0:00}Km", 0f);

        m_countText.DOCounter(3, 1, 3f).OnComplete(() =>
        {
            m_countText.text = "start";
            m_time = true;
        });
        Invoke("Countfalse", 3.5f);
    }

    private void Countfalse()
    {
        m_countObject.SetActive(false);
    }

    public void OnUpdata(GameSceneBase gameSceneBase)
    {
        if (m_time)
        {
            m_timer += Time.deltaTime;
            m_timeText.text = string.Format("Time:{0:000.0}", m_timer);
            m_speedText.text = string.Format("{0:00}Km", m_playerController.m_speed * 2);
        }
    }

    public void OnExit(GameSceneBase gameSceneBase)
    {
        m_countText.text = "";
        m_gameManager = FindObjectOfType<GameManager>();
        m_gameManager.m_time = m_timer;
        m_time = false;
        m_timer = 0f;
        m_playerController.PlayerReset();
        m_player.SetActive(false);
        m_ingameCanvas.SetActive(false);
    }
}
