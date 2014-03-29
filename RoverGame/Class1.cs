using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverGame
{
    public class GameBoard
    {
        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;

            _board = new Space[height,width];
        }

        private Space[,] _board;

        public int Width { get; set; }
        public int Height { get; set; }
    }

    /// <summary>
    /// Space defines information about a space on the board
    /// </summary>
    public class Space
    {
        public IGameObject GameObject { get; set; }
        public ITerrainState TerrainState { get; set; }
    }

    /// <summary>
    /// ITerrain represents the current state of Terrain for a space.
    /// Based on the State Design Pattern: http://www.codeproject.com/Articles/509234/The-State-Design-Pattern-vs-State-Machine
    /// </summary>
    public interface ITerrainState
    {
        
    }

    

    /// <summary>
    /// IGameObject represents an object that can occupy one or more spaces on the board
    /// </summary>
    public interface IGameObject
    {
        
    }
}
