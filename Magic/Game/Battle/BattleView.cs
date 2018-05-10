using Magic.Character;
using Magic.Skill;
using Magic.Tools;
using Magic.SkillEffect;
using System;

namespace Magic.Game.Battle
{
    class BattleView
    {
        public HomeView homeView;
        public CharacterView characterView;
        public BattleController battleController;
        public CharacterManager characterManager;
        int width = Console.WindowWidth, height = Console.WindowHeight;
        int top = 1, left = 4;
        int cursorTop;
        private static object syncLock = new object();

        public BattleView(HomeView homeView, CharacterView characterView, BattleController battleController, CharacterManager characterManager)
        {
            this.homeView = homeView;
            this.characterView = characterView;
            this.battleController = battleController;
            this.characterManager = characterManager;
            homeView.CallBattleView += ChooseCharacterView;
            battleController.UseSkillCallBack += UseSkill;
            battleController.UpdateHpAndMpCallBack += UpdateHPAndMP;
            battleController.RegenHpAndMpCallBack += RegenHpAndMp;
            battleController.EndBattleCallBack += EndBattle;
            battleController.UpdateHpAndMpCallBack += UpdateHPAndMP;
            battleController.SkillAttackCallBack += Attack;
        }

        public void ChooseCharacterView()
        {
            
            Console.Clear();
            characterView.PrintListCharacter();
            Console.Write(MyLocalization.GetText("Please choose a player (Enter the ID):  "));
            int idCharacter1 = int.Parse(Console.ReadLine());
            Console.Write(MyLocalization.GetText("Please choose a player (Enter the ID):  "));
            int idCharacter2 = int.Parse(Console.ReadLine());
            CharacterProperties dataPlayer1 = characterManager.GetCharater(idCharacter1);
            CharacterProperties dataPlayer2 = characterManager.GetCharater(idCharacter2);
            StartBattle(dataPlayer1, dataPlayer2);
        }

        private void StartBattle(CharacterProperties dataPlayer1, CharacterProperties dataPlayer2)
        {
            Console.Clear();
            PrintInfoPlayer(dataPlayer1, dataPlayer2);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.CursorTop + 3);
            Console.WriteLine("THE BATTLE BEGIN\n");
            battleController.Battle(dataPlayer1, dataPlayer2);
            cursorTop = Console.CursorTop;
            Console.ReadKey();
        }

        public void PrintInfoPlayer(CharacterProperties dataPlayer1, CharacterProperties dataPlayer2)
        {
            //Player 1 Info
            Ultils.Border(40, 6, left, top);
            Console.SetCursorPosition(left + 10, top + 2);
            Console.WriteLine(MyLocalization.GetText("Player 1"));
            Console.SetCursorPosition(left + 3, Console.CursorTop);
            Console.WriteLine(Ultils.FormatText((MyLocalization.GetText("Name")), 20) + "\t" + dataPlayer1.characterName);
            Console.SetCursorPosition(left + 3, Console.CursorTop);
            Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("HP:   "), 10) + dataPlayer1.hp + "\t" + Ultils.FormatText(MyLocalization.GetText("MP:   "), 10) + dataPlayer1.mp);
   
            //Player 2 Info
            left = width / 2 + 10;
            Ultils.Border(40, 6, left, top);
            Console.SetCursorPosition(left + 10, top + 2);
            Console.WriteLine(MyLocalization.GetText("Player 2"));
            Console.SetCursorPosition(left + 3, Console.CursorTop);
            Console.WriteLine(Ultils.FormatText((MyLocalization.GetText("Name")), 20) + "\t" + dataPlayer2.characterName);
            Console.SetCursorPosition(left + 3, Console.CursorTop);
            Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("HP:   "), 10) + dataPlayer2.hp + "\t" + Ultils.FormatText(MyLocalization.GetText("MP:   "), 10) + dataPlayer2.mp);
        }
        public void UpdateHPAndMP(CharacterBattleData player1, CharacterBattleData player2)
        {
            lock (syncLock)
            {
                Console.SetCursorPosition(7, 5);
                Console.Write(Ultils.FormatText(MyLocalization.GetText("HP:   "), 10) + player1.hp + "\t" + Ultils.FormatText(MyLocalization.GetText("MP:   "), 10) + player1.mp);
                Console.SetCursorPosition(left + 3, 5);
                Console.Write(Ultils.FormatText(MyLocalization.GetText("HP:   "), 10) + player2.hp + "\t" + Ultils.FormatText(MyLocalization.GetText("MP:   "), 10) + player2.mp);
            }                
        }

        private void UseSkill(CharacterBattleData player, SkillData skill)
        {
            lock (syncLock) {
                Console.SetCursorPosition(width / 2 - 20, cursorTop);
                Console.WriteLine("Player {0} used {1}\n", player.characterProperties.characterName, skill.skillName);
                cursorTop = Console.CursorTop;
            }           
        }

        private void Attack(CharacterBattleData player, SkillEffectData skill)
        {
            lock (syncLock)
            {
                Console.SetCursorPosition(width / 2 - 20, cursorTop);
                Console.WriteLine("Player {0} get {1} damage\n", player.characterProperties.characterName, skill.effectValue);
                cursorTop = Console.CursorTop;
            }
        }

        private void Healer(CharacterBattleData player)
        {
            lock (syncLock)
            {
                Console.SetCursorPosition(width / 2 - 20, cursorTop);

                Console.WriteLine("Player {0} heal: hp = {1},  mp = {2}\n", player.characterProperties.characterName, player.hp, player.mp);
                cursorTop = Console.CursorTop;
            }                
        }

        private void RegenHpAndMp(CharacterBattleData player)
        {
            lock (syncLock)
            {
                Console.SetCursorPosition(width / 2 - 20, cursorTop);
                Console.WriteLine("Player {0} has regenerated HP and MP\n", player.characterProperties.characterName);
                cursorTop = Console.CursorTop;
            }                
        }

        private void EndBattle(CharacterBattleData winPlayer, CharacterBattleData lostPlayer)
        {
            lock (syncLock)
            {
                Console.SetCursorPosition(width / 2 - 20, cursorTop);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The WINNER is {0}, the LOSER is {1}", winPlayer.characterProperties.characterName, lostPlayer.characterProperties.characterName);
            }
        }    
    }
}
