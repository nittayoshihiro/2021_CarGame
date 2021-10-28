using System.Collections;
using UnityEngine;

/// <summary>
/// プレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_power = 20;
    [SerializeField] float m_rotaionpower = 0.5f;
    [SerializeField] float m_jumptime = 1;
    [SerializeField] GameObject m_SmartPhoneCanvas = null;//後に読み取りで動作するようにする
    Coroutine m_coroutine;
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
        m_BasePlayerController =  this.gameObject.AddComponent<PC_Input>();
#elif UNITY_ANDROID
        m_BasePlayerController = Instantiate(m_SmartPhoneCanvas).GetComponent<SmartPhone_Input>();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        m_BasePlayerController.PlayerUpdate();
        if (m_BasePlayerController.GetGasPedal)
        {
            GasPedal();
        }
        if (m_BasePlayerController.GetRightRotation)
        {
            RightRotaion();
        }
        if (m_BasePlayerController.GetLeftRotation)
        {
            LeftRotaion();
        }
        if (m_BasePlayerController.GetBackPedal)
        {
            BackPedal();
        }
        if (m_BasePlayerController.GetJump)
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
        if (!m_ground && m_rigidbody.velocity != Vector3.zero)
        {
            //ドリフト処理
        }
        else if (m_rigidbody.velocity != Vector3.zero)
        {
            m_transform.Rotate(Vector3.down * m_rotaionpower);
        }
    }

    /// <summary>左回転</summary>
    void LeftRotaion()
    {
        if (!m_ground && m_rigidbody.velocity != Vector3.zero)
        {
            //ドリフト処理
        }
        else if (m_rigidbody.velocity != Vector3.zero)
        {
            m_transform.Rotate(Vector3.up * m_rotaionpower);
        }
    }

    /// <summary>バック（後進）</summary>
    void BackPedal()
    {
        m_rigidbody.velocity += m_transform.TransformDirection(Vector3.back * m_power) * Time.fixedDeltaTime / m_rigidbody.mass;
    }

    /// <summary>ジャンプ</summary>
    void Jump()
    {
        if (m_ground)
        {
            m_ground = false;
            m_coroutine = StartCoroutine(JumpNow(m_jumptime));
        }
    }

    /// <summary>
    /// 飛んでいる間
    /// </summary>
    /// <param name="waittime">飛んでいる時間</param>
    /// <returns></returns>
    IEnumerator JumpNow(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        m_ground = true;
    }
}