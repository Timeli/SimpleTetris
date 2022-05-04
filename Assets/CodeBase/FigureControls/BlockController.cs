using System;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class BlockController : MonoBehaviour
    {
        public IInputService Input;

        private StepBefore _stepBefore;

        private bool _isCollided;

        public event Action<StepBefore> Stepped;

        private void Start()
        {
            Input = Game.InputService;
            StartCoroutine(EndFixedUpdate());
        }

        public void FixedUpdate()
        {
            if (_isCollided == false && Input.IsRotate())
            {
                Rotate();
            }
            else if (_isCollided == false) 
            {
                FigureManipulate();
            }

            if (_isCollided)
            {
                ReturnToBeforePosition(_stepBefore);
                _isCollided = false;
            }
        }

        private IEnumerator EndFixedUpdate()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
            while (true)
            {
                yield return waitForFixedUpdate;
                SendStep();
            }
        }

        private void SendStep()
        {
            if (_isCollided == false)
            {
                Stepped?.Invoke(_stepBefore);
                _stepBefore = StepBefore.Idle;
            }
        }

        private void Rotate()
        {
            transform.localRotation *= RotateTo(Constants.RotateDegree);
            _stepBefore = StepBefore.Rotate;
        }

        private void FigureManipulate()
        {

            if (Input.MoveLeft())
            {
                transform.localPosition = MoveTo(-Constants.FigureSize);
                _stepBefore = StepBefore.Left;
            }
            else if (Input.MoveRight())
            {
                transform.localPosition = MoveTo(Constants.FigureSize);
                _stepBefore = StepBefore.Right;
            }
        }

        private void ReturnToBeforePosition(StepBefore stepBefore)
        {
            switch (stepBefore)
            {
                case StepBefore.Left:
                    transform.localPosition = MoveTo(Constants.FigureSize);
                    break;
                case StepBefore.Right:
                    transform.localPosition = MoveTo(-Constants.FigureSize);
                    break;
                case StepBefore.Rotate:
                    transform.localRotation *= RotateTo(-Constants.RotateDegree);
                    break;
            }
            _stepBefore = StepBefore.Idle;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _isCollided = true;
        }

        private Quaternion RotateTo(int rotateToDegree) =>
            Quaternion.Euler(0, 0, rotateToDegree);

        private Vector2 MoveTo(int distance) =>
            new Vector2(transform.localPosition.x + distance, transform.localPosition.y);
    }
}