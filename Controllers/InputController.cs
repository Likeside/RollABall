using UnityEngine;

namespace RollABall.Controllers
{
    public sealed class InputController: IExecute
    {
        private readonly PlayerBase _playerBase;

        public InputController(PlayerBase playerBase)
        {
            _playerBase = playerBase;
        }
        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}