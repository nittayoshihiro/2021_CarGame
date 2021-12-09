using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPedalState : MonoBehaviour, IPlayerBaseState
{
    PlayerController m_playerController = null;

    public void Start()
    {
        m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void OnUpdate(PlayerController playerController)
    {
        if (0 < playerController.m_speed)
        {
            playerController.m_speed -= playerController.m_accel * 3 * Time.deltaTime;
        }
        else
        {
            playerController.m_speed -= playerController.m_accel * Time.deltaTime;
        }
        playerController.m_speed = Mathf.Clamp(playerController.m_speed, -playerController.m_maxspeed / 2, playerController.m_maxrotaionspeed);
    }

    public void BackAdd()
    {
        m_playerController.PlayerStateAdd(this);
    }

    public void BackRemove()
    {
        m_playerController.PlayerStateRemove(this);
    }
}
