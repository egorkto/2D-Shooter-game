using UnityEngine;

public class Timer
{
    public bool timeIsUp { get; private set; } = true;

    private TimerCondition timerCondition;
    private float remainedTime;

    public void TimerUpdate()
    {
        if(remainedTime <= 0)
        {
            timeIsUp = true;
            timerCondition = TimerCondition.Free;
        }
        else
        {
            remainedTime -= Time.deltaTime;
        }
    }

    public void StartTimer(float time)
    {
        if(timerCondition == TimerCondition.Free)
        {
            remainedTime = time;
            timeIsUp = false;
            timerCondition = TimerCondition.Busy;
        }
        else
        {
            Debug.LogError("Timer is busy!");
        }
    }

    enum TimerCondition
    {
        Busy,
        Free
    }
}
