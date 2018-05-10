using System;
using Magic.Enum;

namespace Magic.SkillEffect.ListEffect
{
    class PoisonAttack
    {
        public int id = 5;
        public ESkillEffect typeAction = ESkillEffect.POISON;
        public ETypeEffect typeEffect = ETypeEffect.ATTACK;
        public int levelSkillEffect = 1;
        public float valueIncreasePerLv = 5;
        public float effectValue = 5;
        public float timeExist = 5;
        public float ratioSuccess = 1;
        public float timeDistance = 1;
        public float ratioOutbreak = 0.7f;

        public PoisonAttack()
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
            data.timeExist = timeExist;
            data.ratioSuccess = ratioSuccess;
            data.timeDistance = timeDistance;
            data.ratioOutbreak = ratioOutbreak;
            return data;
        }
    }
}
