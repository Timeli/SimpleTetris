using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected float _rotateDuration = 0.15f;
        protected float _elapsedRotate = 0.15f;

        protected float _startMoveTime;
        protected float _moveDuration = 0.06f;
        protected float _moveStartDuration = 0.2f;
        protected float _currentDuration;

        public virtual bool IsAcceleration() =>
            UnityEngine.Input.GetKeyDown(KeyCode.DownArrow);

        public virtual bool IsRotate() =>
            UnityEngine.Input.GetKeyDown(KeyCode.Space);

        public virtual bool MoveLeft() => 
            UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow);

        public virtual bool MoveRight() =>
            UnityEngine.Input.GetKeyDown(KeyCode.RightArrow);

        protected void ChangeDuration(float duration)
        {
            _startMoveTime = Time.time;
            _currentDuration = duration;
        }

        public virtual bool IsChangeBlock()
        {
            throw new System.NotImplementedException();
        }
    }
       
}