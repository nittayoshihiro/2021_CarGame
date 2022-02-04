using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    [SerializeField] float m_boostspeed = 30f;
    [SerializeField] float m_effecttime = 1f;
    [SerializeField] AudioClip m_itemSound = null;
    AudioSource m_audioSource = null;

    private void Start()
    {
        m_audioSource = this.transform.parent.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Body")
        {
            PlayerController playerController = other.transform.parent.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ItemEffectSpeed(m_effecttime, m_boostspeed);
                m_audioSource.PlayOneShot(m_itemSound);
                this.gameObject.SetActive(false);
            }
        }
    }
}
