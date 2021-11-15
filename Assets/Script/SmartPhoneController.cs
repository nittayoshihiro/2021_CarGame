using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneController : MonoBehaviour
{
    [SerializeField] GameObject m_touchPointerOne;
    [SerializeField] GameObject m_touchPointerTwo;
    Vector3 m_vector3zZero = new Vector3(1, 1, 0);

    // Update is called once per frame
    void Update()
    {
        switch (Input.touches.Length)
        {
            case 0:
                break;
            case 1://一本タッチされている時
                TuchMode(Input.touches[0], m_touchPointerOne);
                break;
            default://二本以上タッチされた時
                TuchMode(Input.touches[0], m_touchPointerOne);
                TuchMode(Input.touches[1], m_touchPointerTwo);
                break;
        }
    }

    private void TuchMode(Touch touch, GameObject touchpoint)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                touchpoint.SetActive(true);
                touchpoint.transform.position = touch.position * m_vector3zZero;
                break;
            case TouchPhase.Moved:
                touchpoint.transform.position = touch.position * m_vector3zZero;
                break;
            case TouchPhase.Ended:
                touchpoint.SetActive(false);
                break;
        }
    }
}
