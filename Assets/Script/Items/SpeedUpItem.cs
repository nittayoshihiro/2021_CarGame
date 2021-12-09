using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    [SerializeField] float m_boostspeed = 30f;
    [SerializeField] float m_effecttime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ItemEffectSpeed(m_effecttime, m_boostspeed);
            Destroy(this.gameObject);
        }
    }
}
