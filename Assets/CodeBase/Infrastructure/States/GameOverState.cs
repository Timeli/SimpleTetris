using Assets.CodeBase.Data;
using Assets.CodeBase.GameField;
using Assets.CodeBase.GameLogic;

namespace Assets.CodeBase.Infrastructure.States
{
    public class GameOverState : IState
    {
        private GameStateMachine _gameStateMachine;
        private GameZone _gameZone;
        private ScoreLogic _scoreLogic;
        private SaverService _saver;

        public GameOverState(GameStateMachine gameStateMachine, GameZone gameZone, ScoreLogic scoreLogic)
        {
            _gameStateMachine = gameStateMachine;
            _gameZone = gameZone;
            _scoreLogic = scoreLogic;
            _saver = new SaverService();
        }

        public void Enter()
        {
            _saver.LoadSaveFile();

            if (_saver.CurrentBestScore < _scoreLogic.Count)
                _saver.SaveBestScore(_scoreLogic.Count);

            _gameZone.GetComponentInChildren<GameOverWindow>()
                .Activate(_saver.CurrentBestScore, _scoreLogic.Count);
        }

        public void Exit()
        {
        }
    }
}
