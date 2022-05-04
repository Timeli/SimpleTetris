using Assets.CodeBase.GameField;
using Assets.CodeBase.GameField.FieldCleaner;
using Assets.CodeBase.GameField.Storeys;
using Assets.CodeBase.GameLogic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class CleanGameFieldState : IFigureManipulateState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly GameZone _gameZone;
        private readonly ScoreLogic _scoreLogic;

        private StoreySetter _storeySetter;
        private ScoreText _scoreText;
        private StoreyLogic _storeyLogic;
        private CleanerHolder _cleanHolder;
        private FieldCleaner _fieldCleaner;
        private GameObject _figure;

        private bool _isGameOver;

        public CleanGameFieldState(GameStateMachine gameStateMachine, GameZone gameZone, ScoreLogic scoreLogic)
        {
            _gameStateMachine = gameStateMachine;
            _gameZone = gameZone;

            InitDependences();
            InitFieldCleaner();
            InitEndGame();

            _scoreLogic = scoreLogic;
            _scoreLogic.Construct(_cleanHolder, _scoreText);
        }

        public void Enter(GameObject figure)
        {
            _figure = figure;

            Enter();
        }

        public void Enter()
        {
            _figure.GetComponentInChildren<BoxColliderActivator>()
                .ActivateColliders(_storeySetter);

            _cleanHolder.CleanField();
        }

        public void Exit(){}

        private void RegroupStoreys()
        {
            RegroupStorey();

            _scoreLogic.Update();

            if (_isGameOver == false)
                _gameStateMachine.Enter(_gameStateMachine.FigureGenerateState);
        }

        private void RegroupStorey()
        {
            _storeyLogic.Initialize(_cleanHolder, _storeySetter);
            _storeyLogic.Regroup();
        }

        private void InitDependences()
        {
            _cleanHolder = _gameZone.GetComponentInChildren<CleanerHolder>();
            _fieldCleaner = _gameZone.GetComponentInChildren<FieldCleaner>();
            _storeyLogic = _gameZone.GetComponentInChildren<StoreyLogic>();
            _storeySetter = _gameZone.GetComponentInChildren<StoreySetter>();
            _scoreText = _gameZone.GetComponentInChildren<ScoreText>();
        }

        private void InitFieldCleaner() =>
            _fieldCleaner.DestroyEnded += RegroupStoreys;


        private void InitEndGame() =>
            _cleanHolder.GameEnded += GameOver;

        private void GameOver()
        {
            _cleanHolder.GameEnded -= GameOver;
            _fieldCleaner.DestroyEnded -= RegroupStoreys;
            _isGameOver = true;

            _gameStateMachine.Enter(_gameStateMachine.GameOverState);
        }
    }
}
