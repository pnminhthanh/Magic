using System;
using System.Collections.Generic;

namespace Magic.Game.MyTimer
{
    public class GameTimer : BaseTimer
    {
        private float currentTime;
        private List<TimerData> listAction;
        public static GameTimer Instance;

        public GameTimer()
        {
            Instance = this;
            listAction = new List<TimerData>();
        }

        public void AddTimer(float countTime, Action action)
        {
            TimerData timerData = new TimerData(currentTime + countTime, action);
            listAction.Add(timerData);
        }

        public override void UpdateTime(float deltaTime)
        {
            currentTime += deltaTime;
            for(int i = listAction.Count-1; i >=0; i--)
            {
                if(currentTime >= listAction[i].targetTime)
                {
                    listAction[i].callBack.Invoke();
                    listAction.RemoveAt(i);
                }
            }
        }
    }
}
