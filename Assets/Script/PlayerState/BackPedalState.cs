using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPedalState : MonoBehaviour, PlayerBaseState
{
    PlayerController m_playerController = null;

    public void Start()
    {
        m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void OnUpdate(PlayerController playerController)
    {
        playerController.m_speed -= playerController.m_accel * Time.deltaTime;
        playerController.m_speed = Mathf.Clamp(playerController.m_speed, -playerController.m_maxspeed, 0f);
        playerController.m_rigidbody.velocity = playerController.transform.forward * playerController.m_speed;
    }

    public void BackAdd()
    {
        m_playerController.PlayerStateAdd(this);
    }

    public void BackRemove()
    {
        m_playerController.m_speed = 0;
        m_playerController.PlayerStateRemove(this);
    }
}
