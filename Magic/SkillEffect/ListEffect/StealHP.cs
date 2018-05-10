using System;
using Magic.Enum;

namespace Magic.SkillEffect.ListEffect
{
    class StealHP
    {
        public int id = 2;
        public ESkillEffect typeAction = ESkillEffect.HEAL;
        public ETypeEffect typeEffect = ETypeEffect.BUFF;
        public int levelSkillEffect = 1;
        public float valueIncreasePerLv = 0.05f;
        public float effectValue = 0.3f; //Bằng 0.3 x lượng sát thương gây lên đối thủ
        public float ratioSuccess = 1;

        public StealHP()
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
