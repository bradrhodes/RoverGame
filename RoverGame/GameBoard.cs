using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RoverGame.Player;

namespace RoverGame
{
    public class GameBoard
    {
        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;

            //_board = new BoardSpace[height,width];
            _board = new Dictionary<Point, BoardSpace>();

            InitalizeBoard();
        }

        //private readonly BoardSpace[,] _board;
        private readonly Dictionary<Point, BoardSpace> _board; 

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Tuple<Point, Point> SpaceshipLocation { get; set; } 
        public List<Point> StartingLocations { get; set; } 

        public BoardSpace Space(int xPos, int yPos)
        {
            //return _board[yPos, xPos];
            return _board[new Point(xPos, yPos)];
        }

        private void InitalizeBoard()
        {
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    _board[new Point(j, i)] = new BoardSpace();
                }
            }
        }

        public IList<BoardSpace> GetEmptyFlatSpaces()
        {
            return _board.Where(x => x.Value.TerrainState.TerrainName == Constants.TerrainNames.Flat && x.Value.GameObject == null).Select(x => x.Value).ToList();
        }

        public GameBoard AlterGameBoard(IAlterGameBoard alteration)
        {
            alteration.AlterBoard(this);
            return this;
        }
    }

    


    public interface IGenerateGameBoard
    {
        GameBoard Generate(int width, int height);
    }

    public class DefaultGameBoardGenerator : IGenerateGameBoard
    {
        public GameBoard Generate(int width, int height)
        {
            // For now all boards are 100x100;
            width = 100;
            height = 100;

            var gameBoard = new GameBoard(width + 3, height + 3) // +3's are to make room for the spaceship
                .AlterGameBoard(new AddRandomTerrain(() => new HillTerrain(), 500))
                .AlterGameBoard(new AddRandomTerrain(() => new HoleTerrain(), 500))
                .AlterGameBoard(new AddRandomTerrain(() => new MountainTerrain(), 200));

            AddSpaceship(gameBoard, width, height);
            GenerateStartingLocations(gameBoard);

            // Add plants, minerals, aliens
            gameBoard.AlterGameBoard(new AddRandomGameObjects(() => new Plant(), 2000))
                .AlterGameBoard(new AddRandomGameObjects(() => new Mineral(), 1000));

            return gameBoard;
        }

        private void AddSpaceship(GameBoard board, int width, int height)
        {
            var xStart = width/2;
            var yStart = height/2;

            var spaceShip = new Spaceship();

            for (var y = yStart; y < yStart + 3; y++)
            {
                for (var x = xStart; x < xStart + 3; x++)
                {
                    var space = board.Space(x, y);
                    space.TerrainState = new FlatTerrain();
                    space.GameObject = spaceShip;
                }
            }

            board.SpaceshipLocation = new Tuple<Point, Point>(new Point(xStart, yStart),
                new Point(xStart + 2, yStart + 2));
        }

        private void GenerateStartingLocations(GameBoard board)
        {
            var x = board.SpaceshipLocation.Item1.X;
            var y = board.SpaceshipLocation.Item1.Y;

            board.StartingLocations = new List<Point>
            {
                new Point(x-1, y-1),
                new Point(x+3, y-1),
                new Point(x+3, y+3),
                new Point(x-1, y+3),
                new Point(x+1, y-1),
                new Point(x+3, y+1),
                new Point(x+1, y+3),
                new Point(x-1, y+1)
            };
        }
    }

}