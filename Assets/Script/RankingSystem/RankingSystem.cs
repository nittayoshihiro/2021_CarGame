using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    RaceTimes m_currentRaceTimes = null;
    static string m_rankingName = "RankingData";

    void Awake()
    {
        Debug.Log(FileController.GetFilePath(m_rankingName));
        //データがないとき
        if (!File.Exists(FileController.GetFilePath(m_rankingName)))
        {
            Debug.Log($"{FileController.GetFilePath(m_rankingName)}のファイルが見つかりませんでした。ファイルを作ります");
            RaceDataClear();
        }
    }

    void Start()
    {
        m_currentRaceTimes = LoadRanking();   
    }

    public void SaveRanking(RaceTimes raceTimes)
    {
        FileController.TextSave(m_rankingName,JsonUtility.ToJson(raceTimes));
    }

    public RaceTimes LoadRanking()
    {
        RaceTimes m_raceTime = JsonUtility.FromJson<RaceTimes>(FileController.TextLoad(m_rankingName));
        return m_raceTime;
    }

    public void RaceDataClear()
    {
        RaceTimes resultData = new RaceTimes(99, 99, 99);
        FileController.TextSave(m_rankingName, JsonUtility.ToJson(resultData));
    }
}

[Serializable]public class RaceTimes
{
    [SerializeField] public float firstPlase;
    [SerializeField] public float secondPlase;
    [SerializeField] public float thirdPlase;

    public RaceTimes(float first ,float second ,float third)
    {
        firstPlase = first;
        secondPlase = second;
        thirdPlase = third;
    }
}
