using Magic.Enum;
using Magic.SkillEffect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Skill
{
    class CreationSkillController
    {
        private SkillManager skillManager;
        private SkillEffectManager skillEffectManager;

        public CreationSkillController(SkillManager skillManager, SkillEffectManager skillEffectManager)
        {
            this.skillEffectManager = skillEffectManager;
            this.skillManager = skillManager;
        }
        

        public void CreateNewSkill(string skillName, string description, int[] listIdSkillEffect, float timeUsed, float timeCooldown, int mpUsed, int levelSkill)
        {
            SkillEffectData[] listSkillEffect = new SkillEffectData[listIdSkillEffect.Length];
            for (int i = 0; i < listIdSkillEffect.Length; i++)
            {               
                listSkillEffect[i] = skillEffectManager.GetSkillEffect(listIdSkillEffect[i]);
            }
            skillManager.CreateNewSkill(skillName, description, listSkillEffect, timeUsed, timeCooldown, mpUsed, levelSkill);
        }

    }
}
