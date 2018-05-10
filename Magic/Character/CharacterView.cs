using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Character;
using Magic.Skill;
using Magic.Tools;

namespace Magic.Character
{
    class CharacterView
    {
        public LearnSkillController controller;
        public CharacterManager characterManager;
        public SkillManager skillManager;
        public HomeView homeview;
        public SkillView skillview;

        public CharacterView(CharacterManager characterManager, SkillManager skillManager, HomeView homeview, SkillView skillview)
        {
            controller = new LearnSkillController(skillManager, characterManager);
            this.characterManager = characterManager;
            this.skillManager = skillManager;
            this.skillview = skillview;
            this.homeview = homeview;
            homeview.CallCharacterView += CharacterCreation;
            homeview.CallLearnSKill += LearnSkillView;
        }

        public void CharacterCreation()
        {
            Console.WriteLine(MyLocalization.GetText("Creation Character View"));
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Character's name"), 50));
            string name = Console.ReadLine();
            Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Character's HP"), 50));
            float hp = float.Parse(Console.ReadLine());
            Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Character's MP"), 50));
            float mp = float.Parse(Console.ReadLine());
            Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Character's HP Regen"), 50));
            float hpRegen = float.Parse(Console.ReadLine());
            Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Character's MP Regen"), 50));
            float mpRegen = float.Parse(Console.ReadLine());
            characterManager.CreateCharacter(name, hp, mp, hpRegen, mpRegen);
            Console.WriteLine(MyLocalization.GetText("Created and saved successfully!"));
        }

        public void PrintListCharacter()
        {
            Console.WriteLine("List of Characters");
            Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("ID"), 10) + Ultils.FormatText(MyLocalization.GetText("Character's name"), 50));
            foreach (var character in characterManager.GetList())
            {
                PrintCharacter(character.Value);
            }
        }

        public void PrintCharacter(CharacterProperties character)
        {
            Console.WriteLine(Ultils.FormatText(character.id.ToString(), 10) + Ultils.FormatText(character.characterName, 25) + Ultils.FormatText(character.hp.ToString()) + Ultils.FormatText(character.mp.ToString()));
        }

        public void LearnSkillView()
        {
            PrintListCharacter();
            Console.Write(MyLocalization.GetText("Choose a character to learn skill: "));
            int idCharacter = Int16.Parse(Console.ReadLine());
            skillview.PrintListSkill();
            Console.Write(MyLocalization.GetText("\nChoose a skill to learn"));
            int idSkill = Int16.Parse(Console.ReadLine());
            if (controller.LearnSkill(idCharacter, idSkill))
                Console.WriteLine(MyLocalization.GetText("Learnt Successfully!!"));
            else Console.WriteLine(MyLocalization.GetText("The character has already learnt this skill"));
        }
    }
}
