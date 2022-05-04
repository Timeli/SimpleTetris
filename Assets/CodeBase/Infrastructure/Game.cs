using Assets.CodeBase.GameField;
using Assets.CodeBase.GameLogic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class Game
    {
        private const int FPS = 30;
        public static IInputService InputService;

        private readonly GameStateMachine _stateMachine;

        public Game(GameZone gameZone)
        {
            Application.targetFrameRate = FPS;
            RegisterInput();

            _stateMachine = new GameStateMachine(gameZone, new ScoreLogic());
            _stateMachine.Enter(_stateMachine.FigureGenerateState);
        }

        private void RegisterInput()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                InputService = new StandAloneInput();
            }
            else
            {
                InputService = new MobileInput();
            }
        }
    }
}