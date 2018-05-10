using Magic.Enum;
using Magic.SkillEffect;
using Magic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Skill
{
    class SkillView
    {
        public HomeView homeview;
        public SkillManager skillManager;
        public CreationSkillController adapter;
        public SkillEffectView skillEffectView;

        public SkillView(HomeView homeview, SkillManager skillManager, SkillEffectManager skillEffectManager, SkillEffectView skillEffectView)
        {
            this.homeview = homeview;
            this.skillManager = skillManager;
            this.skillEffectView = skillEffectView;
            this.adapter = new CreationSkillController(skillManager, skillEffectManager);
            homeview.CallSkillView += CreatNewSkillView;
        }
        
        public void CreatNewSkillView()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MyLocalization.GetText("Creation Skill View") + "\n\n");
                Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Skill Name"), 45));
                string skillName = Console.ReadLine();
                Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Description"), 45));
                string description = Console.ReadLine();
                skillEffectView.PrintListSkillEffect();                              
                List<int> listIdSkillEffect = new List<int>();
                while (true)
                {
                    Console.Write(MyLocalization.GetText("Choose Skill Effect (Enter Value):"));
                    int idSkillEffect = int.Parse(Console.ReadLine());                    
                    listIdSkillEffect.Add(idSkillEffect);
                    Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("Press 'Enter' continue to enter, press any key to exit"), 45));
                    ConsoleKeyInfo keyconfirm = Console.ReadKey();
                    if (keyconfirm.Key != ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Time Used:"), 45));
                float timeUsed = float.Parse(Console.ReadLine());
                Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Time Cool Down:"), 45));
                float timeCoolDown = float.Parse(Console.ReadLine());
                Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter MP Used:"), 45));
                int mpUsed = int.Parse(Console.ReadLine());
                adapter.CreateNewSkill(skillName, description, listIdSkillEffect.ToArray(), timeUsed, timeCoolDown, mpUsed, 1);
                Console.WriteLine(MyLocalization.GetText("Created and saved successfully!"));
                Console.WriteLine(MyLocalization.GetText("Press 'Enter' continue to enter, press any key to exit"));
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void PrintListSkill()
        {
            Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("ID"), 10) + Ultils.FormatText(MyLocalization.GetText("Skill Name"), 25) + Ultils.FormatText(MyLocalization.GetText("Description"), 20) + Ultils.FormatText(MyLocalization.GetText("Magic Value")) + Ultils.FormatText(MyLocalization.GetText("Time Cool Down")) + Ultils.FormatText(MyLocalization.GetText("MP Used"), 10) + "\n");
            foreach (var item in skillManager.GetList())
            {
                PrintSkill(item.Value);
            }
        }

        public void PrintSkill(SkillData skill)
        {
            Console.WriteLine("\n" + Ultils.FormatText(skill.id.ToString(), 10) + Ultils.FormatText(skill.skillName, 25) + Ultils.FormatText(skill.description, 20)  + Ultils.FormatText(skill.timeUsed.ToString()) + Ultils.FormatText(skill.timeCooldown.ToString()) + Ultils.FormatText(skill.mpUsed.ToString()));
            Console.WriteLine(MyLocalization.GetText("Skill Effect"));
            PrintEffectOfSKill(skill);
        }

        public void PrintEffectOfSKill(SkillData skill)
        {
            for (int i = 0; i < skill.listSkillEffect.Length; i++) 
            {
                if (skill.listSkillEffect[i] != null)
                {
                    Console.WriteLine((i + 1) + ".\tType Action: {0}\tType Effect: {1}\tLevel Skill Effect:{2}\tEffect Value: {3}\n\tTime Exist: {4}s\t Ratio Success:{5}\tTime Distance:{6}s\tRatio Out Break:{7}", skill.listSkillEffect[i].typeAction.ToString(), skill.listSkillEffect[i].typeEffect.ToString(), skill.listSkillEffect[i].levelSkillEffect.ToString(), skill.listSkillEffect[i].effectValue.ToString(), skill.listSkillEffect[i].timeExist.ToString(), skill.listSkillEffect[i].ratioSuccess.ToString(), skill.listSkillEffect[i].timeDistance.ToString(), skill.listSkillEffect[i].ratioOutbreak.ToString());
                }                
            }
        }
    }
}
