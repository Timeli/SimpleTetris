using Assets.CodeBase.GameField;
using Assets.CodeBase.GameField.TopZone;
using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Infrastructure.States;
using CodeBase.Infrastructure;
using UnityEngine;

namespace Assets.CodeBase
{
    public class GenerateFigureState : IState
    {
        private readonly GameFactory _gameFactory;
        private readonly GameStateMachine _stateMachine;
        private readonly GameZone _gameZone;

        private GameObject _figure;

        public GenerateFigureState(GameStateMachine gameStateMachine, GameZone gameZone)
        {
            _stateMachine = gameStateMachine;
            _gameFactory = new GameFactory();
            _gameZone = gameZone;

            InitDependences();
        }

        public void Enter()
        {
            _figure = _gameFactory.CreateFigure();
            _stateMachine.Enter(_stateMachine.FigureMoveState, _figure);
        }

        private void InitDependences()
        {
            _gameZone.GetComponentInChildren<NextFigureShower>().Construct(_gameFactory);
        }

        public void Exit()
        {
        }
    }
}