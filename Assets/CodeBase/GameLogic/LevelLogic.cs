using Assets.CodeBase.FigureControls;
using Assets.CodeBase.GameField.FieldCleaner;
using Assets.CodeBase.GameField.TopZone;

namespace Assets.CodeBase.GameLogic
{
    public class LevelLogic
    {
        private const float Difference = 0.035f;
        private const int LinesForLevel = 4;
        private const float StartSpeed = 1f;

        private readonly CleanerHolder _cleanHolder;
        private readonly LevelText _levelText;

        private int _level;
        private int _levelBeforeUpdate;
        private bool _isInit;

        public LevelLogic(CleanerHolder cleanerHolder, LevelText levelText)
        {
            _cleanHolder = cleanerHolder;
            _levelText = levelText;
        }

        public void Update(DownMovement downMovement)
        {
            InitStartSpeed(downMovement);

            _level = _cleanHolder.Lines / LinesForLevel;

            if (_level != _levelBeforeUpdate)
            {
                _levelBeforeUpdate = _level;
                UpdateDownMovementSpeed(downMovement);
                UpdateLeveltext(_level);
            }
        }

        private void InitStartSpeed(DownMovement downMovement)
        {
            if (_isInit == false)
            {
                _isInit = true;
                downMovement.InitStartSpeed(StartSpeed);
            }
        }

        private void UpdateLeveltext(int lines) =>
            _levelText.UpdateLevel(lines);

        private void UpdateDownMovementSpeed(DownMovement downMovement) =>
            downMovement.IncreaseSpeed(Difference);
    }
}
