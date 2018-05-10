using Magic.Character;
using Magic.Enum;
using Magic.Game.MyTimer;
using Magic.Skill;
using Magic.SkillEffect;
using System;

namespace Magic.Game.Battle
{
    public class BattleController : BaseTimer
    {
        private CharacterBattleData player1, player2;
        public delegate void UseSkillDelegate(CharacterBattleData player, SkillData skill);
        public UseSkillDelegate UseSkillCallBack;
        public delegate void UseEffectDelegate(CharacterBattleData player, SkillEffectData skill);
        public UseEffectDelegate SkillAttackCallBack, SkillHealerCallBack;
        public delegate void RegenHpAndMpDelegate(CharacterBattleData player);
        public RegenHpAndMpDelegate RegenHpAndMpCallBack;
        public delegate void UpdateHpAndMp(CharacterBattleData player1, CharacterBattleData player2);
        public UpdateHpAndMp UpdateHpAndMpCallBack;
        public delegate void EndBattle(CharacterBattleData winPlayer, CharacterBattleData losePlayer);
        public EndBattle EndBattleCallBack;
        private bool _isComplete;

        public BattleController()
        {

        }

        public void Init()
        {
            _isComplete = false;
            GameLoop.Instance.JoinTimer(this);
        }

        public void Battle(CharacterProperties dataPlayer1, CharacterProperties dataPlayer2)
        {
            Init();
            player1 = new CharacterBattleData(dataPlayer1);
            player2 = new CharacterBattleData(dataPlayer2);
            RegenHpAndMp(player1);
            RegenHpAndMp(player2);
        }

        public override void UpdateTime(float deltaTime)
        {
            if (_isComplete)
                return;
            SkillData usedSkill1 = player1.UseSkill();
            SkillData usedSkill2 = player2.UseSkill();
            if (usedSkill1 != null)
                UseSkillCallBack.Invoke(player1, usedSkill1);
            if (usedSkill2 != null)
                UseSkillCallBack.Invoke(player2, usedSkill2);
            player1.UpdateStateKill(deltaTime, UseSkill);
            player2.UpdateStateKill(deltaTime, UseSkill);
        }

        private void UseSkill(SkillData skill, CharacterBattleData player)
        {
            CharacterBattleData usedPlayer = null, enemyPlayer = null;
            if(player.characterProperties.id == player1.characterProperties.id)
            {
                usedPlayer = player1;
                enemyPlayer = player2;
            }
            else if(player.characterProperties.id == player2.characterProperties.id)
            {
                usedPlayer = player2;
                enemyPlayer = player1;
            }
            for(int i = 0; i < skill.listSkillEffect.Length; i++)
            {
                if(skill.listSkillEffect[i] != null)
                {
                    if (skill.listSkillEffect[i].typeEffect == ETypeEffect.ATTACK)
                    {
                        enemyPlayer.hp -= skill.listSkillEffect[i].effectValue;
                        if (enemyPlayer.hp <= 0)
                        {
                            _isComplete = true;
                            EndBattleCallBack.Invoke(usedPlayer, enemyPlayer);
                            return;
                        }
                        UpdateHpAndMpCallBack.Invoke(player1, player2);
                        SkillAttackCallBack.Invoke(enemyPlayer, skill.listSkillEffect[i]);
                    }
                    else if (skill.listSkillEffect[i].typeEffect == ETypeEffect.BUFF)
                    {
                        if (skill.listSkillEffect[i].typeAction == ESkillEffect.HEAL)
                        {
                            usedPlayer.RecoverHp(skill.listSkillEffect[i].effectValue);
                            UpdateHpAndMpCallBack.Invoke(player1, player2);
                        }
                    }
                }
            }
        }

        private void RegenHpAndMp(CharacterBattleData player)
        {
            GameTimer.Instance.AddTimer(1, () => ProcessRegenHpAndMp(player));
        }

        private void ProcessRegenHpAndMp(CharacterBattleData player)
        {
            player.RecoverHp(player.characterProperties.hpRegen);
            player.RecoverMp(player.characterProperties.mpRegen);
            RegenHpAndMpCallBack.Invoke(player);
        }
    }
}
