using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightRotationState : MonoBehaviour, PlayerBaseState
{
    PlayerController m_playerController = null;

    public void Start()
    {
        m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void OnUpdate(PlayerController playerController)
    {
        playerController.m_rotation += playerController.m_rotaionaccel * Time.deltaTime;
        playerController.m_rotation = Mathf.Clamp(playerController.m_rotation, 0, playerController.m_maxrotaionspeed);
        playerController.transform.Rotate(Vector3.up * playerController.m_rotation);
    }

    public void RightAdd()
    {
        m_playerController.PlayerStateAdd(this);
    }

    public void RightRemove()
    {
        m_playerController.m_rotation = 0;
        m_playerController.PlayerStateRemove(this);
    }
}
