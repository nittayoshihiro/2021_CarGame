using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightRotationState : MonoBehaviour, PlayerBaseState
{
    PlayerController m_playerController = null;
    Image m_image = null;

    public void Start()
    {
        m_image = GetComponent<Image>();
        m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void OnUpdate(PlayerController playerController)
    {
        if (playerController.m_rigidbody.velocity != Vector3.zero)
        {
            playerController.transform.Rotate(Vector3.up * playerController.m_rotaionpower);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_image.color = Color.black;
        m_playerController.PlayerStateAdd(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_image.color = Color.white;
        m_playerController.PlayerStateRemove(this);
    }
}
