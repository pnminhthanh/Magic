using Magic.Game;
using Magic.Skill;
using Magic.SkillEffect;
using Magic.Character;
using System;
using Magic.Game.Battle;

namespace Magic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);
            GameLoop game = new GameLoop();
            HomeView homeview = new HomeView();
            SkillEffectManager skillEffectManager = new SkillEffectManager();
            SkillManager skillManager = new SkillManager();
            SkillEffectView skillEffectView = new SkillEffectView(homeview, skillEffectManager);
            CharacterManager characterManager = new CharacterManager();
            SkillView skillView = new SkillView(homeview, skillManager, skillEffectManager, skillEffectView);
            CharacterView characterView = new CharacterView(characterManager, skillManager, homeview, skillView);
            BattleController battleController = new BattleController();
            BattleView battleView = new BattleView(homeview, characterView, battleController, characterManager);
            homeview.ShowListFunction();
            Console.ReadKey();
        }
    }
}
