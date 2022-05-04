using Assets.CodeBase.Services.Input;
using UnityEngine;

namespace Assets.CodeBase
{
    public class StandAloneInput : InputService
    {
        public override bool IsAcceleration() =>
            Input.GetKey(KeyCode.DownArrow);

        public override bool IsRotate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeDuration(_moveStartDuration);
                return true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Time.time - _startMoveTime >= _currentDuration)
            {
                ChangeDuration(_moveDuration);
                return true;
            }
            return false;
        }

        public override bool MoveRight()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeDuration(_moveStartDuration);
                return true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Time.time - _startMoveTime >= _currentDuration)
            {
                ChangeDuration(_moveDuration);
                return true;
            }
            return false;
        }
    }
}