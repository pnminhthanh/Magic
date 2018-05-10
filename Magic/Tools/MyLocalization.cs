namespace Magic.Tools
{
    class MyLocalization
    {
        private static string selectLanguage = "eng";

        public static string GetText(string code)
        {
            if (selectLanguage.Equals("vni"))
            {
                return GetTextVNI(code);
            }
            else if (selectLanguage.Equals("eng"))
            {
                return GetTextENG(code);
            }
            else return code;
        }

        private static string GetTextVNI(string code)
        {
            switch (code)
            {
                case "TEST":
                    return "Creation Skill Effect View\n\n";
                default:
                    return code;
            }
        }

        private static string GetTextENG(string code)
        {
            switch (code)
            {
                case "titleCreationSkillEffectView":
                    return "Creation Skill Effect View";
                case "typeAction":
                    return "Choose Type Action (Enter Value):";
                case "typeEffect":
                    return "Choose Type Effect (Enter Value):";
                case "levelSkillEffect":
                    return "Enter Level Skill Effect:";
                case "effectValue":
                    return "Enter Effect Value:";
                case "timeExist":
                    return "Enter Time Exist:";
                case "ratioSuccess":
                    return "Enter Ratio Success:";
                case "timeDistance":
                    return "Enter Time Distance:";
                case "ratioOutBreak":
                    return "Enter Ratio Out Break:";
                case "successCreationMessage":
                    return "Created and saved successfully!";
                case "direction":
                    return "Press 'Enter' continue to enter, press any key to exit";
                case "titleCreationSkillView":
                    return "Creation SkillView";
                case "skillName":
                    return "Enter Skill Name";
                case "description":
                    return "Enter Description";
                case "skillEffect":
                    return "Choose Skill Effect (Enter Value):";
                case "magicValue":
                    return "Enter Magic Value:";
                case "timeUsed":
                    return "Enter Time Used:";
                case "timeCoolDown":
                    return "Enter Time Cool Down:";
                case "mpUsed":
                    return "Enter MP Used:";
                case "ID":
                    return "ID";
                case "Type Action":
                    return "Type Action";
                case "Type Effect":
                    return "Type Effect";
                case "Level Skill Effect":
                    return "Level Skill Effect";
                case "Effect Value":
                    return "Effect Value";
                case "Time Exist":
                    return "Time Exist";
                case "Ratio Success":
                    return "Ratio Success";
                case "Time Distance":
                    return "Time Distance";
                case "Ratio Outbreak":
                    return "Ratio Outbreak";
                case "Skill Effect":
                    return "Skill Effect";
                case "Skill Name":
                    return "Skill Name";
                case "Description":
                    return "Description";
                case "Magic Value":
                    return "Magic Value";
                case "Time Used":
                    return "Time Used";
                case "Time Cool Down":
                    return "Time Cool Down";
                case "MP Used":
                    return "MP Used";
                case "Creation Character View":
                    return "Creation Character View";
                case "Enter Character's name":
                    return "Enter Character's name";
                case "Enter Character's HP":
                    return "Enter Character's HP";
                case "Enter Character's MP":
                    return "Enter Character's MP";
                case "Enter Character's HP Regen":
                    return "Enter Character's HP Regen";
                case "Enter Character's MP Regen":
                    return "Enter Character's MP Regen";
                case "Choose a character to learn skill":
                    return "Choose a character to learn skill";
                case "Choose a skill to learn":
                    return "Choose a skill to learn";
                case "successMess":
                    return "Learnt Successfully!!";
                case "The character has already learnt this skill":
                    return "The character has already learnt this skill";
                case "Character's name":
                    return "Character's name";
                case "Character's HP":
                    return "Character's HP";
                case "Character's MP":
                    return "Character's MP";
                case "Character's HP Regen":
                    return "Character's HP Regen";
                case "Character's MP Regen":
                    return "Character's MP Regen";
                case "Please choose a player (Enter the ID):":
                    return "Please choose a player (Enter the ID):";
                case "Start Battle":
                    return "Start Battle";
                default:
                    return code;
            }
        }
    }
}
