using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float m_power = 20;
    [SerializeField] public float m_rotaionpower = 0.5f;
    [SerializeField] GameObject m_SmartPhoneCanvas = null;//後に読み取りで動作するようにする
    public Rigidbody m_rigidbody;
    List<PlayerBaseState> m_playerBaseStates = new List<PlayerBaseState>();

    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;

#if UNITY_ANDROID
        Instantiate(m_SmartPhoneCanvas);
#endif
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