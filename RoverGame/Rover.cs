using System;
using RoverGame.Player;

namespace RoverGame
{
    public class Rover : ICharacter
    {
        private readonly IRover _playerRover;

        public Rover(IRover playerRover)
        {
            if (playerRover == null) throw new ArgumentNullException("playerRover");
            _playerRover = playerRover;
        }

        public void NextTurn(GameBoard gameBoard)
        {
            var instruction = _playerRover.Execute()
        }

        private GameState GetGameState()
        {
            
        }
    }
}