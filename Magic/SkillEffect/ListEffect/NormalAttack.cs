using Magic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.SkillEffect.ListEffect
{
    class NormalAttack
    {
        public const int id = 1;
        public ESkillEffect typeAction = ESkillEffect.NONE;
        public ETypeEffect typeEffect = ETypeEffect.ATTACK;
        public int levelSkillEffect = 1;
        public float effectValue = 10;
        public float ratioSuccess = 1;
        public float timeDistance = 0;
        public float ratioOutbreak = 0;
        public float valueIncreasePerLv = 5;

        public NormalAttack()
        {

        }
                
        public NormalAttack Clone()
        {
            NormalAttack data = new NormalAttack();
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.levelSkillEffect = levelSkillEffect;
            data.effectValue = effectValue;
            data.ratioSuccess = ratioSuccess;
            data.timeDistance = timeDistance;
            data.ratioOutbreak = ratioOutbreak;
            data.valueIncreasePerLv = valueIncreasePerLv;
            return data;
        }
    }
}
