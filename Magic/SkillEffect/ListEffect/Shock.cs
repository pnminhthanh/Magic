using Magic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.SkillEffect.ListEffect
{
    class Shock
    {
        public const int id = 6;
        public ESkillEffect typeAction = ESkillEffect.SHOCK;
        public ETypeEffect typeEffect = ETypeEffect.DEBUFF;
        public int levelSkillEffect = 1;
        public float timeExist = 2;
        public float ratioSuccess = 1;
        public float timeDistance = 0;
        public float ratioOutbreak = 0;
        public float valueIncreasePerLv = 0.2f;

        public Shock()
        {

        }        

        public Shock Clone()
        {
            Shock data = new Shock();
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.levelSkillEffect = levelSkillEffect;
            data.timeExist = timeExist;
            data.ratioSuccess = ratioSuccess;
            data.timeDistance = timeDistance;
            data.ratioOutbreak = ratioOutbreak;
            data.valueIncreasePerLv = valueIncreasePerLv;
            return data;
        }
    }
}
