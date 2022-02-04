using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultState : MonoBehaviour, GameSceneBase
{
    [SerializeField] GameObject m_resultCanvas = null;
    [SerializeField] Text m_RankingText = null;
    RankingSystem m_rankingSystem = null;
    RaceTimes m_raceTimes = null;
    GameManager m_gameManager = null;

    public void OnEnter(GameSceneBase gameSceneBase)
    {
        m_resultCanvas.SetActive(true);
        m_gameManager = FindObjectOfType<GameManager>();
        m_rankingSystem = FindObjectOfType<RankingSystem>();
        m_raceTimes = m_rankingSystem.LoadRanking();

        if (m_raceTimes.firstPlase > m_gameManager.m_time)
        {
            m_raceTimes.thirdPlase = m_raceTimes.secondPlase;
            m_raceTimes.secondPlase = m_raceTimes.firstPlase;
            m_raceTimes.firstPlase = m_gameManager.m_time;
            m_rankingSystem.SaveRanking(m_raceTimes);
            m_RankingText.text = ResultText(m_raceTimes, 1);
        }
        else if (m_raceTimes.secondPlase > m_gameManager.m_time)
        {
            m_raceTimes.thirdPlase = m_raceTimes.secondPlase;
            m_raceTimes.secondPlase = m_gameManager.m_time;
            m_rankingSystem.SaveRanking(m_raceTimes);
            m_RankingText.text = ResultText(m_raceTimes, 2);
        }
        else if (m_raceTimes.thirdPlase > m_gameManager.m_time)
        {
            m_raceTimes.thirdPlase = m_gameManager.m_time;
            m_rankingSystem.SaveRanking(m_raceTimes);
            m_RankingText.text = ResultText(m_raceTimes, 3);
        }
        else
        {
            m_RankingText.text = ResultText(m_raceTimes,0);
        }
    }

    public void OnUpdata(GameSceneBase gameSceneBase)
    {

    }

    public void OnExit(GameSceneBase gameSceneBase)
    {
        m_resultCanvas.SetActive(false);
    }

    string ResultText(RaceTimes raceTimes, int rankingNum)
    {
        string resultText = null; ;
        switch (rankingNum)
        {
            case 0:
                resultText = string.Format("Time:{0:00.00}\n1位{1:00.00}\n2位{2:00.00}\n3位{3:00.00}",
                    m_gameManager.m_time, m_raceTimes.firstPlase, m_raceTimes.secondPlase, m_raceTimes.thirdPlase);
                break;
            case 1:
                resultText = string.Format("Time:{0:00.00}\n<color=#ffff00>1位{1:00.00}</color>\n2位{2:00.00}\n3位{3:00.00}",
                    m_gameManager.m_time, m_raceTimes.firstPlase, m_raceTimes.secondPlase, m_raceTimes.thirdPlase);
                break;
            case 2:
                resultText = string.Format("Time:{0:00.00}\n1位{1:00.00}\n<color=#ffff00>2位{2:00.00}</color>\n3位{3:00.00}",
                    m_gameManager.m_time, m_raceTimes.firstPlase, m_raceTimes.secondPlase, m_raceTimes.thirdPlase);
                break;
            case 3:
                resultText = string.Format("Time:{0:00.00}\n1位{1:00.00}\n2位{2:00.00}\n<color=#ffff00>3位{3:00.00}</color>",
                    m_gameManager.m_time, m_raceTimes.firstPlase, m_raceTimes.secondPlase, m_raceTimes.thirdPlase);
                break;
        }


        return resultText;
    }
}
