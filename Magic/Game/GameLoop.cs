using Magic.Game.MyTimer;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Magic.Game
{
    public class GameLoop
    {
        private GameTimer myTimer;
        private List<BaseTimer> listTimer;
        private long lastTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        public static GameLoop Instance;

        public GameLoop()
        {
            Instance = this;
            listTimer = new List<BaseTimer>();
            myTimer = new GameTimer();
            listTimer.Add(myTimer);
            RunLoop();
        }

        public void RunLoop()
        {
            Timer TheTimer = null;
            TheTimer = new Timer(
                this.Tick, null, 0, 10);
        }

        public void Tick(object info)
        {
            Update();
        }

        public void JoinTimer(BaseTimer timer)
        {
            listTimer.Add(timer);
        }

        public void RemoveTimer(BaseTimer timer)
        {
            listTimer.Remove(timer);
        }

        private void Update()
        {
            long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long deltaTime = currentTime - lastTime;
            for (int i = listTimer.Count - 1; i >= 0; i--)
            {
                listTimer[i].UpdateTime((float)(deltaTime / 1000f));
            }
            lastTime = currentTime;
        }
    }
}
