using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Infrastructure.States;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.FigureControls
{
    public class DownMovement : MonoBehaviour
    {
        [SerializeField]
        private ParticleActivator _particleActivator;

        private const float MinimalFallingSpeed = 0.05f;
        private static float _fallingSpeed;
        
        public Transform BottomChecker;

        public IInputService Input;

        private Collider2D _collider;
        private int _collidedCounter;

        private float _currentSpeed;
        private float _timeCounter;
        private bool _isFall = true;

        public ContactFilter2D contactFilter;
        private readonly List<Collider2D> _overlapColliders = new();

        public Action SteppedFollower;
        public Action Stopped;

        private void Start()
        {
            _collider = BottomChecker.GetComponent<Collider2D>();
            Input = Game.InputService;
        }

        private void FixedUpdate()
        {
            CheckBottom();
            FallDown();
            Accelerate();
        }

        public void IncreaseSpeed(float value)
        {
            if (value < 0)
                throw new InvalidOperationException();

            if (_fallingSpeed - value >= MinimalFallingSpeed)
                _fallingSpeed -= value;
        }

        public void InitStartSpeed(float value) =>
            _fallingSpeed = value;

        private void Accelerate()
        {
            if (Input.IsAcceleration())
            {
                if (_currentSpeed != Constants.AccelerationSpeed)
                {
                    _currentSpeed = Constants.AccelerationSpeed;
                    _particleActivator.Activate();
                }
            }
            else
            {
                if (_currentSpeed != _fallingSpeed)
                {
                    _currentSpeed = _fallingSpeed;
                    _particleActivator.Deactivate();
                }
            }
        }

        private void FallDown()
        {
            _timeCounter += Time.deltaTime;
            if (_isFall)
            {
                if (_timeCounter >= _currentSpeed)
                {
                    Falling();
                    SteppedFollower?.Invoke();
                    _timeCounter = 0;
                }
            }
        }

        private void CheckBottom()
        {
            if (_collider.OverlapCollider(contactFilter, _overlapColliders) > 0)
            {
                if (Input.IsAcceleration())
                    _collidedCounter = Constants.CollidedBeforeStop;

                _collidedCounter++;
                _isFall = false;
                _particleActivator.Deactivate();
                StopMoving();
            }
            else
            {
                _isFall = true;
                _collidedCounter = 0;
            }
        }

        private void StopMoving()
        {
            if (_collidedCounter >= Constants.CollidedBeforeStop)
                Stopped?.Invoke();
        }

        private void Falling() =>
            transform.localPosition = new Vector2(transform.localPosition.x,
                                                  transform.localPosition.y - Constants.FigureSize);
    }
}