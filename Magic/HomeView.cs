using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class HomeView
    {
        public delegate void CallView();
        public CallView CallCharacterView, CallSkillView, CallSkillEffectView, CallLearnSKill, CallBattleView;

        public HomeView()
        {

        }
        
        public void ShowListFunction()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nChoose the function:\n\n");
                Console.WriteLine("1. Create new character\n");
                Console.WriteLine("2. Create new skill\n");
                Console.WriteLine("3. Create new skill effect\n");
                Console.WriteLine("4. Learn skill\n");
                Console.WriteLine("5. Battle\n");
                Console.WriteLine("Press 'Esc' to exit");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        CallCharacterView.Invoke();
                        break;
                    case ConsoleKey.D2:
                        CallSkillView.Invoke();
                        break;
                    case ConsoleKey.D3:
                        CallSkillEffectView.Invoke();
                        break;
                    case ConsoleKey.D4:
                        CallLearnSKill.Invoke();
                        break;
                    case ConsoleKey.D5:
                        CallBattleView.Invoke();
                        break;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Console.WriteLine("You entered the unvailable value. Please re-enter");
                        continue;
                }
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
        }


    }
}
