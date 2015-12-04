using System;
using TheSlum.Characters;

namespace TheSlum.GameEngine
{
    public class AdvancedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            base.ExecuteCommand(inputParams);
            switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string characterType = inputParams[1];
            string characterName = inputParams[2];
            int characterX = int.Parse(inputParams[3]);
            int characterY = int.Parse(inputParams[4]);
            Team team = (Team) Enum.Parse(typeof (Team), inputParams[5]);

            string id = "" + (characterList.Count + 1);
            Character character = CharacterFactory.Create(characterType,characterX,characterY,id,team);
            characterList.Add(character);
        }
    }
}