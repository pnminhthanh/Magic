using Magic.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Character
{
    public class CharacterProperties
    {
        public int id;
        public static int idAuto;
        public string characterName;
        public float hp;
        public float mp;
        public float hpRegen;
        public float mpRegen;
        public List<SkillData> listSkill;

        public CharacterProperties()
        {
            listSkill = new List<SkillData>();
        }

        public CharacterProperties(string characterName, float hp, float mp, float hpRegen, float mpRegen)
        {
            idAuto++;
            id = idAuto;
            this.characterName = characterName;
            this.hp = hp;
            this.mp = mp;
            this.hpRegen = hpRegen;
            this.mpRegen = mpRegen;
            listSkill = new List<SkillData>();
        }

        public CharacterProperties Clone()
        {
            CharacterProperties data = new CharacterProperties();
            data.id = id;
            data.characterName = characterName;
            data.hp = hp;
            data.mp = mp;
            data.hpRegen = hpRegen;
            data.mpRegen = mpRegen;
            data.listSkill = new List<SkillData>();
            for (int i = 0; i < listSkill.Count; i++)
            {
                SkillData skillData = listSkill[i].Clone();
                data.listSkill.Add(skillData);
            }
            return data;
        }

        public bool LearnSkill(SkillData skillData)
        {
            foreach(SkillData data in listSkill)
            {
                if (data.id == skillData.id)
                    return false;
            }
            listSkill.Add(skillData);
            return true;
        }
    }
}
