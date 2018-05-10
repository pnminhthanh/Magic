using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Skill;

namespace Magic.Character
{
    class LearnSkillController
    {
        private SkillManager skillManager;
        private CharacterManager characterManager;

        public LearnSkillController(SkillManager skillManager, CharacterManager characterManager)
        {
            this.skillManager = skillManager;
            this.characterManager = characterManager;
        }

        public bool LearnSkill(int idCharacter, int idSkill)
        {
            CharacterProperties character = characterManager.GetCharater(idCharacter);
            SkillData skill = skillManager.GetSkill(idSkill);
            if (character.LearnSkill(skill))
            {
                characterManager.UpdateData(character);
                return true;
            }
            return false;
        }
    }
}
