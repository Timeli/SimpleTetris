using Assets.CodeBase.Services.Input;
using Services.Input;
using UnityEngine;

namespace Assets.CodeBase
{
    public class MobileInput : InputService
    {
        private bool _isPressedLeft;
        private bool _isPressedRight;

        public override bool IsAcceleration() =>
            AccelerateButton.IsAccelerate;

        public override bool IsRotate()
        {
            if (RotateButton.IsRotate)
            {
                if (_elapsedRotate >= _rotateDuration)
                {
                    _elapsedRotate = 0;
                    return true;
                }
            }
            _elapsedRotate += Time.fixedDeltaTime;
            return false;
        }

        public override bool MoveLeft()
        {
            if (MoveLeftButton.Pressed && _isPressedLeft == false)
            {
                ChangeDuration(_moveStartDuration);
                _isPressedLeft = true;
                return true;
            }
            else if (MoveLeftButton.Pressed && Time.time - _startMoveTime >= _currentDuration)
            {
                ChangeDuration(_moveDuration);
                return true;
            }
            else if (MoveLeftButton.Pressed == false)
            {
                _isPressedLeft = false;
            }

            return false;
        }

        public override bool MoveRight()
        {
            if (MoveRightButton.Pressed && _isPressedRight == false)
            {
                ChangeDuration(_moveStartDuration);
                _isPressedRight = true;
                return true;
            }
            else if (MoveRightButton.Pressed && Time.time - _startMoveTime >= _currentDuration)
            {
                ChangeDuration(_moveDuration);
                return true;
            }
            else if (MoveRightButton.Pressed == false)
            {
                _isPressedRight = false;
            }

            return false;
        }
       
    }
}
    