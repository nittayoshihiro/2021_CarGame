using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_power = 20;
    [SerializeField] float m_rotaionpower = 0.5f;
    [SerializeField] float m_jumppower = 1;
    [SerializeField] GameObject m_SmartPhoneCanvas = null;//後に読み取りで動作するようにする
    Transform m_transform;
    Rigidbody m_rigidbody;
    BasePlayerController m_BasePlayerController;

    /// <summary>地面についているか</summary>
    bool m_ground = true;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.GetComponent<Transform>();
        m_rigidbody = this.GetComponent<Rigidbody>();

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        m_BasePlayerController = new PC_Input();
#elif UNITY_ANDROID
        Instantiate(m_SmartPhoneCanvas);
        m_BasePlayerController = m_SmartPhoneCanvas.GetComponent<SmartPhone_Input>();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        m_BasePlayerController.PlayerUpdate();
        if (m_BasePlayerController.GetGasPedal())
        {
            GasPedal();
        }
        if (m_BasePlayerController.GetRightRotation())
        {
            RightRotaion();
        }
        if (m_BasePlayerController.GetLeftRotation())
        {
            LeftRotaion();
        }
        if (m_BasePlayerController.GetBackPedal())
        {
            BackPedal();
        }
        if (m_BasePlayerController.GetJump())
        {
            Jump();
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
}