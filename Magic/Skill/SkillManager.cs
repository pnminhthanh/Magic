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
    class SkillManager
    {
        private Dictionary<int, SkillData> listSkill;
        private string path = "../SkillData.txt";

        public SkillManager()
        {
            listSkill = new Dictionary<int, SkillData>();
            ReadData();
        }

        public void CreateNewSkill(string skillName, string description, SkillEffectData[] listSkillEffect, float timeUsed, float timeCooldown, int mpUsed, int levelSkill)
        {
            SkillData newskill = new SkillData(skillName, description, listSkillEffect, timeUsed, timeCooldown, mpUsed, levelSkill);
            AddSkill(newskill);
        }

        public void AddSkill(SkillData skillData)
        {
            if (!listSkill.ContainsKey(skillData.id))
            {
                listSkill.Add(skillData.id, skillData);
                IOMethods.Instance.WriteData<SkillData>(path, listSkill);
            }                
        }

        public void RemoveSkill(int id)
        {
            if (listSkill.ContainsKey(id))
            {
                listSkill.Remove(id);
                IOMethods.Instance.WriteData<SkillData>(path, listSkill);
            }
        }

        public SkillData GetSkill(int idSkill)
        {
            if (!listSkill.ContainsKey(idSkill))
                return null;
            return listSkill[idSkill].Clone();
        }
        
        public Dictionary<int, SkillData> GetList()
        {
            return listSkill;
        }

        public void ReadData()
        {
            IOMethods.Instance.ReadData<SkillData>(path, ref listSkill);
            int max = 0;
            foreach (var item in listSkill)
            {
                if (item.Value.id > max)
                    max = item.Value.id;
            }
            SkillData.idAuto = max;
        }
    }
}
