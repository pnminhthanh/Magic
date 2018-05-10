using Magic.Enum;
using Magic.Skill;
using System;
using System.Collections.Generic;

namespace Magic.Character
{
    public class MyCharacter
    {
        public CharacterProperties characterProperties;

        public MyCharacter()
        {

        }

        public MyCharacter(CharacterProperties characterProperties)
        {
            this.characterProperties = characterProperties;
        }

        public MyCharacter Clone()
        {
            MyCharacter character = new MyCharacter();
            character.characterProperties = characterProperties.Clone();
            return character;
        }
    }
}
