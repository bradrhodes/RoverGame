using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace RoverGame
{
    /// <summary>
    /// ITerrain represents the current state of Terrain for a BoardSpace.
    /// Based on the State Design Pattern: http://www.codeproject.com/Articles/509234/The-State-Design-Pattern-vs-State-Machine
    /// </summary>
    public interface ITerrainState
    {
        void Dig(BoardSpace boardSpace);
        void Build(BoardSpace boardSpace);
        int Depth { get; }
        string TerrainName { get; }
    }

    /// <summary>
    /// Defines the state of the terrain as a hole
    /// </summary>
    public class HoleTerrain : ITerrainState
    {
        public HoleTerrain()
        {
            TerrainName = Constants.TerrainNames.Hole;
            Depth = -1;
        }

        public void Dig(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = this;
        }

        public void Build(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = new FlatTerrain();
        }

        public int Depth { get; private set; }
        public string TerrainName { get; private set; }
    }

    /// <summary>
    /// Defines the state of the terrain as a hill
    /// </summary>
    public class HillTerrain : ITerrainState
    {
        public HillTerrain()
        {
            TerrainName = Constants.TerrainNames.Hill;
            Depth = 1;
        }

        public void Dig(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = new FlatTerrain();
        }

        public void Build(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = this;
        }

        public int Depth { get; private set; }
        public string TerrainName { get; private set; }
    }

    /// <summary>
    /// Defines the state of the terraine as flat
    /// </summary>
    public class FlatTerrain : ITerrainState
    {
        public FlatTerrain()
        {
            TerrainName = Constants.TerrainNames.Flat;
            Depth = 0;
        }

        public void Dig(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = new HoleTerrain();
        }

        public void Build(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = new HillTerrain();
        }

        public int Depth { get; private set; }
        public string TerrainName { get; private set; }
    }

    public class MountainTerrain : ITerrainState
    {
        public MountainTerrain()
        {
            TerrainName = Constants.TerrainNames.Mountain;
            Depth = 2;
        }

        public void Dig(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = this;
        }

        public void Build(BoardSpace boardSpace)
        {
            boardSpace.TerrainState = this;
        }

        public int Depth { get; private set; }
        public string TerrainName { get; private set; }
    }
}