using Assets.CodeBase;
using Assets.CodeBase.FigureControls;
using Assets.CodeBase.Infrastructure.States;
using UnityEngine;

public abstract class ParticleMover : MonoBehaviour
{
    [SerializeField]
    protected DownMovement _downMovement;

    [SerializeField]
    protected BlockController _blockController;

    private void Awake() => Initialize();

    private void Initialize()
    {
        _downMovement.SteppedFollower += MoveDown;
        _blockController.Stepped += FollowTo;
    }

    private void OnDestroy()
    {
        _downMovement.SteppedFollower -= MoveDown;
        _blockController.Stepped -= FollowTo;
    }

    private void FollowTo(StepBefore stepBefore)
    {
        switch (stepBefore)
        {
            case StepBefore.Left:
                transform.localPosition = MoveTo(-Constants.FigureSize);
                break;
            case StepBefore.Right:
                transform.localPosition = MoveTo(Constants.FigureSize);
                break;
            case StepBefore.Rotate:
                CorrectPosition();
                break;
            default:
                break;
        }
    }

    protected abstract void CorrectPosition();

    protected Vector2 MoveTo(int distance) =>
           new Vector2(transform.localPosition.x + distance, transform.localPosition.y);

    private void MoveDown() =>
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - Constants.FigureSize);
}
