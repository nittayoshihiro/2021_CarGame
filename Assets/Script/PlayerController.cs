using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputStatus m_inputStatus = InputStatus.PC;
    [SerializeField] float m_power = 30;
    [SerializeField] float m_jumppower = 2;
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
                if (Input.GetKey(KeyCode.W))
                {
                    GasPedal();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    RightRotaion();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    BackPedal();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    LeftRotaion();
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
                break;
            case InputStatus.SmartPhone:

                break;
        }
    }

    /// <summary>アクセル（前進）</summary>
    void GasPedal()
    {
        m_rigidbody.velocity += m_transform.TransformDirection(Vector3.forward * m_power) * Time.fixedDeltaTime;
    }

    /// <summary>右回転</summary>
    void RightRotaion()
    {
        m_transform.Rotate(Vector3.down);
    }

    /// <summary>左回転</summary>
    void LeftRotaion()
    {
        m_transform.Rotate(Vector3.up);
    }

    /// <summary>バック（後進）</summary>
    void BackPedal()
    {
        m_rigidbody.velocity += m_transform.TransformDirection(Vector3.back * m_power) * Time.fixedDeltaTime;
    }

    /// <summary>ジャンプ</summary>
    void Jump()
    {
        m_rigidbody.velocity = Vector3.up * m_jumppower;
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
