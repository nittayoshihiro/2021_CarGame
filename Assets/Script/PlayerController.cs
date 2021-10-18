using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputStatus m_inputStatus = InputStatus.PC;
    [SerializeField] float m_power = 20;
    [SerializeField] float m_rotaionpower = 0.5f;
    [SerializeField] float m_jumppower = 1;
    Transform m_transform;
    Rigidbody m_rigidbody;
    /// <summary>地面についているか</summary>
    bool m_ground = true;

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
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Mouse0))
                {
                    GasPedal();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    RightRotaion();
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Mouse1))
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
        m_rigidbody.velocity += m_transform.TransformDirection(Vector3.forward * m_power) * Time.fixedDeltaTime / m_rigidbody.mass;
    }

    /// <summary>右回転</summary>
    void RightRotaion()
    {
        if (m_rigidbody.velocity != Vector3.zero)
        {
            m_transform.Rotate(Vector3.down * m_rotaionpower);
        }
    }

    /// <summary>左回転</summary>
    void LeftRotaion()
    {
        if (m_rigidbody.velocity != Vector3.zero)
        {
            m_transform.Rotate(Vector3.up * m_rotaionpower);
        }
    }

    /// <summary>バック（後進）</summary>
    void BackPedal()
    {
        //前進のパワーの1.5倍
        m_rigidbody.velocity += m_transform.TransformDirection(Vector3.back * m_power) * Time.fixedDeltaTime / m_rigidbody.mass;
    }

    /// <summary>ジャンプ</summary>
    void Jump()
    {
        if (m_ground)
        {
            m_rigidbody.velocity = Vector3.up * m_jumppower;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //地面触れた時
        if (collision.gameObject.tag == ("Map"))
        {
            m_ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //地面を離れた時
        if (collision.gameObject.tag == ("Map"))
        {
            m_ground = false;
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
