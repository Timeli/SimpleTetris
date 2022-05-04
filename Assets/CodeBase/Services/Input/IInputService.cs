using UnityEngine;

namespace Assets.CodeBase
{
    public interface IInputService
    {
        bool IsRotate();
        bool IsAcceleration();
        bool IsChangeBlock();
        bool MoveLeft();
        bool MoveRight();
    }
}