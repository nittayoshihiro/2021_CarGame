using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmartPhoneController : MonoBehaviour
{
    [SerializeField] GameObject m_touchPointerOne;
    [SerializeField] GameObject m_touchPointerTwo;
    PlayerController m_playerController;
    Vector3 m_vector3zZero = new Vector3(1, 1, 0);
    Vector2 m_touchbegin = new Vector2(0, 0);
    /// <summary>左のタッチ保存</summary>
    Touch m_leftTouch = new Touch();
    //leftTouchは０から１で管理します。
    float m_leftTouchx = 0;
    float m_leftTouchy = 0;
    public Vector2 GetleftVector => new Vector2(m_leftTouchx, m_leftTouchy);

    private void Start()
    {
        m_playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        switch (Input.touches.Length)
        {
            case 0:
                break;
            case 1://1本以上タッチされた時
                Touch(Input.touches[0], m_touchPointerOne);
                break;
            case 2://2本タッチされている時
                Touch(Input.touches[0], m_touchPointerOne);
                Touch(Input.touches[1], m_touchPointerTwo);
                break;
        }

        m_playerController.transform.Rotate(new Vector3(0, m_leftTouchy, 0) * m_playerController.m_rotaionaccel);


#elif UNITY_EDITOR
    if (Input.GetMouseButton(0))
    {
            m_touchPointerOne.SetActive(true);
            m_touchPointerOne.transform.position = Input.mousePosition;
    }
#endif
    }

    private void Touch(Touch touch, GameObject gameObject)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                gameObject.SetActive(true);
                gameObject.transform.position = touch.position;
                break;
            case TouchPhase.Moved:
                gameObject.transform.position = touch.position;
                break;
            case TouchPhase.Ended:
                gameObject.SetActive(false);
                break;
        }
    }
}
