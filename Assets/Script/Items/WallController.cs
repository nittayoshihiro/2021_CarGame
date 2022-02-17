using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour
{
    [SerializeField] float m_downspeed = 0.8f;
    [SerializeField] float m_effecttime = 1f;
    [SerializeField] AudioClip m_itemSound = null;
    AudioSource m_audioSource = null;
    GameManager m_gameManager = null;

    private void Start()
    {
        m_audioSource = this.transform.parent.GetComponent<AudioSource>();
        m_gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            PlayerController playerController = other.transform.parent.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.PlayerReset();
                m_audioSource.PlayOneShot(m_itemSound);
                m_gameManager.GameOver();
            }
        }
    }
}
