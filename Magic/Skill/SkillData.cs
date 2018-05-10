using Magic.SkillEffect;

namespace Magic.Skill
{
    public class SkillData
    {
        public int id;
        public static int idAuto;
        public string skillName;
        public string description;
        public SkillEffectData[] listSkillEffect;
        public float timeUsed;
        public float timeCooldown;
        public int mpUsed;
        public int levelSkill = 1;

        public SkillData()
        {
        }

        public SkillData(string skillName, string description, SkillEffectData[] listSkillEffect, float timeUsed, float timeCooldown, int mpUsed, int levelSkill)
        {
            idAuto++;
            this.id = idAuto;
            this.skillName = skillName;
            this.description = description;
            this.listSkillEffect = listSkillEffect;
            this.timeUsed = timeUsed;
            this.timeCooldown = timeCooldown;
            this.mpUsed = mpUsed;
            this.levelSkill = levelSkill;
        }

        public SkillData Clone()
        {
            SkillData data = new SkillData();
            data.id = this.id;
            data.skillName = skillName;
            data.description = description;
            data.listSkillEffect = new SkillEffectData[listSkillEffect.Length];
            for(int i = 0; i < listSkillEffect.Length; i++)
            {
                if (listSkillEffect[i] != null)
                    data.listSkillEffect[i] = listSkillEffect[i].Clone();
            }
            data.timeUsed = timeUsed;
            data.timeCooldown = timeCooldown;
            data.mpUsed = mpUsed;
            data.levelSkill = levelSkill;
            return data;
        }
    }
}
