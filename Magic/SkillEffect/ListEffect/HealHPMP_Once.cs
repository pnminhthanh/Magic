using System;
using Magic.Enum;

namespace Magic.SkillEffect.ListEffect
{
    class HealHPMP_Once
    {
        public int id = 2;
        public ESkillEffect typeAction = ESkillEffect.HEAL;
        public ETypeEffect typeEffect = ETypeEffect.BUFF;
        public int levelSkillEffect = 1;
        public float valueIncreasePerLv = 0;
        public float effectValue = 50;
        public float ratioSuccess = 1;

        public HealHPMP_Once()
        {

        }

        public SkillEffectData Clone()
        {
            SkillEffectData data = new SkillEffectData();
            data.id = id;
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.levelSkillEffect = levelSkillEffect;
            data.effectValue = effectValue;
            data.ratioSuccess = ratioSuccess;
            return data;
        }
    }
}
