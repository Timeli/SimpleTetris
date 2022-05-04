using UnityEngine;

public class ParticleMoverLine : ParticleMover
{
    protected override void CorrectPosition()
    {
        Vector3 angle = _blockController.transform.eulerAngles;
        Vector3 blockPos = _blockController.transform.localPosition;

        if (angle.z == 0)
            transform.localPosition = GetPositon(blockPos.x + 15, blockPos.y);
        else if (angle.z == 90f)
            transform.localPosition = GetPositon(blockPos.x - 10, blockPos.y + 120);
        else if (angle.z == 180f)
            transform.localPosition = GetPositon(blockPos.x - 40, blockPos.y);
        else if (angle.z == 270f)
            transform.localPosition = GetPositon(blockPos.x - 15, blockPos.y + 60);
    }

    private Vector2 GetPositon(float x, float y) =>
        new Vector2(x, y);
}
