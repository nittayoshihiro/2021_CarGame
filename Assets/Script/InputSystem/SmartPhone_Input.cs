using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>スマホ入力クラス</summary>
public class SmartPhone_Input : BasePlayerController, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject m_a_gameobject = null;
    [SerializeField] GameObject m_b_gameobject = null;
    [SerializeField] GameObject m_r_gameobject = null;
    [SerializeField] GameObject m_l_gameobject = null;
    [SerializeField] GameObject m_j_gameobject = null;

    // Update is called once per frame
    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter == m_a_gameobject)
        {
            m_gasPedal = true;
        }
        if (eventData.pointerEnter == m_b_gameobject)
        {
            m_BackPedal = true;
        }
        if (eventData.pointerEnter == m_r_gameobject)
        {
            m_rightRotaion = true;
        }
        if (eventData.pointerEnter == m_l_gameobject)
        {
            m_leftRotaion = true;
        }
        if (eventData.pointerEnter == m_j_gameobject)
        {
            m_Jump = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter == m_a_gameobject)
        {
            m_gasPedal = true;
        }
        if (eventData.pointerEnter == m_b_gameobject)
        {
            m_BackPedal = true;
        }
        if (eventData.pointerEnter == m_r_gameobject)
        {
            m_rightRotaion = true;
        }
        if (eventData.pointerEnter == m_l_gameobject)
        {
            m_leftRotaion = true;
        }
        if (eventData.pointerEnter == m_j_gameobject)
        {
            m_Jump = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter == m_a_gameobject)
        {
            m_gasPedal = false;
        }
        if (eventData.pointerEnter == m_b_gameobject)
        {
            m_BackPedal = false;
        }
        if (eventData.pointerEnter == m_r_gameobject)
        {
            m_rightRotaion = false;
        }
        if (eventData.pointerEnter == m_l_gameobject)
        {
            m_leftRotaion = false;
        }
        if (eventData.pointerEnter == m_j_gameobject)
        {
            m_Jump = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerEnter == m_a_gameobject)
        {
            m_gasPedal = false;
        }
        if (eventData.pointerEnter == m_b_gameobject)
        {
            m_BackPedal = false;
        }
        if (eventData.pointerEnter == m_r_gameobject)
        {
            m_rightRotaion = false;
        }
        if (eventData.pointerEnter == m_l_gameobject)
        {
            m_leftRotaion = false;
        }
        if (eventData.pointerEnter == m_j_gameobject)
        {
            m_Jump = false;
        }
    }
}
