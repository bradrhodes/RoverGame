namespace RoverGame
{
    /// <summary>
    /// BoardSpace defines information about a space on the board
    /// </summary>55
    public class BoardSpace
    {
        public BoardSpace()
        {
            TerrainState = new FlatTerrain();
        }

        public IGameObject GameObject { get; set; }
        public ITerrainState TerrainState { get; set; }
        public ICharacter Character { get; set; }
    }
}