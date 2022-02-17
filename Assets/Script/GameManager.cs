
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_player = null;
    [SerializeField] GoalGate m_goalGate = null;
    [SerializeField] GameObject m_camera = null;
    [SerializeField] GameObject m_items = null;
    [SerializeField] GameObject m_gameOver = null;
    private GameObject[] m_childObject;
    AudioController m_audioController = null;
    GameSceneBase m_gameSceneBase = null;
    InGameState m_inGameState = null;
    ResultState m_resultState = null;
    TitleState m_titleState = null;
    Text m_gameover = null;
    static string m_filename = "RankingData";
    public float m_time = 0f;
    private Vector3 m_itempos;
    private Quaternion m_quaternion;

    [RuntimeInitializeOnLoadMethod()]
    static void BeforInit()
    {
        if (!File.Exists(FileController.GetFilePath(m_filename)))
        {
            Debug.Log($"");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_audioController = GetComponent<AudioController>();
        m_inGameState = FindObjectOfType<InGameState>();
        m_resultState = FindObjectOfType<ResultState>();
        m_titleState = FindObjectOfType<TitleState>();
        m_gameSceneBase = m_titleState;
        m_gameSceneBase.OnEnter(m_gameSceneBase);
        m_childObject = new GameObject[m_items.transform.childCount];

        for (int i = 0; i < m_items.transform.childCount; i++)
        {
            m_childObject[i] = m_items.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_gameSceneBase.OnUpdata(m_gameSceneBase);
    }

    public void NextState(GameSceneBase nextState)
    {
        m_gameSceneBase.OnExit(m_gameSceneBase);
        m_gameSceneBase = nextState;
        m_gameSceneBase.OnEnter(m_gameSceneBase);
    }

    public void StartButton()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < m_childObject.Length; i++)
        {
            if (!m_childObject[i].active)
            {
                m_childObject[i].SetActive(true);
            }
            
            m_itempos = m_childObject[i].transform.position;
            m_itempos.x = random.Next(-5, 5);
            m_childObject[i].transform.position = m_itempos;
        }
        m_player.transform.position = new Vector3(0, 0, -970);
        m_player.transform.rotation = m_quaternion;
        m_quaternion.x = 0f;
        m_quaternion.y = 0f;
        m_quaternion.z = 0f;
        m_player.transform.rotation = m_quaternion;
        m_player.SetActive(true);
        m_audioController.GameBGM();
        NextState(m_inGameState);
    }

    public void GameOver()
    {
        m_gameOver.SetActive(true);
        m_gameover.DOFade(1, 1f).OnComplete(() =>
        {
            m_gameover.color =
            new Color(m_gameover.color.r, m_gameover.color.g, m_gameover.color.g, 0f); ;
            m_gameOver.SetActive(false);
        });
    }

    public void Goal()
    {
        m_audioController.ResultBGM();
        NextState(m_resultState);
    }

    public void ResultButton()
    {
        if (m_gameOver.active)
        {
            m_gameOver.SetActive(false);
        }
        
        m_audioController.TiteBGM();
        m_goalGate.Clear();
        m_player.SetActive(false);
        NextState(m_titleState);
    }
}
