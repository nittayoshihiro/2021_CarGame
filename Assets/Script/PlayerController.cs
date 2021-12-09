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
    [SerializeField] GameObject m_smartphonecanvas = null;//後に読み取りで動作するようにする
    [SerializeField] Camera m_playerCamera = null;
    public Rigidbody m_rigidbody;
    List<IPlayerBaseState> m_playerBaseStates = new List<IPlayerBaseState>();
    /// <summary>プレイヤーのスピード</summary>
    public float m_speed = 0f;
    /// <summary>プレイヤーの回転</summary>
    public float m_rotation = 0f;
    Coroutine m_coroutine = null;

    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;
        Instantiate(m_smartphonecanvas);
    }

    void Update()
    {
        foreach (IPlayerBaseState item in m_playerBaseStates)
        {
            item.OnUpdate(this);
        }
        m_playerCamera.fieldOfView = m_defoltFOV + (m_speed / 2f);
        m_rigidbody.velocity = transform.forward * m_speed;
        m_speed = Mathf.Lerp(m_speed, 0f, Time.deltaTime/5);
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

}