using System.Collections.Generic;
using Magic.Skill;
using Magic.Tools;

namespace Magic.Character
{
    class CharacterManager
    {        
        private Dictionary<int, CharacterProperties> listCharacter;
        private static string path = "..\\CharacterData.txt";
        public CharacterManager()
        {
            listCharacter = new Dictionary<int, CharacterProperties>();
            ReadData();
        }

        public void CreateCharacter(string name, float hp, float mp, float hpRegen, float mpRegen)
        {
            CharacterProperties newChar = new CharacterProperties(name, hp, mp, hpRegen, mpRegen);
            AddCharacter(newChar);
        }

        public void AddCharacter(CharacterProperties characterData)
        {
            if(!listCharacter.ContainsKey(characterData.id))
            {
                listCharacter.Add(characterData.id, characterData);
                IOMethods.Instance.WriteData<CharacterProperties>(path, listCharacter);
            }                
        }

        public void ReadData()
        {
            IOMethods.Instance.ReadData<CharacterProperties>(path, ref listCharacter);
            int max = 0;
            foreach(var item in listCharacter)
            {
                if (item.Value.id > max)
                    max = item.Value.id;
            }
            CharacterProperties.idAuto = max;
        }

        public void RemoveCharacter(int id)
        {
            if (listCharacter.ContainsKey(id))
            {
                listCharacter.Remove(id);
            }
        }

        public Dictionary<int, CharacterProperties> GetList()
        {
            return listCharacter;
        }

        public CharacterProperties GetCharater(int idCharacter)
        {
            if (!listCharacter.ContainsKey(idCharacter))
                return null;
            return listCharacter[idCharacter].Clone();
        }

        public void UpdateData(CharacterProperties character)
        {
            listCharacter[character.id] = character;
            IOMethods.Instance.WriteData<CharacterProperties>(path, listCharacter);
        }
    }
}
