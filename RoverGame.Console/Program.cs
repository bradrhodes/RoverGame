using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoverGame.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new DefaultGameBoardGenerator().Generate(100, 100);

            // Todo: Need to use Windsor to load all rovers
            var rovers = new List<Rover>().ToArray();

            var game = new Game(gameBoard, rovers);
            game.Play(100, new CancellationTokenSource().Token);
        }
    }
}
