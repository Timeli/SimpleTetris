using Assets.CodeBase.Infrastructure.States;
using UnityEngine;

namespace Assets.CodeBase.GameField.FieldCleaner
{
    public class Cleaner : MonoBehaviour
    {
        private const string Block = "Block";
        private float RayDistance = Screen.width * 0.9f;
        private Vector3 _startPosition;

        private void Start() =>
            _startPosition = transform.localPosition;


        public void CastRay(out RaycastHit2D[] hit2D)
        {
            hit2D = Physics2D.RaycastAll(transform.position, Vector2.left, RayDistance, 1 << LayerMask.NameToLayer(Block));
        }

        public void DoStep() =>
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + Constants.FigureSize);

        public void ToStartPosition() =>
            transform.localPosition = _startPosition;
    }
}