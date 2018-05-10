using Magic.Enum;

namespace Magic.SkillEffect
{
    public class SkillEffectData
    {
        public int id;
        public static int idAuto;
        public ESkillEffect typeAction;
        public ETypeEffect typeEffect;
        public int levelSkillEffect;
        public float valueIncreasePerLv;
        public float effectValue;
        public float timeExist;//-1 la ton tai vinh vien
        public float ratioSuccess; //ti le hieu ung lay dinh  //đề nghị viết cmt có dấu dùm(ps: bèo)
        public float timeDistance;//thoi gian de effect boc phat
        public float ratioOutbreak;//xac suat de effect boc phat

        public SkillEffectData()
        {

        }

        public SkillEffectData(ESkillEffect typeAction, ETypeEffect typeEffect, int levelSkillEffect, float valueIncreasePerLv, float effectValue, float timeExist, float ratioSuccess, float timeDistance, float ratioOutbreak)
        {
            idAuto++;
            this.id = idAuto;
            this.typeAction = typeAction;
            this.typeEffect = typeEffect;
            this.levelSkillEffect = levelSkillEffect;
            this.valueIncreasePerLv = valueIncreasePerLv;
            this.effectValue = effectValue;
            this.timeExist = timeExist;
            this.ratioSuccess = ratioSuccess;
            this.timeDistance = timeDistance;
            this.ratioOutbreak = ratioOutbreak;
        }

        public SkillEffectData Clone()
        {
            SkillEffectData data = new SkillEffectData();
            data.id = id;
            data.typeAction = typeAction;
            data.typeEffect = typeEffect;
            data.levelSkillEffect = levelSkillEffect;
            data.valueIncreasePerLv = valueIncreasePerLv;
            data.effectValue = effectValue;
            data.timeExist = timeExist;
            data.ratioSuccess = ratioSuccess;
            data.timeDistance = timeDistance;
            data.ratioOutbreak = ratioOutbreak;
            return data;
        }
    }
}
