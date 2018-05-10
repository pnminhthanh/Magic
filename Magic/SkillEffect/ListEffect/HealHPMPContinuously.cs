using Magic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.SkillEffect.ListEffect
{
    class HealHPMPContinuously
    {

        public const int id = 3;
        public ESkillEffect typeAction = ESkillEffect.HEAL;
        public ETypeEffect typeEffect = ETypeEffect.BUFF;
        public int levelSkillEffect = 1;
        public float effectValue = 10;
        public float timeExist = 10;
        public float ratioSuccess = 1;
        public float timeDistance = 2;
        public float ratioOutbreak = 1;
        public float valueIncreasePerLv = 5;

        public HealHPMPContinuously()
        {

        }
        
        public HealHPMPContinuously Clone()
        {
            HealHPMPContinuously data = new HealHPMPContinuously();
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
