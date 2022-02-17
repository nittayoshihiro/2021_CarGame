using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownItem : MonoBehaviour
{
    [SerializeField] float m_downspeed = 0.8f;
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
                playerController.m_speed *=m_downspeed;
                m_audioSource.PlayOneShot(m_itemSound);
                this.gameObject.SetActive(false);
            }
        }
    }
}
