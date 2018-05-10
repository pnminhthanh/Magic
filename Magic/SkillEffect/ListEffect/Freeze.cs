using Magic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.SkillEffect.ListEffect
{
    class Freeze
    {
        public const int id = 7;
        public ESkillEffect typeAction = ESkillEffect.FREEZE;
        public ETypeEffect typeEffect = ETypeEffect.DEBUFF;
        public int levelSkillEffect = 1;
        public float effectValue = 0;
        public float timeExist = 5;
        public float ratioSuccess = 0.5f;
        public float timeDistance = 0;
        public float ratioOutbreak = 0;
        public float valueIncreasePerLv = 0;

        public Freeze()
        {

        }
        
        public Freeze Clone()
        {
            Freeze data = new Freeze();
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.levelSkillEffect = levelSkillEffect;
            data.effectValue = effectValue;
            data.timeExist = timeExist;
            data.ratioSuccess = ratioSuccess;
            data.timeDistance = timeDistance;
            data.ratioOutbreak = ratioOutbreak;
            data.valueIncreasePerLv = valueIncreasePerLv;
            return data;
        }
    }
}
