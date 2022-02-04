using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource m_playerSE = null;
    [SerializeField] AudioSource m_sfx = null;
    [SerializeField] AudioSource m_bgm = null;
    [SerializeField] AudioClip m_engen = null;
    [SerializeField] AudioClip m_titleBGM = null;
    [SerializeField] AudioClip m_ingameBGM = null;
    [SerializeField] AudioClip m_resultBGM = null;

    private void Start()
    {
        m_playerSE.clip = m_engen;
        m_playerSE.volume = 0f;
        m_bgm.Play();
    }

    public void ChangeAudioClip(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        m_sfx.clip = audioClip;
        m_sfx.Play();
    }

    public void EngenVolume(float volume)
    {
        m_playerSE.volume = volume;
    }

    public void TiteBGM()
    {
        ChangeAudioClip(m_titleBGM, m_bgm);
    }

    public void GameBGM()
    {
        ChangeAudioClip(m_ingameBGM, m_bgm);
    }

    public void ResultBGM()
    {
        ChangeAudioClip(m_resultBGM, m_bgm);
    }
}
