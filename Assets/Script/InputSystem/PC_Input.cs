using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>PC入力クラス</summary>
public class PC_Input : BasePlayerController
{
    // Update is called once per frame
    public override void PlayerUpdate()
    {
        base.PlayerUpdate();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Mouse0))
        {
            m_gasPedal = true;
        }
        else
        {
            m_gasPedal = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_leftRotaion = true;
        }
        else
        {
            m_leftRotaion = false;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Mouse1))
        {
            m_BackPedal = true;
        }
        else
        {
            m_BackPedal = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rightRotaion = true;
        }
        else
        {
            m_rightRotaion = false;
        }

    }
}
