using System;
using UnityEngine;


public delegate void CompleteEvent();
public delegate void UpdateEvent(float t);

public class Timer : MonoBehaviour
{
    bool isLog = true;
    //Action _updateEvent;
    UpdateEvent updateEvent;
    //Action<float> ac;
    CompleteEvent onCompleted;

    float timeTarget;   // 计时时间/

    float timeStart;    // 开始计时时间/

    float timeNow;     // 现在时间/

    float offsetTime;   // 计时偏差/

    bool isTimer;       // 是否开始计时/

    bool isDestory = true;     // 计时结束后是否销毁/

    bool isEnd;         // 计时是否结束/

    bool isIgnoreTimeScale = true;  // 是否忽略时间速率

    bool isRepeate;

    float Time_
    {
        get { return isIgnoreTimeScale ? Time.realtimeSinceStartup : Time.time; }
    }
    float now;
    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            timeNow = Time_ - offsetTime;
            now = timeNow - timeStart;
            if (updateEvent != null)
                updateEvent(Mathf.Clamp01(now / timeTarget));
            if (now > timeTarget)
            {
                if (onCompleted != null)
                    onCompleted();
                if (!isRepeate)
                    StopTimer();
                else
                    RestartTimer();
            }
        }
    }


    public float GetLeftTime()
    {
        return Mathf.Clamp(timeTarget - now, 0, timeTarget);
    }


    void OnApplicationPause(bool isPause_)
    {
        if (isPause_)
        {
            PauseTimer();
        }
        else
        {
            ContinueTimer();
        }
    }

    /// <summary>
    /// 计时结束
    /// </summary>
    public void StopTimer()
    {
        isTimer = false;
        isEnd = true;
        if (isDestory)
            Destroy(gameObject);
    }


    float _pauseTime;
    /// <summary>
    /// 暂停计时
    /// </summary>
    public void PauseTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("计时已经结束！");
        }
        else
        {
            if (isTimer)
            {
                isTimer = false;
                _pauseTime = Time_;
            }
        }
    }
    /// <summary>
    /// 继续计时
    /// </summary>
    public void ContinueTimer()
    {
        if (isEnd)
        {
            if (isLog) Debug.LogWarning("计时已经结束！请从新计时！");
        }
        else
        {
            if (!isTimer)
            {
                offsetTime += (Time_ - _pauseTime);
                isTimer = true;
            }
        }
    }
    public void RestartTimer()
    {
        timeStart = Time_;
        offsetTime = 0;
    }

    public void ChangeTargetTime(float time_)
    {
        timeTarget += time_;
    }

    

    /// <summary>
    /// 开始计时 : 
    /// </summary>
    public void StartTiming(float duration, CompleteEvent _onCompleted, UpdateEvent update = null, bool _isIgnoreTimeScale = true, bool _isRepeate = false, bool _isDestory = true)
    {
        timeTarget = duration;
        if (_onCompleted != null)
            onCompleted = _onCompleted;
        if (update != null)
            updateEvent = update;
        isDestory = _isDestory;
        isIgnoreTimeScale = _isIgnoreTimeScale;
        isRepeate = _isRepeate;

        timeStart = Time_;
        offsetTime = 0;
        isEnd = false;
        isTimer = true;

    }
    /// <summary>
    /// 创建计时器:名字
    /// </summary>
    public static Timer CreateTimer(string gobjName = "Timer")
    {
        GameObject g = new GameObject(gobjName);
        Timer timer = g.AddComponent<Timer>();
        return timer;
    }

}


    

