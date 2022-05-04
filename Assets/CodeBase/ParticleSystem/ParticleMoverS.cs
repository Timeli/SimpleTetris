using UnityEngine;

public class ParticleMoverS : ParticleMover
{
    protected override void CorrectPosition()
    {
        Vector3 angle = _blockController.transform.eulerAngles;
        Vector3 blockPos = _blockController.transform.localPosition;

        if (angle.z == 0)
            transform.localPosition = CreatePos(blockPos.x, blockPos.y + 50);
        else if (angle.z == 90f)
            transform.localPosition = CreatePos(blockPos.x + 30, blockPos.y + 110);
        else if (angle.z == 180f)
            transform.localPosition = CreatePos(blockPos.x, blockPos.y + 110);
        else if (angle.z == 270f)
            transform.localPosition = CreatePos(blockPos.x - 30, blockPos.y + 110);
    }

    private Vector2 CreatePos(float x, float y) =>
        new Vector2(x, y);
}
