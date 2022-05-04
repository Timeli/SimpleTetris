using UnityEngine;

public class ParticleMoverT : ParticleMover
{
    protected override void CorrectPosition()
    {
        Vector3 angle = _blockController.transform.eulerAngles;
        Vector3 blockPos = _blockController.transform.localPosition;

        if (angle.z == 0)
            transform.localPosition = GetPositon(blockPos.x, blockPos.y + 50);
        else 
            transform.localPosition = GetPositon(blockPos.x, blockPos.y + 110);
    }

    private Vector2 GetPositon(float x, float y) =>
        new Vector2(x, y);
}
