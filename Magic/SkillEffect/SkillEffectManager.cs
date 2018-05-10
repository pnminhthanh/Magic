using Magic.Enum;
using Magic.Tools;
using System.Collections.Generic;

namespace Magic.SkillEffect
{
    class SkillEffectManager
    {
        private Dictionary<int, SkillEffectData> listSkillEffect;
        private string path = "../SkillEffectData.txt";

        public SkillEffectManager()
        {
            listSkillEffect = new Dictionary<int, SkillEffectData>();
            ReadData();
        }
        
        public void CreateNewSkillEffect(ESkillEffect typeAction, ETypeEffect typeEffect, int levelSkillEffect, float valueIncreasePerLv, float effectValue, float timeExist, float ratioSuccess, float timeDistance, float ratioOutbreak)
        {
            SkillEffectData newskilleffect = new SkillEffectData(typeAction, typeEffect, levelSkillEffect, valueIncreasePerLv, effectValue, timeExist, ratioSuccess, timeDistance, ratioOutbreak);
            AddSkillEffect(newskilleffect);
        }

        public void AddSkillEffect(SkillEffectData skillEffectData)
        {
            if (!listSkillEffect.ContainsKey(skillEffectData.id))
            {
                listSkillEffect.Add(skillEffectData.id, skillEffectData);
                IOMethods.Instance.WriteData<SkillEffectData>(path, listSkillEffect);
            }                
        }

        public void ReadData()
        {
            IOMethods.Instance.ReadData<SkillEffectData>(path, ref listSkillEffect);
            int max = 0;
            foreach(var item in listSkillEffect)
            {
                if (item.Value.id > max)
                    max = item.Value.id;
            }
            SkillEffectData.idAuto = max;
        }

        public void RemoveSkillEffect(int id)
        {
            if(listSkillEffect.ContainsKey(id))
            {
                listSkillEffect.Remove(id);
                IOMethods.Instance.WriteData<SkillEffectData>(path, listSkillEffect);
            }            
        }

        public SkillEffectData GetSkillEffect(int idSkillEffect)
        {
            if (!listSkillEffect.ContainsKey(idSkillEffect))
                return null;
            return listSkillEffect[idSkillEffect].Clone();
        }

        public Dictionary<int, SkillEffectData> GetListSkillEffect()
        {
            return listSkillEffect;
        }
    }
}
