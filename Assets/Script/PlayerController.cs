using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputStatus m_inputStatus;
    [SerializeField] float m_acceleration;
    Transform m_transform;
    Rigidbody m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.GetComponent<Transform>();
        m_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //入力形式
        switch (m_inputStatus)
        {
            case InputStatus.PC:
                if (Input.GetKey("w"))
                {
                    m_rigidbody.velocity += m_transform.TransformDirection(Vector3.forward * m_acceleration) * Time.fixedDeltaTime;
                }
                if (Input.GetKey("a"))
                {
                    m_rigidbody.velocity += m_transform.TransformDirection(Vector3.left * m_acceleration) * Time.fixedDeltaTime;
                }
                if (Input.GetKey("s"))
                {
                    m_rigidbody.velocity += m_transform.TransformDirection(Vector3.back * m_acceleration) * Time.fixedDeltaTime;
                }
                if (Input.GetKey("d"))
                {
                    m_rigidbody.velocity += m_transform.TransformDirection(Vector3.right * m_acceleration) * Time.fixedDeltaTime;
                }
                break;
            case InputStatus.SmartPhone:

                break;
        }
    }

    /// <summary>
    /// 入力状態
    /// </summary>
    enum InputStatus
    {
        PC,
        SmartPhone
    }
}
