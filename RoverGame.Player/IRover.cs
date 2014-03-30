using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverGame.Player
{
    /// <summary>
    /// IRover represents an AI-controlled character in the game
    /// </summary>
    public interface IRover
    {
        Instruction Execute(GameState gameState);
        string RoverName { get; }
    }
}
