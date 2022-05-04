namespace Assets.CodeBase.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }

    public interface IFigureManipulateState : IState
    {
        void Enter(UnityEngine.GameObject figure);
    }
}