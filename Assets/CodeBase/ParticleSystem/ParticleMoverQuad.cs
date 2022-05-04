using Assets.CodeBase.FigureControls;
using Assets.CodeBase;
using Assets.CodeBase.Infrastructure.States;
using UnityEngine;

public class ParticleMoverQuad : MonoBehaviour
{
    public DownMovement DownMovement;
    public BlockController BlockController;

    private void Awake() => 
        Initialize();

    private void Initialize()
    {
        DownMovement.SteppedFollower += MoveDown;
        BlockController.Stepped += FollowTo;
    }

    private void OnDestroy()
    {
        DownMovement.SteppedFollower -= MoveDown;
        BlockController.Stepped -= FollowTo;
    }

    private void MoveDown() =>
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - Constants.FigureSize);

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
            default:
                break;
        }
    }

    private Vector2 MoveTo(int distance) =>
            new Vector2(transform.localPosition.x + distance, transform.localPosition.y);
}
