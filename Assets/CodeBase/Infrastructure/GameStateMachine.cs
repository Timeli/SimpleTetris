using Assets.CodeBase.GameField;
using Assets.CodeBase.GameLogic;
using Assets.CodeBase.Infrastructure.States;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure
{
    public class GameStateMachine
    {
        public IState FigureGenerateState { get; private set; }
        public IState GameOverState { get; private set; }
        public IFigureManipulateState FigureMoveState { get; private set; }
        public IFigureManipulateState CleanGameFieldState { get; private set; }

        private IState _currentState;

        public GameStateMachine(GameZone gameZone, ScoreLogic scoreLogic)
        {
            FigureGenerateState = new GenerateFigureState(this, gameZone);
            GameOverState = new GameOverState(this, gameZone, scoreLogic);
            FigureMoveState = new MoveFigureState(this, gameZone);
            CleanGameFieldState = new CleanGameFieldState(this, gameZone, scoreLogic);
        }

        public void Enter(IState state)
        {
            _currentState?.Exit();
            _currentState = state;
            state.Enter();
        }

        public void Enter(IFigureManipulateState state, GameObject figure)
        {
            _currentState?.Exit();
            _currentState = state;
            state.Enter(figure);
        }
    }
}