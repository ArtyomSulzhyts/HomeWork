using UnityEngine;
using Zenject;


namespace Pirates
{
    public class GamePlayController : IInitializable
    {
        private readonly InputHandler _inputHandler;
        private readonly IShip _ship;

        public GamePlayController(InputHandler inputHandler, IShip ship)
        {
            _inputHandler = inputHandler;
            _ship = ship;
        }
        
        public void Initialize()
        {
            _inputHandler.ScreenTap += TapOnScreen;
        }

        private void TapOnScreen(Vector2 position)
        {
            _ship.MoveToPosition(position);
        }
    }
}
