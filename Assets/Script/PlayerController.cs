using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float m_accel = 2f;
    [SerializeField] public float m_maxspeed = 20f;
    [SerializeField] public float m_rotaionaccel = 2f;
    [SerializeField] public float m_maxrotaionspeed = 20f;
    [SerializeField] float m_defoltFOV = 90;
    [SerializeField] Camera m_playerCamera = null;
    [SerializeField] GameObject m_speedEfect = null;
    AudioController m_audioController = null;
    public Rigidbody m_rigidbody;
    List<IPlayerBaseState> m_playerBaseStates = new List<IPlayerBaseState>();
    /// <summary>プレイヤーのスピード</summary>
    public float m_speed = 0f;
    /// <summary>プレイヤーの回転</summary>
    public float m_rotation = 0f;
    Coroutine m_coroutine = null;
    //ゲートのカウントを保持します。
    public int gateCount = 0;

    void Start()
    {
        m_audioController = FindObjectOfType<AudioController>();
        m_rigidbody = this.GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        if (40 < m_speed)
        {
            m_speedEfect.SetActive(true);
        }
        else
        {
            m_speedEfect.SetActive(false);
        }

        foreach (IPlayerBaseState item in m_playerBaseStates)
        {
            item.OnUpdate(this);
        }
        m_playerCamera.fieldOfView = m_defoltFOV + (m_speed / 2f);
        m_rigidbody.velocity = transform.forward * m_speed;
        m_speed *= 0.995f;

        m_audioController.EngenVolume(m_speed / 50);
    }

    /// <summary>アイテム効果スピード関数</summary>
    public void ItemEffectSpeed(float wait, float accel)
    {
        if (m_coroutine != null)
        {
            StopCoroutine(m_coroutine);
        }
        m_coroutine = StartCoroutine(EffectCoroutine(wait, accel));
    }

    IEnumerator EffectCoroutine(float wait, float accel)
    {
        while (0 < wait)
        {
            m_speed = accel;
            m_rigidbody.velocity = transform.forward * accel;
            wait -= Time.deltaTime;
            yield return null;
        }
    }

    public void PlayerStateAdd(IPlayerBaseState playerBaseState)
    {
        m_playerBaseStates.Add(playerBaseState);
    }

    public void PlayerStateRemove(IPlayerBaseState playerBaseState)
    {
        m_playerBaseStates.Remove(playerBaseState);
    }

    public void PlayerReset()
    {
        m_speed = 0f;
        m_playerBaseStates.Clear();
    }
}