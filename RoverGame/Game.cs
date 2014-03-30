using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RoverGame.Player;

namespace RoverGame
{
    public class Game
    {
        private readonly GameBoard _gameBoard;
        private readonly IList<Rover> _orderedCharacters;

        public Game(GameBoard gameBoard, IEnumerable<Rover> playableRovers)
        {
            if (gameBoard == null) throw new ArgumentNullException("gameBoard");
            if (playableRovers == null) throw new ArgumentNullException("playableRovers");

            _gameBoard = gameBoard;
            _orderedCharacters = playableRovers.ToList();
            _orderedCharacters.Shuffle();
        }

        public void Play(int numTurns, CancellationToken cancellationToken)
        {
            var turn = 0;

            while (turn < numTurns && !cancellationToken.IsCancellationRequested)
            {
                foreach (var orderedCharacter in _orderedCharacters)
                {
                    orderedCharacter.NextTurn(_gameBoard);
                }


                turn ++;
            }
        }
    }
}