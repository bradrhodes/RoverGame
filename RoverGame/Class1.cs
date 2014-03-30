using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoverGame.Player;

namespace RoverGame
{
    /// <summary>
    /// IGameObject represents an object that can occupy one or more spaces on the board
    /// </summary>
    public interface IGameObject
    {
        
    }

    /// <summary>
    /// ICollectable represents an object that can be collected by a rover
    /// </summary>
    public interface ICollectable : IGameObject
    {
        
    }

    public interface ICharacter : IGameObject
    {
        
    }

    public interface INonPlayableCharacter : ICharacter
    {
        
    }

    public class Plant : ICollectable
    {
        
    }

    public class Mineral : ICollectable
    {
        
    }

    public class HerbivoreAlien : INonPlayableCharacter
    {
        
    }

    public class Spaceship : IGameObject
    {
        
    }
}
