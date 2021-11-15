using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleResultSceen : MonoBehaviour
{
    /// <summary>ゲームの状況</summary>
    SceneTransition sceneTransition = new SceneTransition();
    State state;
    OrbitManagement orbit;
    public GameObject startUI;
    public GameObject resultUI;
    public float raceTime_s;
    public float raceTime_m;
    public Text timeText;
    public bool sceenCheng;
    private void Start()
    {
        startUI = GameObject.Find("Title");
        resultUI = GameObject.Find("Result");
        state = sceneTransition;
        state.OnEnter(state, this);
        orbit = FindObjectOfType<OrbitManagement>();
    }
    public void Update()
    {
        if (sceenCheng == true)
        {
            raceTime_s += Time.deltaTime;
            //timeText.text = raceTime_m + ":" + raceTime_s.ToString("F2");
            timeText.text = string.Format("{0:00}",raceTime_m)+":"+string.Format("{0:00.00}",raceTime_s);
            if (raceTime_s >= 59.9f)
            {
                raceTime_m += 1;
                raceTime_s -= 59.9f;
            }
            state.OnUpdate(state, this);
            if (orbit.WeekNum == 4)
            {
                sceenCheng = false;
                state.OnExit(state,this);
                orbit.Reset();
            }
        }
        
    }
    public void Reset()
    {
        raceTime_s = 0;
        raceTime_m = 0;
        state.OnEnter(state, this);
    }
    public void Cheng(State NextState)
    {
        state.OnExit(state, this);
        state = NextState;
        state.OnEnter(state, this);
    }
}
