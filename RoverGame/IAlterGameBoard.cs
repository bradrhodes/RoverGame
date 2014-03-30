using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace RoverGame
{
    public interface IAlterGameBoard
    {
        void AlterBoard(GameBoard board);
    }

    public class AddRandomGameObjects : IAlterGameBoard
    {
        private readonly Func<IGameObject> _objectFactory;
        private readonly int _count;

        public AddRandomGameObjects(Func<IGameObject> objectFactory, int count = 1)
        {
            if (objectFactory == null) throw new ArgumentNullException("objectFactory");
            _objectFactory = objectFactory;
            _count = count;
        }

        public void AlterBoard(GameBoard board)
        {
            var flatSpaces = board.GetEmptyFlatSpaces();

            for (var i = 0; i < _count; i++)
            {
                var rndIndex = RandomGenerator.Next(0, flatSpaces.Count - 1);
                var rndSpace = flatSpaces[rndIndex];
                rndSpace.GameObject = _objectFactory.Invoke();

                flatSpaces.RemoveAt(rndIndex);
            }
        }
    }

    /// <summary>
    /// Adds given amount of random terrain
    /// </summary>
    public class AddRandomTerrain : IAlterGameBoard
    {
        private readonly Func<ITerrainState> _terrainStateFactory;
        private readonly int _count;

        public AddRandomTerrain(Func<ITerrainState> terrainStateFactory, int count = 1)
        {
            if (terrainStateFactory == null) throw new ArgumentNullException("terrainStateFactory");
            _terrainStateFactory = terrainStateFactory;
            _count = count;
        }

        /// <summary>
        /// Alters the board.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="args"></param>
        public void AlterBoard(GameBoard board)
        {
            for (var i = 0; i < _count; i++)
            {
                var x = RandomGenerator.Next(0, board.Width - 1);
                var y = RandomGenerator.Next(0, board.Height - 1);

                board.Space(x, y).TerrainState = _terrainStateFactory.Invoke();
            }
        }
    }

    public class AddHerbivoreAliens : IAlterGameBoard
    {
        private readonly int _numAliens;

        public AddHerbivoreAliens(int numAliens)
        {
            _numAliens = numAliens;
        }

        public void AlterBoard(GameBoard board)
        {
            for (var i = 0; i < _numAliens; i++)
            {
                var x = RandomGenerator.Next(0, board.Width - 1);
                var y = RandomGenerator.Next(0, board.Height - 1);

                board.Space(x, y).Character = new HerbivoreAlien();
            }
        }
    }
}