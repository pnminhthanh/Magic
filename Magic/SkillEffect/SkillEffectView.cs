using Magic.Enum;
using Magic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.SkillEffect
{
    class SkillEffectView
    {
        public SkillEffectManager skillEffectManager;
        public HomeView homeview;

        public SkillEffectView(HomeView homeview, SkillEffectManager skillEffectManager)
        {
            this.homeview = homeview;
            this.skillEffectManager = skillEffectManager;
            homeview.CallSkillEffectView += CreatNewSkillEffectView;            
        }
        
        public void CreatNewSkillEffectView()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MyLocalization.GetText("Creation Skill Effect View") + "\n\n");
                for (int i = -3; i < 3; i++)
                {
                    ESkillEffect type = (ESkillEffect)i;
                    Console.WriteLine(type.ToString() + " : " + i);
                }
                Console.Write("\n" + Ultils.FormatText(MyLocalization.GetText("Choose Type Action (Enter Value):"), 45));
                ESkillEffect typeAction = (ESkillEffect)int.Parse(Console.ReadLine());
                for (int i = 0; i < 4; i++)
                {
                    ETypeEffect type = (ETypeEffect)i;
                    Console.WriteLine(type.ToString() + " : " + i);
                }
                Console.Write("\n" + Ultils.FormatText(MyLocalization.GetText("Choose Type Effect (Enter Value)"), 45));
                ETypeEffect typeEffect = (ETypeEffect)int.Parse(Console.ReadLine());
                Console.Write(Ultils.FormatText(MyLocalization.GetText("Enter Level Skill Effect:"), 45));
                int levelSkillEffect = int.Parse(Console.ReadLine());
                Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("Enter Effect Value:"), 45));
                float effectValue = float.Parse(Console.ReadLine());
                Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("Enter Time Exist:"), 45));
                float timeExist = float.Parse(Console.ReadLine());
                Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("Enter Ratio Success:"), 45));
                float ratioSuccess = float.Parse(Console.ReadLine());
                Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("Enter Time Distance:"), 45));
                float timeDistance = float.Parse(Console.ReadLine());
                Console.WriteLine(Ultils.FormatText(MyLocalization.GetText("Enter Ratio Out Break:"), 45));
                float ratioOutBreak = float.Parse(Console.ReadLine());
                skillEffectManager.CreateNewSkillEffect(typeAction, typeEffect, levelSkillEffect, effectValue, timeDistance, ratioSuccess, timeDistance, ratioOutBreak);
                Console.WriteLine(MyLocalization.GetText("Created and saved successfully!"));
                Console.WriteLine(MyLocalization.GetText("Press 'Enter' continue to enter, press any key to exit"));
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void PrintListSkillEffect()
        {
            Console.WriteLine("\n" + Ultils.FormatText(MyLocalization.GetText("ID"), 10) + Ultils.FormatText(MyLocalization.GetText("Type Action"), 30) + Ultils.FormatText(MyLocalization.GetText("Type Effect"), 30) + Ultils.FormatText(MyLocalization.GetText("Level Skill Effect")) + Ultils.FormatText(MyLocalization.GetText("Effect Value")) + Ultils.FormatText(MyLocalization.GetText("Time Exist")) + Ultils.FormatText(MyLocalization.GetText("Ratio Success")) + Ultils.FormatText(MyLocalization.GetText("Time Distance")) + Ultils.FormatText(MyLocalization.GetText("Ratio Outbreak")) + "\n");
            foreach (var item in skillEffectManager.GetListSkillEffect())
            {
                PrintSkillEffect(item.Value);
            }
        }

        public void PrintSkillEffect(SkillEffectData skillEffect)
        {
            Console.WriteLine(Ultils.FormatText(skillEffect.id.ToString(), 10) + Ultils.FormatText(skillEffect.typeAction.ToString(), 30) + Ultils.FormatText(skillEffect.typeEffect.ToString(), 30) + Ultils.FormatText(skillEffect.levelSkillEffect.ToString()) + Ultils.FormatText(skillEffect.effectValue.ToString()) + Ultils.FormatText(skillEffect.timeExist.ToString()) + Ultils.FormatText(skillEffect.ratioSuccess.ToString()) + Ultils.FormatText(skillEffect.timeDistance.ToString()) + Ultils.FormatText(skillEffect.ratioOutbreak.ToString()) + "\n");
        }
    }
}
