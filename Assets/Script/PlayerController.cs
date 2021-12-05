using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float m_accel = 2f;
    [SerializeField] public float m_maxspeed = 20f;
    [SerializeField] public float m_rotaionaccel = 2f;
    [SerializeField] public float m_maxrotaionspeed = 20f;
    [SerializeField] GameObject m_smartphonecanvas = null;//後に読み取りで動作するようにする
    public Rigidbody m_rigidbody;
    List<PlayerBaseState> m_playerBaseStates = new List<PlayerBaseState>();
    /// <summary>プレイヤーのスピード</summary>
    public float m_speed = 0f;
    /// <summary>プレイヤーの回転</summary>
    public float m_rotation = 0f;

    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;
        Instantiate(m_smartphonecanvas);
    }

    void Update()
    {
        foreach (PlayerBaseState item in m_playerBaseStates)
        {
            item.OnUpdate(this);
        }
    }

    public void PlayerStateAdd(PlayerBaseState playerBaseState)
    {
        m_playerBaseStates.Add(playerBaseState);
    }

    public void PlayerStateRemove(PlayerBaseState playerBaseState)
    {
        m_playerBaseStates.Remove(playerBaseState);
    }
}