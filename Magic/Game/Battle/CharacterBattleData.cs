using Magic.Character;
using Magic.Enum;
using Magic.Game.MyTimer;
using Magic.Skill;
using System;
using System.Collections.Generic;

namespace Magic.Game.Battle
{
    public class CharacterBattleData
    {
        public CharacterProperties characterProperties;
        public List<EStateBattle> listStateSkill;
        public List<float> listTimeUsed;
        public List<float> listTimeCountDown;
        public float hp;
        public float mp;

        public CharacterBattleData()
        {
        }

        public CharacterBattleData(CharacterProperties character)
        {
            listTimeUsed = new List<float>();
            listTimeCountDown = new List<float>();
            characterProperties = character.Clone();
            listStateSkill = new List<EStateBattle>();
            for(int i = 0; i < character.listSkill.Count; i++)
            {
                EStateBattle state = EStateBattle.NONE;
                listStateSkill.Add(state);
                float timeUsed = character.listSkill[i].timeUsed;
                float timeCountDown = character.listSkill[i].timeCooldown;
                listTimeUsed.Add(timeUsed);
                listTimeCountDown.Add(timeCountDown);
                hp = character.hp;
                mp = character.mp;
            }
        }

        public SkillData UseSkill()
        {
            for (int i = 0; i < characterProperties.listSkill.Count; i++)
            {
                if (listStateSkill[i] == EStateBattle.NONE)
                {
                    listStateSkill[i] = EStateBattle.PREPARE;
                    for (int j = 0; j < characterProperties.listSkill.Count; j++)
                    {
                        if (listStateSkill[j] == EStateBattle.NONE)
                            listStateSkill[j] = EStateBattle.WAITING;
                    }
                    return characterProperties.listSkill[i];

                }
            }
            return null;
        }

        public void UpdateStateKill(float deltaTime, Action<SkillData, CharacterBattleData> useCallBack)
        {
            for (int i = 0; i < characterProperties.listSkill.Count; i++)
            {
                if (listStateSkill[i] == EStateBattle.PREPARE)
                {
                    listTimeUsed[i] -= deltaTime;
                    if (listTimeUsed[i] <= 0)
                    {
                        listTimeUsed[i] = characterProperties.listSkill[i].timeUsed;
                        useCallBack.Invoke(characterProperties.listSkill[i], this);
                        listStateSkill[i] = EStateBattle.COUNTDOWN;
                        for (int j = 0; j < characterProperties.listSkill.Count; j++)
                        {
                            if (listStateSkill[j] == EStateBattle.WAITING)
                                listStateSkill[j] = EStateBattle.NONE;
                        }
                    }
                }
                else if (listStateSkill[i] == EStateBattle.COUNTDOWN)
                {
                    listTimeCountDown[i] -= deltaTime;
                    if (listTimeCountDown[i] <= 0)
                    {
                        listTimeCountDown[i] = characterProperties.listSkill[i].timeCooldown;
                        listStateSkill[i] = EStateBattle.NONE;
                    }
                }
            }
        }

        public void RecoverHp(float hpAdd)
        {
            hp += hpAdd;
            if (hp > characterProperties.hp)
                hp = characterProperties.hp;
        }

        public void RecoverMp(float mpAdd)
        {
            mp += mpAdd;
            if (mp > characterProperties.mp)
                mp = characterProperties.mp;
        }

    }
}
