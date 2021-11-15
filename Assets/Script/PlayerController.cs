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
    public Transform m_transform;
    public Rigidbody m_rigidbody;
    List<PlayerBaseState> m_playerBaseStates = new List<PlayerBaseState>();

    void Start()
    {
        m_transform = this.GetComponent<Transform>();
        m_rigidbody = this.GetComponent<Rigidbody>();
        Application.targetFrameRate = 30;

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        m_BasePlayerController = this.gameObject.AddComponent<PC_Input>();
#elif UNITY_ANDROID
       // m_BasePlayerController = Instantiate(m_SmartPhoneCanvas).GetComponent<SmartPhone_Input>();
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