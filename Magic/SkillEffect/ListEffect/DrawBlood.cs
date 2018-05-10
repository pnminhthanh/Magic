using Magic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.SkillEffect.ListEffect
{
    class DrawBlood
    {

        public const int id = 9;
        public ESkillEffect typeAction = ESkillEffect.POISON;
        public ETypeEffect typeEffect = ETypeEffect.ATTACK;
        public float effectValue = 10;
        public float levelSkillEffect = 1;
        public float timeExist = 5;
        public float ratioSuccess = 1;
        public float timeDistance = 0.5f;
        public float ratioOutbreak = 1;
        public float valueIncreasePerLv = 2;

        public DrawBlood()
        {

        }
                
        public DrawBlood Clone()
        {
            DrawBlood data = new DrawBlood();
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.levelSkillEffect = levelSkillEffect;
            data.effectValue = effectValue;
            data.timeExist = timeExist;
            data.ratioSuccess = ratioSuccess;
            data.valueIncreasePerLv = valueIncreasePerLv;
            return data;
        }
    }
}
