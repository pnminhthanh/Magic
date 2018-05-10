using System;
using Magic.Enum;

namespace Magic.SkillEffect.ListEffect
{
    class Revival
    {
        public int id = 4;
        public ESkillEffect typeAction = ESkillEffect.REVIVAL;
        public ETypeEffect typeEffect = ETypeEffect.BUFF;
        public float effectValue = 50;
        public float ratioSuccess = 1;

        public Revival()
        {

        }

        public SkillEffectData Clone()
        {
            SkillEffectData data = new SkillEffectData();
            data.id = id;
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.effectValue = effectValue;
            data.ratioSuccess = ratioSuccess;
            return data;
        }
    }
}
