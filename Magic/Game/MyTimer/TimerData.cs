using System;

namespace Magic.Game.MyTimer
{
    class TimerData
    {
        public float targetTime;
        public Action callBack;

        public TimerData(float startTime, Action callBack)
        {
            this.targetTime = startTime;
            this.callBack = callBack;
        }
    }
}
