// the main entry point to the program, to initialize the game
using UnityEngine;
using Asteroids.Facade;


namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            var gameServies = new GameServices();
            gameServies.Start();
        }
    }
}

