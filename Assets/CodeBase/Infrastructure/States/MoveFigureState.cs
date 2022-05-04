using Assets.CodeBase.FigureControls;
using Assets.CodeBase.GameField;
using Assets.CodeBase.GameField.FieldCleaner;
using Assets.CodeBase.GameField.TopZone;
using Assets.CodeBase.GameLogic;
using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Infrastructure.States;
using System;
using UnityEngine;

namespace Assets.CodeBase
{
    internal class MoveFigureState : IFigureManipulateState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameZone _gameZone;
        private readonly LevelLogic _levelLogic;

        private FollowerBehave _followerBehave;
        private DownMovement _downMovement;
        private GameObject _figure;
        private CleanerHolder _cleanHolder;
        private LevelText _levelText;

        public MoveFigureState(GameStateMachine gameStateMachine, GameZone gameZone)
        {
            _gameStateMachine = gameStateMachine;
            _gameZone = gameZone;

            InitDependences();

            _levelLogic = new LevelLogic(_cleanHolder, _levelText);
        }

        public void Enter(GameObject figure)
        {
            _figure = figure;
            Enter();
        }

        public void Enter()
        {
            GetScripts();

            _levelLogic.Update(_downMovement);

            _downMovement.Stopped += ExitMoveState;
        }

        public void Exit()
        {

            _downMovement.Stopped -= ExitMoveState;
            DestroyScripts();
        }

        private void InitDependences()
        {
            _cleanHolder = _gameZone.GetComponentInChildren<CleanerHolder>();
            _levelText = _gameZone.GetComponentInChildren<LevelText>();
        }

        private void ExitMoveState() =>
            _gameStateMachine.Enter(_gameStateMachine.CleanGameFieldState, _figure);

        private void GetScripts()
        {
            _downMovement = _figure.GetComponentInChildren<DownMovement>();
            _followerBehave = _figure.GetComponentInChildren<FollowerBehave>();
        }

        private void DestroyScripts()
        {
            GameObject.Destroy(_followerBehave.gameObject);
            GameObject.Destroy(_downMovement.gameObject);
        }
    }
}