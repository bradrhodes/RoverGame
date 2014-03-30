using System.Drawing;

namespace RoverGame.Player
{
    public class GameState
    {
        public Point CurrentPosition { get; set; }
        public BoardSpace[] VisibleSpaces { get; set; }
    }

    public enum Direction
    {
        North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest
    }

    public enum Action
    {
        Move, Dig, Build, Collect, Bump, Give
    }

    public interface IInteraction
    {
        void Execute();
    }

    public class BoardSpace
    {
        public Point Location { get; set; }
        public Terrain Terrain { get; set; }
        public GameObject Object { get; set; }
        public CharacterType CharacterType { get; set; }
        public Action[] PossibleActions { get; set; }
    }

    public enum Terrain
    {
        Hole, Flat, Hill, Mountain
    }

    public enum GameObject
    {
        None, Plant, Mineral
    }

    public enum CharacterType
    {
        Alien, Rover
    }
}